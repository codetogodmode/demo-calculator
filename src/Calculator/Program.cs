namespace Calculator;

enum Operation
{
    Add, //0
    Substract, //1
    Multiply, //2
    Divide //3
}

class Program
{
    static void Main(string[] args)
    {
        //Deklarace proměnných
        string textInput;
        int choiceNumber;
        Operation choice;

        float firstNumber;
        float secondNumber;
        float result = 0F;

        //Výpis menu
        Console.WriteLine("Vyber si operaci a dej enter");
        Console.WriteLine("Sčítání - 1");
        Console.WriteLine("Odečítání - 2");
        Console.WriteLine("Násobení - 3");
        Console.WriteLine("Dělení - 4");

        //Vyčtení vybrané operace
        textInput = Console.ReadLine();
        choiceNumber = int.Parse(textInput);

        //Kontrola vstupu
        if (choiceNumber < 1 || choiceNumber > 4)
        {
            Console.WriteLine("Napsal jsi špatné číslo");
            return;
        }
        choice = (Operation)(choiceNumber - 1);

        Console.WriteLine("Napiš první číslo a dej enter");
        textInput = Console.ReadLine();
        firstNumber = float.Parse(textInput);
        Console.WriteLine("Napiš druhé číslo a dej enter");
        textInput = Console.ReadLine();
        secondNumber = float.Parse(textInput);

        //Výpis operace
        Console.WriteLine($"Vybral sis operaci {choice} | První číslo: {firstNumber} | Druhé číslo: {secondNumber}");

        if (choice == Operation.Add)
        {
            result = firstNumber + secondNumber;
        }
        else if (choice == Operation.Substract)
        {
            result = firstNumber - secondNumber;
        }
        else if (choice == Operation.Multiply)
        {
            result = firstNumber * secondNumber;
        }
        else if (choice == Operation.Divide)
        {
            if (secondNumber != 0)
            {
                result = firstNumber / secondNumber;
            }
            else
            {
                Console.WriteLine("Nulou se nedá dělit");
            }
        }
        else
        {
            result = 0F;
            Console.WriteLine("Zadal jsi špatnou operaci");
        }

        Console.WriteLine($"Výsledek: {result}");
    }
}
