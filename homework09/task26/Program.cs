// Задайте значение N. Напишите программу, которая выведет все натуральные
// числа в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
using System;

Console.Clear();
Console.Write("Введите N: ");
int n = int.Parse(Console.ReadLine()!)!;
PrintNaturalDesc(n);                    //Вывод всех натуральных чисел
//PrintNaturalDesc(n, false, true);     //Раскомментировать вывод только для четных
//PrintNaturalDesc(n, true);            //Раскомментировать вывод только для нечетных

void PrintNaturalDesc(int n, bool onlyOdd = false, bool onlyEven = false)
{
    if ((n == 1) || ((n == 2) && onlyEven))
        Console.WriteLine($"{n}.");
    else
    {
        if ((IsEven(n) && !onlyOdd) || (!IsEven(n) && !onlyEven))
            Console.Write($"{n}, ");
        PrintNaturalDesc(n - 1, onlyOdd, onlyEven);
    }
}

bool IsEven(int value)
{
    return value % 2 == 0;
}