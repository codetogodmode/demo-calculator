namespace Calculator;

enum Operation
{
    Add, //0
    Substract, //1
    Multiply, //2
    Divide, //3
    Invalid //4
}

class Program
{
    static void Main(string[] args)
    {
        //Deklarace proměnných
        bool running = true;
        string textInput;
        Operation choice;

        float firstNumber;
        float secondNumber;
        float result;

        WelcomeScreen();

        while (running)
        {
            choice = Menu();

            if (choice == Operation.Invalid)
            {
                continue;
            }

            firstNumber = GetNumber("první");
            secondNumber = GetNumber("druhé");

            //Výpis operace
            Console.WriteLine($"Vybral sis operaci {choice} | První číslo: {firstNumber} | Druhé číslo: {secondNumber}");

            result = Calculate(choice, firstNumber, secondNumber);

            Console.WriteLine($"Výsledek: {result}");

            running = ContinueApplication();
        }
    }

    static Operation Menu()
    {
        string textInput;
        int choiceNumber;
        Operation choice;
        bool isValidInput;

        DisplayMenuOptions();
        //Vyčtení vybrané operace
        textInput = Console.ReadLine();
        choiceNumber = int.Parse(textInput);

        isValidInput = IsOperationInputValid(choiceNumber);
        if (!isValidInput)
        {
            return Operation.Invalid;
        }
        choice = (Operation)(choiceNumber - 1);
        return choice;
    }

    static float Calculate(Operation selectedOperation, float firstNumber, float secondNumber)
    {
        if (selectedOperation == Operation.Add)
        {
            return Add(firstNumber, secondNumber);
        }
        else if (selectedOperation == Operation.Substract)
        {
            return Substract(firstNumber, secondNumber);
        }
        else if (selectedOperation == Operation.Multiply)
        {
            return Multiply(firstNumber, secondNumber);
        }
        else if (selectedOperation == Operation.Divide)
        {
            return Divide(firstNumber, secondNumber);
        }
        else
        {
            Console.WriteLine("Zadal jsi špatnou operaci");
            return 0F;
        }
    }

    static float Add(float firstNumber, float secondNumber)
    {
        return firstNumber + secondNumber;
    }

    static float Substract(float firstNumber, float secondNumber)
    {
        return firstNumber - secondNumber;
    }

    static float Multiply(float firstNumber, float secondNumber)
    {
        return firstNumber * secondNumber;
    }

    static float Divide(float firstNumber, float secondNumber)
    {
        if (secondNumber != 0)
        {
            return firstNumber / secondNumber;
        }
        else
        {
            Console.WriteLine("Nulou se nedá dělit");
            return 0F;
        }
    }

    static bool ContinueApplication()
    {
        string textInput;
        Console.WriteLine("Chceš další výpočet? (y)");
        textInput = Console.ReadLine();
        textInput = textInput.ToLower();
        Console.WriteLine();
        if (textInput == "y")
        {
            Console.WriteLine($"Uživatel zadal {textInput}, Kalkulačka ukončena");
            return true;
        }
        return false;
    }

    static bool IsOperationInputValid(int operationNumberToCheck)
    {
        //Kontrola vstupu
        if (operationNumberToCheck < 1 || operationNumberToCheck > 4)
        {
            Console.WriteLine("Napsal jsi špatné číslo");
            return false;
        }
        return true;
    }

    static void DisplayMenuOptions()
    {
        //Výpis menu
        Console.WriteLine("Vyber si operaci a dej enter");
        Console.WriteLine("Sčítání - 1");
        Console.WriteLine("Odečítání - 2");
        Console.WriteLine("Násobení - 3");
        Console.WriteLine("Dělení - 4");
    }

    static float GetNumber(string numberOrder)
    {
        string textInput;
        float parsedNumber;
        Console.WriteLine($"Napiš {numberOrder} číslo a dej enter");
        textInput = Console.ReadLine();
        parsedNumber = float.Parse(textInput);
        return parsedNumber;
    }

    static void WelcomeScreen()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        for (int i = 0; i < 50; i++)
        {
            Console.Write("=");
            if (i == 24)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" KALKULAČKA ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
