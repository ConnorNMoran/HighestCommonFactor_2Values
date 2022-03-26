using System;

namespace HighestCommonFactor_2Values
{
    class HCF
    {
        enum YesNoPrompt
        {
            Yes,
            No,
            Invalid
        };

        static void Main(string[] args)
        {
            //Establish start of program
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This program will work out the highest common factor of two integers.");

            //Repeat input and algorithm until user is satisfied 
            while (true)
            {
                int[] values = GetInputsFromUser();
                int result = HighestFactor(values[0], values[1]);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The highest common factor is:");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result}\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Would you like to try two new values?");
                Console.WriteLine("Please enter Y or N.");

                YesNoPrompt answer = PromptUserYesNo();

                if (answer == YesNoPrompt.No)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you.");


            Console.ForegroundColor = ConsoleColor.Red;
        }


        private static YesNoPrompt PromptUserYesNo()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                string userResponse = Console.ReadLine();
                string userAnswer = userResponse.Trim().ToUpperInvariant();

                Console.WriteLine("");

                YesNoPrompt promptAnswer = (userAnswer == "Y" ? YesNoPrompt.Yes : (userAnswer == "N" ? YesNoPrompt.No : YesNoPrompt.Invalid));

                if (promptAnswer == YesNoPrompt.Invalid)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
                else
                {
                    return promptAnswer;
                }
            }
        }

        //Get the values from the user, making sure to error check.
        private static int[] GetInputsFromUser()
        {
            int[] values = new int[2];

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please write the first value you wish to input:");

            int count = 0;
            while (count < 2)
            {
                Console.ForegroundColor = ConsoleColor.White;

                string line = Console.ReadLine();
                int value;
                Console.WriteLine("");

                if (int.TryParse(line, out value))
                {
                    values[count] = value;
                    count++;

                    if (count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Now write the second value you wish to input:");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("This is not a valid integer. Please enter an integer.");
                }
            }

            return values;
        }

        //Recursive function using the Euclidean algorithm.
        private static int HighestFactor(int value1, int value2)
        {
            if (value2 == 0)
            {
                return value1;
            }

            return HighestFactor(value2, value1 % value2);
        }
    }
}