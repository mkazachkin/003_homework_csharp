// Напишите программу вычисления функции Аккермана с помощью рекурсии.
// Даны два неотрицательных числа m и n.
// m = 2, n = 3->A(m, n) = 9
// m = 3, n = 2->A(m, n) = 29
using System;

Console.Clear();
Console.Write("Введите параметр m функции Аккермана A(m, n): ");
int m = int.Parse(Console.ReadLine()!)!;
Console.Write("Введите параметр n функции Аккермана A(m, n): ");
int n = int.Parse(Console.ReadLine()!)!;

Console.WriteLine("Результат вычислений функции Аккермана " +
    $"A(m, n) для m = {m} и n = {n} составляет {AckermannFunction(m, n)}.");

int AckermannFunction(int m, int n)
{
    if (m == 0)
        return n + 1;
    else if ((n == 0) && (m > 0))
        return AckermannFunction(m - 1, 1);
    else
        return AckermannFunction(m - 1, AckermannFunction(m, n - 1));
}