using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arguments for ConsoleInterface
            string[] newArgs = new string[2] { "", "" };
            if (args.Length < 1)
            {
                Console.WriteLine("No console arguments has been found.");
            }
            else
            {
                newArgs = args;
            }

            do
            {
                if (args.Length < 1 || newArgs[0] == "")
                {
                    // Read the working directory
                    Console.WriteLine("Enter directory path:");
                    newArgs[0] = Console.ReadLine();
                }
                if (newArgs[0] != "")
                {
                    try
                    {
                        DirectoryInfo directory = new DirectoryInfo(newArgs[0]);
                        // Check if the directory exists
                        if (directory.Exists)
                        {
                            // Run ConsoleInterface
                            Console.WriteLine("Directory path is correct.");
                            Console.WriteLine($"Current directory: {directory.FullName}");
                            ConsoleInterface(newArgs);
                        }
                        else
                        {
                            Console.WriteLine("Invalid directory path - try again.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected error. " + Environment.NewLine + e.Message);
                    }
                    newArgs[0] = "";
                }
            } while (newArgs[0] == "");

        }

        /// <summary>
        /// Implements a user interface for both backup and watch modes. 
        /// Takes first elements in args as the working directory path and
        /// second as the mode's name.
        /// </summary>
        /// <param name="args"></param>
        static void ConsoleInterface(string[] args)
        {
            // If second argument exists and it refers to the backup mode.
            if (args.Length > 1 && args[1].ToLower().Contains("backup"))
            {
                Console.WriteLine("The backup mode's been activated.");
                Console.WriteLine("Enter the restore date and time:");
                string s2 = "";
                do
                {
                    s2 = Console.ReadLine().ToLower();
                    if (DateTime.TryParse(s2, out DateTime backupDateTime))
                    {
                        backup(backupDateTime);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date or time format. Example: 22/12/2019 18:00:00");
                    }
                }
                while (s2 != "q");
                Console.WriteLine("The backup mode's been deactivated.");
                args[1] = "";
            }
            // If second argument exists and it refers to the watch mode.
            else if (args[1].ToLower().Contains("watch"))
            {
                Console.WriteLine("The watch mode's been activated.");
                Watch(args[0]);
                Console.WriteLine("The watch mode's been deactivated.");
                args[1] = "";
            }
            // If there is no second argument - read it.
            string s = "";
            do
            {
                Console.WriteLine("Enter \"watch\" to start text files watching or " +
                    "\"backup\" to start text files watching");
                Console.WriteLine("Enter 'q' to close program.");
                s = Console.ReadLine().ToLower();
                if (s.Contains("backup"))
                {
                    Console.WriteLine("The backup mode's been activated.");
                    Console.WriteLine("Enter the restore date and time or 'q' to change the mode:");
                    string s2 = "";
                    do
                    {
                        // Read restore date and time
                        s2 = Console.ReadLine().ToLower();
                        if (DateTime.TryParse(s2, out DateTime backupDateTime))
                        {
                            // Run backup mode
                            backup(backupDateTime);
                        }
                    }
                    while (s2 != "q");
                    Console.WriteLine("The backup mode's been deactivated.");
                }
                else
                if (s.Contains("watch"))
                {
                    // Run watch mode
                    Console.WriteLine("The watch mode's been activated.");
                    Watch(args[0]);
                    Console.WriteLine("The watch mode's been deactivated.");
                }
                else if (s != "q")
                {
                    Console.WriteLine("Unknown command.");
                }
            }
            while (s != "q");
            // Terminate the program
            Environment.Exit(0);

        }
        /// <summary>
        /// Use directory path to watch the changes of all text files contained in it.
        /// </summary>
        /// <param name="directoryPath"></param>
        static void Watch(string directoryPath)
        {
            // Example directory path:
            // string directoryPath = "K:/Example/";

            // Set up the filter
            string filter = "*.txt";

            // Create DirectoryInfo about the working directory
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Save the directory and all subdirectories
            List<DirectoryInfo> directories = new List<DirectoryInfo>();
            directories.Add(directoryInfo);
            directories.AddRange(directoryInfo.GetDirectories());

            // Create watchers to watch file changes
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
            foreach (var directory in directories)
            {
                // Add watch for every directory
                watchers.Add(new FileSystemWatcher(directory.FullName, filter));
                foreach (var file in directory.GetFiles(filter))
                {
                    // Create logs for current files to backup if they will be deleted
                    Log log = new Log(DateTime.Now, file.FullName, file.FullName, default);
                    List<string> fileData = new List<string>();
                    // Copy the file data to the log
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        while (!sr.EndOfStream)
                        {
                            var t = sr.ReadLineAsync();
                            t.Wait();
                            fileData.Add(t.Result);
                        }
                    }
                    // Add file data to the log
                    log.AddAllLines(fileData);

                    // Clearing previous log file (some access exceptions occure when 
                    // the log file contains previous logs)
                    using (StreamWriter sw = new StreamWriter(logFileName))
                    {

                    }
                    // Save log to the log file by serialising it using Newtonsoft Json
                    using (StreamWriter sw = new StreamWriter(logFileName, true))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(log));

                    }
                }
            }
            // Set up all watchers
            foreach (var watcher in watchers)
            {
                // Set up the filter for watchable changes
                watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                // Start watching.
                watcher.EnableRaisingEvents = true;
            }
            Console.WriteLine("Enter 'q' to quit the watch mode.");
            string temp = "";
            do
            {
                temp = Console.ReadLine();
                if (temp != "q")
                {
                    Console.WriteLine("Unknown command.");
                }
            } while (temp != "q");
            foreach (var watcher in watchers)
            {

                // Add event handlers.
                watcher.Changed -= OnChanged;
                watcher.Created -= OnChanged;
                watcher.Deleted -= OnChanged;
                watcher.Renamed -= OnRenamed;

                // Change the flag to start watching.
                watcher.EnableRaisingEvents = false;
            }
        }
        /// <summary>
        /// The log file's name.
        /// </summary>
        static string logFileName = Environment.CurrentDirectory + "\\Log.json";

        /// <summary>
        /// Run if file was created, changed or deleted. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            //Current date and time
            DateTime currentFileDateTime = DateTime.Now;

            //Create new log
            Log log = new Log(currentFileDateTime, e.FullPath, e.FullPath, e.ChangeType);

            Console.WriteLine($"File: {e.FullPath} has been {e.ChangeType} at " +
                $"{currentFileDateTime.ToLongDateString()} {currentFileDateTime.ToLongTimeString()}");
            //Write all file data if file was created or changed
            if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
            {
                List<string> fileData = new List<string>();
                using (StreamReader sr = new StreamReader(e.FullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        var t = sr.ReadLineAsync();
                        t.Wait();
                        fileData.Add(t.Result);
                    }

                }
                log.AddAllLines(fileData);
            }

            //Serialize log using Newtonsoft Json
            using (StreamWriter sw = new StreamWriter(logFileName, true))
            {
                sw.WriteLine(JsonConvert.SerializeObject(log));
            }
        }
        /// <summary>
        /// Run if file was renamed
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        static void OnRenamed(object source, RenamedEventArgs e)
        {

            DateTime currentFileDateTime = DateTime.Now;
            Log log = new Log(currentFileDateTime, e.FullPath, e.OldFullPath, e.ChangeType);

            Console.WriteLine($"File {e.OldFullPath} has been renamed to {e.FullPath} at " +
                $"{currentFileDateTime.ToLongDateString()} {currentFileDateTime.ToLongTimeString()}");

            //Serialize log using Newtonsoft Json
            using (StreamWriter sw = new StreamWriter(logFileName, true))
            {
                sw.WriteLine(JsonConvert.SerializeObject(log));
            }
        }

        /// <summary>
        /// Use the log file to restore the files to state at the specified DateTime backupTime.
        /// </summary>
        /// <param name="backupTime"></param>
        static void backup(DateTime backupTime)
        {
            //Check if the log file exists
            if (!File.Exists(logFileName))
            {
                Console.WriteLine("The log file has not been found.");
                return;
            }

            // Clear list of logs
            listOfLogs.Clear();

            // Fill the list
            using (StreamReader sr = new StreamReader(logFileName))
            {
                while (!sr.EndOfStream)
                {
                    // Deserialize log from .json file
                    Log log = JsonConvert.DeserializeObject<Log>(sr.ReadLine());
                    listOfLogs.Add(log);
                }
            }

            // Initialize lastLogIndex if it was not initialized before 
            if (lastLogIndex == -1)
            {
                // The last index in the collection
                lastLogIndex = listOfLogs.Count() - 1;
            }


            if (listOfLogs[lastLogIndex].logdate == backupTime)
            {
                Console.WriteLine("The backup is not required.");
                return;
            }

            bool[] usedLogs = new bool[listOfLogs.Count()];

            for (int i = 0; i < usedLogs.Length; i++) usedLogs[i] = false;

            // Check if the restore time is forward or reverse
            bool condition = listOfLogs[lastLogIndex].logdate < backupTime;

            if (condition)
            {
                
                //for (int i = 0; i < listOfLogs.Count; i++)
                //{

                //    if (listOfLogs[i].logdate == default) { }
                //}
            }
            else 
            { 
            
            }
            //lastLogIndex += !condition ? -1 : 0;
            //if (lastLogIndex < 0) lastLogIndex = 0;
            //if (lastLogIndex >= listOfLogs.Count) lastLogIndex = listOfLogs.Count - 1;

            // Check all logs from the list in order specified by the condition
            for (//int i1 = condition ? lastLogIndex : listOfLogs.Count - 1;
            int i1 = lastLogIndex;
        condition ? i1 < listOfLogs.Count : i1 >= lastLogIndex;
      //   condition ? i1 < listOfLogs.Count : i1 >= lastLogIndex;
            i1 += condition ? 1 : -1)
            {
                Log log = listOfLogs[i1];
                if (!usedLogs[i1])
                    if (condition)
                    {
                        // Reverse time case

                        // Check if log date is not more than desired date
                        if (log.logdate <= backupTime)
                        {
                            // Update last log index
                            lastLogIndex = i1;

                            // Show the log data
                            Console.WriteLine(Environment.NewLine + "Found:");

                            Console.WriteLine($"{log.changeType} '\t' {log.fileFullName} '\t' {log.logdate.ToShortDateString()} " +
                                $"{log.logdate.ToLongTimeString()}'\t'");

                            // Uncomment if file data representation is needed
                            //Console.WriteLine("File data:");
                            //foreach (var item in log._fileChanges)
                            //{
                            //    Console.WriteLine(item);
                            //}

                            // File was changed or file was saved initially 
                            if (log.changeType == WatcherChangeTypes.Changed || log.changeType == default)
                            {
                                // Create or rewrite file using log file data
                                using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                {
                                    for (int i = 0; i < log._fileChanges.Count; i++)
                                    {
                                        // Use WriteAsync for the last line to evade undesired line
                                        var t = i != log._fileChanges.Count - 1 ?
                                            Task.Run(() => sw.WriteLineAsync(log._fileChanges[i]))
                                            :
                                            Task.Run(() => sw.WriteAsync(log._fileChanges[i]));
                                        t.Wait();
                                    }
                                }

                            }
                            // File was renamed
                            else if (log.changeType == WatcherChangeTypes.Renamed)
                            {
                                if (File.Exists(log.fileOldName))
                                {
                                    // Create a copy of the file with old name and delete the old file
                                    File.Copy(log.fileOldName, log.fileFullName, true);
                                    File.Delete(log.fileOldName);
                                }
                                for (int i = lastLogIndex - 1; i >= 0; i--)
                                {
                                    if (listOfLogs[i].changeType == WatcherChangeTypes.Changed && !usedLogs[i])
                                    {
                                        // Create or rewrite file using log file data
                                        using (StreamWriter sw = new StreamWriter(log.fileOldName))
                                        {
                                            for (int j = 0; j < listOfLogs[i]._fileChanges.Count; j++)
                                            {
                                                // Use WriteAsync for the last line to evade undesired line
                                                var t = i != listOfLogs[i]._fileChanges.Count - 1 ?
                                                    Task.Run(() => sw.WriteLineAsync(listOfLogs[i]._fileChanges[i]))
                                                    :
                                                    Task.Run(() => sw.WriteAsync(listOfLogs[i]._fileChanges[i]));
                                                t.Wait();
                                            }
                                        }
                                        usedLogs[i] = true;
                                        break;
                                    }
                                }
                            }
                            // File was created
                            else if (log.changeType == WatcherChangeTypes.Created)
                            {
                                // Create the file
                                using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                {

                                }

                            }
                            // File was deleted
                            else if (log.changeType == WatcherChangeTypes.Deleted)
                            {
                                // Delete the file
                                File.Delete(log.fileFullName);
                            }

                        }
                        else
                        {
                            //Ignore all other logs
                        }
                    }
                    else
                    {
                        // Forward time case
                        // Every method runs as in previous case but in reverse mode
                        // Check if log date is not less than desired date
                        if (log.logdate >= backupTime)
                        {
                            // Update log index
                            lastLogIndex = i1;

                            // Show the log data
                            Console.WriteLine(Environment.NewLine + "Found:");
                            Console.WriteLine($"{log.changeType} '\t' {log.fileFullName} '\t' {log.logdate.ToShortDateString()} " +
                                $"{log.logdate.ToLongTimeString()}'\t'");

                            // Uncomment if file data representation is needed
                            //Console.WriteLine("File data:");
                            //foreach (var item in log._fileChanges)
                            //{
                            //    Console.WriteLine(item);
                            //}

                            // File was changed or created initially
                            if (log.changeType == WatcherChangeTypes.Changed || log.changeType == default)
                            {
                                // Create or rewrite file using log file data
                                using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                {
                                    for (int i = 0; i < log._fileChanges.Count; i++)
                                    {
                                        // Use WriteAsync for the last line to evade undesired line
                                        var t = i != log._fileChanges.Count - 1 ?
                                            Task.Run(() => sw.WriteLineAsync(log._fileChanges[i]))
                                            :
                                            Task.Run(() => sw.WriteAsync(log._fileChanges[i]));
                                        t.Wait();
                                    }
                                }
                            }
                            // File was renamed
                            else if (log.changeType == WatcherChangeTypes.Renamed)
                            {
                                if (File.Exists(log.fileFullName))
                                {
                                    // Create a copy of the file with new name and delete the old file
                                    if (log.fileFullName != log.fileOldName)
                                    {
                                        File.Copy(log.fileFullName, log.fileOldName, true);
                                    }
                                    File.Delete(log.fileFullName);
                                }
                                else
                                {

                                    for (int i = lastLogIndex - 1; i >= 0; i--)
                                    {
                                        if ((listOfLogs[i].changeType == WatcherChangeTypes.Changed
                                            || listOfLogs[i].changeType == WatcherChangeTypes.Created) && !usedLogs[i])
                                        {
                                            // Create or rewrite file using log file data
                                            using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                            {
                                                for (int j = 0; j < listOfLogs[i]._fileChanges.Count; j++)
                                                {
                                                    // Use WriteAsync for the last line to evade undesired line
                                                    var t = i != listOfLogs[i]._fileChanges.Count - 1 ?
                                                        Task.Run(() => sw.WriteLineAsync(listOfLogs[i]._fileChanges[i]))
                                                        :
                                                        Task.Run(() => sw.WriteAsync(listOfLogs[i]._fileChanges[i]));
                                                    t.Wait();
                                                }
                                            }
                                            usedLogs[i] = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            // File was created
                            else if (log.changeType == WatcherChangeTypes.Created)
                            {
                                if (File.Exists(log.fileFullName))
                                {
                                    // Delete file
                                    File.Delete(log.fileFullName);
                                }
                                else
                                {

                                    for (int i = lastLogIndex + 1; i < listOfLogs.Count(); i++)
                                    {
                                        if (listOfLogs[i].changeType == WatcherChangeTypes.Renamed
                                            && listOfLogs[i].fileOldName == log.fileFullName
                                            && !usedLogs[i])
                                        {
                                            // Create a copy of the file with new name and delete the old file
                                            if (listOfLogs[i].fileFullName != listOfLogs[i].fileOldName)
                                            {
                                                File.Copy(listOfLogs[i].fileFullName, listOfLogs[i].fileOldName, true);
                                            }
                                            File.Delete(listOfLogs[i].fileFullName);

                                            usedLogs[i] = true;
                                            break;
                                        }
                                    }
                                }

                            }
                            // File was deleted
                            else if (log.changeType == WatcherChangeTypes.Deleted)
                            {
                                // Create empty file
                                using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                {

                                }

                                for (int i = lastLogIndex - 1; i >= 0; i--)
                                {
                                    if (listOfLogs[i].changeType == WatcherChangeTypes.Changed && !usedLogs[i])
                                    {
                                        // Create or rewrite file using log file data
                                        using (StreamWriter sw = new StreamWriter(log.fileFullName))
                                        {
                                            for (int j = 0; j < listOfLogs[i]._fileChanges.Count; j++)
                                            {
                                                // Use WriteAsync for the last line to evade undesired line
                                                var t = i != listOfLogs[i]._fileChanges.Count - 1 ?
                                                    Task.Run(() => sw.WriteLineAsync(listOfLogs[i]._fileChanges[i]))
                                                    :
                                                    Task.Run(() => sw.WriteAsync(listOfLogs[i]._fileChanges[i]));
                                                t.Wait();
                                            }
                                        }
                                        usedLogs[i] = true;
                                        break;
                                    }
                                }

                                // Note: since we don't know the file data at the moment it
                                // is not possible to restore this file unless we will not read
                                // the previous logs
                            }
                        }
                    }
                usedLogs[i1] = true;
            }
            Console.WriteLine("Backup's been done.");
            Console.WriteLine($"Current state date and time: {listOfLogs[lastLogIndex].logdate.ToShortDateString()}" +
                $"+{listOfLogs[lastLogIndex].logdate.ToLongTimeString()}");
            Console.WriteLine("Enter the restore date and time:");
        }

        static List<Log> listOfLogs = new List<Log>();

        // Track the last position in the log file which corresponds to 
        // the last state of the files
        static int lastLogIndex = -1;
    }
}
