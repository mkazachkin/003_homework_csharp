// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

Console.Clear();
int userNum = NumberInput("Введите число");
Console.WriteLine($"Сумма цифр этого числа равна {SumDigits(Math.Abs(userNum))}");

int SumDigits(int someNumber)
{
    int result = 0;
    int tempNumber;
    while (someNumber > 0)
    {
        result += someNumber % 10;
        someNumber /= 10;
    }
    return result;
}
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