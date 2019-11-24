using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1
{
    class Task1_6FontAdjustment
    {
        [Flags] public enum FontFormat //A structure that contains font formats
        { 
            None = 0,//Default value
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
        private static void timerExit(object state) {
           if(noResponse) Environment.Exit(0);//Terminate application
        }
        private static bool noResponse = true;//State of no response from user
        //If user don't push enter that counts for no response
        public static void ConsoleInterface()//An interaction interface
        {
            Console.WriteLine("The application will automatically close after a minute if " +
                "no input is provided.");
            Timer timer = new Timer(timerExit,null,60000,60000);//Create timer to escape infinite loop
            FontFormat[] formats = (FontFormat[])Enum.GetValues(typeof(FontFormat));//Create a list of formats
            FontFormat fontFormatVal = new FontFormat();//Initialization of new FontFormat object
            int numberOfProperties = 0;//Number of font properties
            do {
                numberOfProperties = 0;//reset the value
                Console.Write("Inscription Parameters: ");
                Console.Write(fontFormatVal);//Output current font format
                Console.WriteLine("\n Type-in:"); 
                Console.WriteLine("1: " + FontFormat.Bold);
                Console.WriteLine("2: " + FontFormat.Italic);
                Console.WriteLine("3: " + FontFormat.Underline);
                int inputValue = 0;
                do {
                    noResponse = true;//Change the user state to default
                    Int32.TryParse(Console.ReadLine(), out inputValue); //Read the format index 
                    noResponse = false;//Change the user state to response
                    timer.Change(60000, 60000);//reset timer
                }
                while (inputValue < 1 || inputValue>3);//Until the index is correct
                    fontFormatVal = fontFormatVal.HasFlag(formats[inputValue]) ?//If current format contains
                    //input format
                            fontFormatVal ^ formats[inputValue]//Exclude the format
                            : fontFormatVal.HasFlag(formats[inputValue]) ?//If current format is none
                            formats[inputValue] //Rewrite the format  
                            : fontFormatVal | formats[inputValue]; //Include the format               
            } while (true); 
        }
    }
}
