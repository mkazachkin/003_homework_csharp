//Задача 25: Напишите цикл, который принимает на вход два числа (A и B)
//и возводит число A в натуральную степень B.
//3, 5 -> 243 (3⁵)
//2, 4 -> 16

Console.Clear();
int x, y;

x = NumberInput("Введите число");
y = NumberInput("Введите степень числа");
Console.WriteLine($"{x}{MakeUpperCase(y)}={NaturalPow(x, y)}");

int NumberInput(string message)
{
    string someString;
    int someIntNumber;
    do
    {
        Console.Write($"{message}: ");
        someString = Console.ReadLine()!;
    } while (!int.TryParse(someString, out someIntNumber));
    return someIntNumber;
}
int NaturalPow(int x, int y)
{
    int result = x;
    for (int i = 2; i <= y; i++) result = result * x;
    return result;
}
string MakeUpperCase(int someNumber)
{
    string resultString = Convert.ToString(someNumber);
    string[] powString = new string[10] { "⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹" };
    if (Console.OutputEncoding.CodePage == 65001)
    {
        for (int i = 0; i <= 9; i++) resultString = resultString.Replace(Convert.ToString(i), powString[i]);
        resultString.Replace("-", "⁻");
    }
    else
    {
        resultString = "^" + resultString;
    }
    return resultString;
}