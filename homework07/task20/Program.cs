//Задача 52. Задайте двумерный массив из целых чисел.
//Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

using Geekbrains;

int row = 4;
int col = 3;
double min = -1000;
double max = 1000;
string format = " {0:F0}";
int cellSize = 9;

Console.Clear();

double[,] array = Double2DArray.Make(row, col, min, max);
Double2DArray.Print(array, cellSize, format, ConsoleColor.White, ConsoleColor.Yellow);

//Не стал оформлять отдельным методом, т. к. работаем с массивом вещественных чисел,
//а по условию задачи должны быть целые. Так что работаем с целыми, но округляя на строчке 32.
double[] mid = new double[col];
for (int i = 0; i < col; i++)
{
    mid[i] = 0;
    for (int j = 0; j < row; j++)
    {
        //В условиях задачи работаем с целыми числами, так что округлим при расчетах
        mid[i] += Math.Round(array[j, i], 0) / row;
    }
}
Console.WriteLine();
Console.Write("  "); //Выравняем десятичную часть
DoubleArray.Print(mid, cellSize, " {0:F1}");