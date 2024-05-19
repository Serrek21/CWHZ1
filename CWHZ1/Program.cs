using System;

// Делегаціх
public delegate void MessageDelegate(string m);
public delegate int MathDelegate(int x, int y);
public delegate bool PredicateDelegate(int n);

public class MessageApp
{
    public void DisplayMessage(string m)
    {
        Console.WriteLine($"Повідомлення: {m}");
    }
}

public class MathApp
{
    public int Dod(int x, int y)
    {
        return x + y;
    }

    public int Vid(int x, int y)
    {
        return x - y;
    }

    public int Mno(int x, int y)
    {
        return x * y;
    }
}

public class Number
{
    public bool Par(int n)
    {
        return n % 2 == 0;
    }

    public bool Nepar(int n)
    {
        return n % 2 != 0;
    }

    public bool Proste(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        int sqrt = (int)Math.Sqrt(n);
        for (int i = 3; i <= sqrt; i += 2)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool Fibo(int n)
    {
        return Square(5 * n * n + 4) || Square(5 * n * n - 4);
    }

    private bool Square(int x)
    {
        int sqrt = (int)Math.Sqrt(x);
        return sqrt * sqrt == x;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Зав 1
        MessageApp mApp = new MessageApp();
        MessageDelegate messageDelegate = new MessageDelegate(mApp.DisplayMessage);

        messageDelegate("Maks lox");

        // Зав 2 
        MathApp MaApp = new MathApp();
        MathDelegate DodDelegate = new MathDelegate(MaApp.Dod);
        MathDelegate VidDelegate = new MathDelegate(MaApp.Vid);
        MathDelegate MnoDelegate = new MathDelegate(MaApp.Mno);

        Console.WriteLine($"Сума: {DodDelegate(10, 5)}");
        Console.WriteLine($"Різниця: {VidDelegate(10, 5)}");
        Console.WriteLine($"Добуток: {MnoDelegate(10, 5)}");

        // Зав 3
        Number number = new Number();
        Predicate<int> ParPre = new Predicate<int>(number.Par);
        Predicate<int> NeparPre = new Predicate<int>(number.Nepar);
        Predicate<int> ProstePre = new Predicate<int>(number.Proste);
        Predicate<int> fiboPre = new Predicate<int>(number.Fibo);

        Console.WriteLine($"Число 6 парне: {ParPre(6)}");
        Console.WriteLine($"Число 7 непарне: {NeparPre(7)}");
        Console.WriteLine($"Число 11 просте: {ProstePre(11)}");
        Console.WriteLine($"Число 5 - число Фібоначчі: {fiboPre(5)}");
    }
}