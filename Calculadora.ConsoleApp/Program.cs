string[] options = ["+", "-", "×", "÷"];
decimal? num1 = null;
decimal? num2 = null;
int? select = null;
decimal? result = null;
while (true)
{
    if (num1 == null && select == null && num2 == null)
    {
        WriteThing(num1, select, num2, result);
        Console.Write("Digite um número: ");
        num1 = decimal.Parse(Console.ReadLine());
        continue;
    }
    else if (num1 != null && select == null && num2 == null)
    {
        select = ShowSelect();
        continue;
    }
    else if (num1 != null && select != null && num2 == null)
    {
        WriteThing(num1, select, num2, result);
        Console.Write("Digite um número: ");
        num2 = decimal.Parse(Console.ReadLine());
        continue;
    }
    else
    {
        switch (select)
        {
            case 0: result = num1.Value + num2.Value; break;
            case 1: result = num1.Value - num2.Value; break;
            case 2: result = num1.Value * num2.Value; break;
            case 3: result = num1.Value / num2.Value; break;
        }
        WriteThing(num1, select, num2, result);
        Console.WriteLine("Aperte ENTER para continuar ou ESC para sair...");
        bool thing = true;
        while (thing)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    num1 = null;
                    num2 = null;
                    select = null;
                    result = null;
                    thing = false;
                    break;
                case ConsoleKey.Escape: return;
                default: continue;
            }
        }

    }
}
void WriteThing(decimal? n1, int? sel, decimal? n2, decimal? res)
{
    string w1 = n1 == null ? "__" : $"{n1}";
    string ws = sel == null ? "__" : $"{options[sel.Value]}";
    string w2 = n2 == null ? "__" : $"{n2}";
    string wr = res == null ? "__" : $"{res}";
    Console.Clear();
    Console.WriteLine("Calculadora 2026");
    Console.WriteLine($"{w1} {ws} {w2} = {wr}");
}
int ShowSelect()
{
    int indexSelected = 0;
    ConsoleKey key;

    while (true)
    {
        WriteThing(num1, select, num2, result);
        for (int i = 0; i < options.Length; i++)
        {
            if (i == indexSelected)
                Console.WriteLine($"> {options[i]}");

            else
                Console.WriteLine($"  {options[i]}");
        }
        Console.WriteLine("Selecione com as setas e presione enter...");
        
        key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow: indexSelected = (indexSelected == 0) ? options.Length - 1 : indexSelected - 1; break;

            case ConsoleKey.DownArrow: indexSelected = (indexSelected + 1) % options.Length; break;

            case ConsoleKey.Enter: return indexSelected;
        }
    }
}