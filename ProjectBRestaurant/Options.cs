namespace ProjectBRestaurant
{
    class Options
    {
        public static int listOfChoice(bool canCancel, params string[] options)
        {
            // const int startY = 8;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    // Console.SetCursorPosition(0, startY + i);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Blue;

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
                            if (currentSelection < options.Length - 1)
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
