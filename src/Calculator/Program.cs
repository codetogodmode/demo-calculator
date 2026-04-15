namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        string textoveCislo;
        float prvniCislo = 5;
        float druheCislo = 50;
        float vysledek = 100;

        Console.WriteLine("Řekni mi první číslo a Enter");
        textoveCislo = Console.ReadLine();
        prvniCislo = float.Parse(textoveCislo);
        Console.WriteLine("Řekni mi druhé číslo a Enter");
        textoveCislo = Console.ReadLine();
        druheCislo = float.Parse(textoveCislo);
        vysledek = prvniCislo + druheCislo;
        Console.WriteLine($"První číslo: {prvniCislo} | Druhé číslo: {druheCislo} | Výsledek součtu: {vysledek}");
        Console.WriteLine();
        Console.ReadKey();
    }
}
