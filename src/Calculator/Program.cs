namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        // Prázdný řádek nahoře
        Console.WriteLine();

        // Horní oddělovač — tyrkysová
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Console.WriteLine();

        // Hlavní titulek — žlutá
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("          MARTIN'S CALCULATOR");

        // Podtitul — zelená
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("             CTGM Academy");

        // Verze — tmavě šedá
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("                 v1.0");
        Console.WriteLine();

        // Dolní oddělovač — tyrkysová
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine("2 + 2 = 4 ");
        Console.WriteLine();
        Console.ResetColor();

        // Prompt pro ukončení — tmavě šedá
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Stiskni libovolnou klávesu pro ukončení...");
        Console.ResetColor();

        // Pauza — aby se aplikace nezavřela okamžitě
        Console.ReadKey();
    }
}
