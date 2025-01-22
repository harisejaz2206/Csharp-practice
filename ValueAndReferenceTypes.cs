public class ValueAndReferenceTypes
{
    // Method to modify value using ref
    static void ModifyValue(ref int x)
    {
        x = 100;
        Console.WriteLine($"Inside ModifyValue method: x = {x}");
    }

    // Method using out parameters
    static void GetValues(out int x, out int y)
    {
        x = 10;
        y = 20;
    }

    public static void Solve()
    {
        Console.WriteLine("\n=== Value and Reference Types Demo ===\n");

        // Value Types
        Console.WriteLine("Value Types Demo:");
        int number = 42;
        DateTime date = DateTime.Now;
        bool flag = true;

        Console.WriteLine($"Number: {number}");
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Flag: {flag}");

        // Reference Types
        Console.WriteLine("\nReference Types Demo:");
        string text = "Hello";
        object obj = new object();
        List<int> numbers = new List<int> { 1, 2, 3 };

        Console.WriteLine($"Text: {text}");
        Console.WriteLine($"Object: {obj}");
        Console.WriteLine($"List numbers: {string.Join(", ", numbers)}");

        // Demonstrating ref parameter
        Console.WriteLine("\nRef Parameter Demo:");
        int x = 5;
        Console.WriteLine($"Before ModifyValue: x = {x}");
        ModifyValue(ref x);
        Console.WriteLine($"After ModifyValue: x = {x}");

        // Demonstrating out parameter
        Console.WriteLine("\nOut Parameter Demo:");
        int a, b;
        GetValues(out a, out b);
        Console.WriteLine($"Values from GetValues: a = {a}, b = {b}");
    }
} 