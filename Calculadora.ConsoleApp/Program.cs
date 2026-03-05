string[] options = ["+", "-", "×", "÷", "×T"];
decimal? num1 = null;
decimal? num2 = null;
int? select = null;
decimal? result = null;
List<string> history = [];
while (true)
{
    WriteTitle();
    WriteProgress(num1, num2, select, result);
    num1 = GetNumber();
    select = Select();
    if (select == 4)
    {
        history.Add(TimesTable(num1));
        if (!Continue()) return;
        else
        {
            num1 = null;
            num2 = null;
            select = null;
            result = null;
            continue;
        }
    }
    else
    {
        num2 = GetNumber();
        result = Calculate(num1, num2, select);
        WriteTitle();
        history.Add(WriteProgress(num1, num2, select, result));
    }
    if (!Continue()) return;
    else
    {
        num1 = null;
        num2 = null;
        select = null;
        result = null;
    }
}
bool Continue()
{
    Console.WriteLine("Pressione ENTER para uma nova operação, H para ver o histórico ou ESC para sair...");
    while (true)
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.H: ShowHistory(); break;
            case ConsoleKey.Enter: return true;
            case ConsoleKey.Escape: return false;
            default: break;
        }
    }
}
void WriteTitle()
{
    string title = "Calculadora 2026";
    int MenuWidth = title.Length + 2;
    int padding = (MenuWidth - title.Length) / 2;
    Console.Clear();
    Console.WriteLine("┌" + new string('─', MenuWidth) + "┐");
    Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(MenuWidth) + "│");
    Console.WriteLine("└" + new string('─', MenuWidth) + "┘");
}
string WriteProgress(decimal? n1, decimal? n2, int? sel, decimal? res)
{
    string w1 = n1 == null ? "_" : $"{n1}";
    string ws = sel == null ? "_" : $"{options[sel.Value]}";
    string w2 = n2 == null ? "_" : $"{n2}";
    string wr = res == null ? "_" : $"{(res == decimal.MaxValue ? "Indefinido" : res)}";
    Console.WriteLine($"{w1} {ws} {w2} = {wr}");
    return $"{w1} {ws} {w2} = {wr}";
}
int Select()
{
    int selectedIndex = 0;
    ConsoleKey key;

    while (true)
    {
        WriteTitle();
        WriteProgress(num1, num2, select, result);
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex) Console.WriteLine($"> {options[i]}");
            else Console.WriteLine($"  {options[i]}");
        }
        Console.WriteLine("Selecione a operação desejada com as setas e pressione ENTER...");
        key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow: selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1; break;

            case ConsoleKey.DownArrow: selectedIndex = (selectedIndex + 1) % options.Length; break;

            case ConsoleKey.Enter: return selectedIndex;
        }
    }
}
decimal GetNumber()
{
    decimal num;
    WriteTitle();
    WriteProgress(num1, num2, select, result);
    Console.Write("Digite um número: ");
    while (!decimal.TryParse(Console.ReadLine(), out num))
    {
        WriteTitle();
        WriteProgress(num1, num2, select, result);
        Console.Write("Valor inválido. Tente Novamente: ");
    }
    return num;
}
decimal? Calculate(decimal? n1, decimal? n2, int? operation)
{
    switch (operation)
    {
        case 0: return n1 + n2;
        case 1: return n1 - n2;
        case 2: return n1 * n2;
        case 3:
            if (n2 == 0) return decimal.MaxValue;
            else return n1 / n2;
        default: return null;
    }
}
string TimesTable(decimal? n1)
{
    WriteTitle();
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"{n1} × {i} = {Calculate(n1, i, 2)}");
    }
    return $"Calculado tabuada do {n1}";
}
void ShowHistory()
{
    WriteTitle();
    System.Console.WriteLine("Histórico:");
    foreach (string s in history)
    {
        Console.WriteLine(s);
    }
    Console.WriteLine("Pressione ENTER para uma nova operação, H para ver o histórico ou ESC para sair...");
}