using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main() {
            int selectedClass = ConsoleHelper.MultipleChoice(true, "Login", "Regristeren", "Reserveren", "Contact informatie");
            // bool keepLooping = true;
            // int itemSelected;
            // while (keepLooping){
            //     Console.WriteLine("Type de nummer van de volgende onderdelen:");
            //     Console.ForegroundColor = ConsoleColor.Blue;
            //     Console.WriteLine("[1] Login Scherm");
            //     Console.ForegroundColor = ConsoleColor.White;
            //     Console.WriteLine("[2] Reserveren");
            //     Console.WriteLine("[3] Contact informatie");
            //     Console.WriteLine("[0]");
            //     var Scherm = Console.ReadLine();
            //     if (Scherm == "1") {
            //         // while login true
            //           //  Console.WriteLine("Login");
            //             var tmpScherm = Console.ReadLine();
            //             if (tmpScherm == "1"){
            //                 Console.WriteLine("kies de type account");
            //                 if (Console.ReadLine() == "1"){
            //                     Console.WriteLine("U wilt een ");
            //                 }
            //             else if (tmpScherm == "2"){
            //                 Console.WriteLine("kies de type account");
            //             }
            //         } 
            //     }
            //     else if (Scherm == "2") {
            //         Console.WriteLine("Reserveren");
            //     }
            //     else if (Scherm == "3") {
            //         Console.WriteLine("Contact");
            //     }
            //     else if (Scherm == "0") {
            //         return;
            //     }
            // }
        }
    }
    class ConsoleHelper
    {
    public static int MultipleChoice(bool canCancel, params string[] options)
        {
        const int startY = 8;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
            {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
                {
                Console.SetCursorPosition(0, startY + i);

                if(i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(options[i]);

                Console.ResetColor();
                }

            key = Console.ReadKey(true).Key;

            switch (key)
                {
                case ConsoleKey.UpArrow:
                    {
                    if (currentSelection > 0)
                        currentSelection--;
                    break;
                    }
                case ConsoleKey.DownArrow:
                    {
                    if (currentSelection < options.Length-1)
                        currentSelection++;
                    break;
                    }
                case ConsoleKey.Escape:
                    {
                    if (canCancel)
                        return -1;
                    break;
                    }
                }
            } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
        }
    }
}
