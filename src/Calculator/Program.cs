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

        //Deklarace proměnných
        bool running = true;
        string textInput;
        int choiceNumber;
        Operation choice;

        float firstNumber;
        float secondNumber;
        float result = 0F;

        while (running)
        {
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
                Console.WriteLine($"Proběhla multiplikace uvnitř else if, výsledek: {result}");
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

            Console.WriteLine("Chceš další výpočet? (y)");
            textInput = Console.ReadLine();
            textInput = textInput.ToLower();
            Console.WriteLine();
            if (textInput != "y")
            {
                Console.WriteLine($"Uživatel zadal {textInput}, Kalkulačka ukončena");
                running = false;
            }
        }
    }
}
