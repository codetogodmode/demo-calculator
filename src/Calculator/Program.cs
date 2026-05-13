using System.Security.Cryptography.X509Certificates;

namespace Calculator;

enum Operation
{
    Add,
    Substract,
    Multiply,
    Divide,
    Invalid
}

enum UserChoice
{
    Calculate,
    DisplayHistory,
    EndApplication,
    Invalid

}

class Program
{
    static void Main(string[] args)
    {
        //Deklarace proměnných
        string textInput;
        UserChoice choice;
        List<string> history = new List<string>();
        Dictionary<string, Operation> operationsBySymbol = GetOperationsBySymbolsDictionary();
        string[] expression;
        Operation selectedOperation;

        float firstNumber;
        float secondNumber;
        float result;

        WelcomeScreen();

        while (true)
        {
            choice = Menu();

            if (choice == UserChoice.Calculate)
            {

                expression = GetExpression();
                if (!operationsBySymbol.ContainsKey(expression[1]))
                {
                    Console.WriteLine("Zadal jsi nevalidní symbol");
                    continue;
                }
                selectedOperation = operationsBySymbol[expression[1]];
                try
                {
                    firstNumber = float.Parse(expression[0]);
                    secondNumber = float.Parse(expression[2]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Chyba: to není číslo, zkus to znovu");
                    continue;
                }
                catch
                {
                    Console.WriteLine("Něco se nepovedlo");
                    continue;
                }
                Console.WriteLine($"Vybral sis operaci {selectedOperation} | První číslo: {firstNumber} | Druhé číslo: {secondNumber}");
                result = Calculate(selectedOperation, firstNumber, secondNumber);
                Console.WriteLine($"Výsledek: {result}");
                SaveToHistory(history, firstNumber, secondNumber, selectedOperation, result);
            }
            else if (choice == UserChoice.DisplayHistory)
            {
                DisplayHistory(history);
                continue;
            }
            else if (choice == UserChoice.EndApplication)
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }

    static string[] GetExpression()
    {
        Console.WriteLine("Napiš příklad");
        string input = Console.ReadLine();
        return input.Split(" ");
    }

    static Dictionary<string, Operation> GetOperationsBySymbolsDictionary()
    {
        Dictionary<string, Operation> operationsBySymbol = new Dictionary<string, Operation>();
        operationsBySymbol.Add("+", Operation.Add);
        operationsBySymbol.Add("-", Operation.Substract);
        operationsBySymbol.Add("*", Operation.Multiply);
        operationsBySymbol.Add("/", Operation.Divide);
        return operationsBySymbol;
    }

    static List<string> SaveToHistory(List<string> history, float firstNumber, float secondNumber, Operation usedOperation, float result)
    {
        string record = $"První číslo: {firstNumber} | Druhé číslo: {secondNumber} | Operace: {usedOperation} | Výsledek: {result}";
        history.Add(record);
        return history;
    }

    static void DisplayHistory(List<string> history)
    {
        Console.WriteLine($"V historii je aktuálně {history.Count()} záznamů");
        foreach (string record in history)
        {
            Console.WriteLine(record);
        }
    }

    static UserChoice Menu()
    {
        string textInput;
        int choiceNumber;
        UserChoice choice;
        bool isValidInput;

        DisplayMenuOptions();
        //Vyčtení vybrané operace
        textInput = Console.ReadLine();
        try
        {
            choiceNumber = int.Parse(textInput);

            isValidInput = IsUserChoiceInputValid(choiceNumber);
            if (!isValidInput)
            {
                return UserChoice.Invalid;
            }
            choice = (UserChoice)(choiceNumber - 1);
        }
        catch
        {
            Console.WriteLine("Nezadal jsi číšlo");
            choice = UserChoice.Invalid;
        }
        
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

    static bool IsUserChoiceInputValid(int operationNumberToCheck)
    {
        //Kontrola vstupu
        if (operationNumberToCheck < 1 || operationNumberToCheck > 3)
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
        Console.WriteLine("Počítat - 1");
        Console.WriteLine("Zobrazit historii - 2");
        Console.WriteLine("Ukončit aplikaci - 3");
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
