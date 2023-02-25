// Задайте значения M и N. Напишите программу, которая найдёт
// сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30
using System;

Console.Clear();
Console.Write("Введите начальное число: ");
int m = int.Parse(Console.ReadLine()!)!;
Console.Write("Введите конечное число: ");
int n = int.Parse(Console.ReadLine()!)!;
int sum = NaturalNumbersSum(m, n);
Console.WriteLine($"Сумма чисел от {m} до {n} равна {sum}");

int NaturalNumbersSum(int start, int end)
{
    if (start == end)
        return end;
    else
        return start + NaturalNumbersSum(start + 1, end);
}