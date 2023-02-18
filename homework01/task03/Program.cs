//    Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
//    5 -> 2, 4
//    8 -> 2, 4, 6, 8
using Geekbrains;
int counter;
double num;
Console.Clear();
num = Input.DoubleNum("Введите число");
if (num < 2)
{
    Console.WriteLine($"Четных чисел от 1 до {num} не существует. Печально.");
}
else
{
    counter = 2;
    Console.Write($"Список четных чисел от 1 до {num}: ");
    while (counter < (num - 1))
    {
        Console.Write(counter + ", ");
        counter += 2;
    }
    Console.WriteLine(counter + ".");
}