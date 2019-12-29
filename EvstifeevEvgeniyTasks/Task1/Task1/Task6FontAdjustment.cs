using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1
{
    internal class Task6FontAdjustment
    {
        // A structure that contains font formats.
        [Flags] 
        internal enum FontFormat 
        {
            // None is default value.
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
            // Every value is a power of two in order to use binary operations.
        }
        // State of no response from user.
        private static bool noResponse = true;
        // If user don't push enter that counts for no response.
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            Console.WriteLine("The application will automatically close after a minute if " +
                "no input is provided.");
            // Create timer to escape infinite loop.
            Timer timer = new Timer(TimerExit,null,60000,60000);
            // Create a list of formats.
            FontFormat[] formats = (FontFormat[])Enum.GetValues(typeof(FontFormat));
            // Initialization of new FontFormat object.
            FontFormat fontFormatVal = new FontFormat();
            do {
                Console.Write("Inscription Parameters: ");
                // Output current font format.
                Console.Write(fontFormatVal);
                Console.WriteLine("\n Type-in:"); 
                Console.WriteLine("1: " + FontFormat.Bold);
                Console.WriteLine("2: " + FontFormat.Italic);
                Console.WriteLine("3: " + FontFormat.Underline);
                int inputValue = 0;
                do 
                {
                    // Change the user state to default.
                    noResponse = true;
                    // Read the format index.
                    Int32.TryParse(Console.ReadLine(), out inputValue);
                    // Change the user state to response.
                    noResponse = false;
                    // Reset timer.
                    timer.Change(60000, 60000);
                }
                // Until the index is correct.
                while (inputValue < 1 || inputValue>3);
                // If current format contains input format
                fontFormatVal = fontFormatVal.HasFlag(formats[inputValue]) ?
                            // Exclude the format.
                            fontFormatVal ^ formats[inputValue]
                            : // If current format is none.
                            fontFormatVal.HasFlag(formats[inputValue]) ?
                            // Rewrite the format. 
                            formats[inputValue]
                            :  // Include the format.       
                            fontFormatVal | formats[inputValue];     
            } while (true); 
        }
        private static void TimerExit(object state)
        {
            // Terminate application.
            if (noResponse) Environment.Exit(0);
        }
    }
}
