// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки
// с наименьшей суммой элементов: 1 строка

using Geekbrains;

double[,] array = Double2DArray.MakeCustom();
Double2DArray.Print(array);
double sum = Double2DArray.SumRow(array, 0);
double tmp;
int minRow = 0;
Console.WriteLine($"Сумма ряда 0 составляет {sum}.");
for (int i = 1; i < array.GetLength(0); i++)
{
    tmp = Double2DArray.SumRow(array, i);
    Console.WriteLine($"Сумма ряда {i} составляет {tmp}.");
    if (tmp < sum)
    {
        sum = tmp;
        minRow = i;
    }
}
Console.WriteLine($"Наименьшая сумма элементов матрицы в ряду {minRow}");