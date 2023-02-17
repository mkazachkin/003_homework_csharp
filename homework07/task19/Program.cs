//Задача 50. Напишите программу, которая на вход принимает позиции элемента
//в двумерном массиве, и возвращает значение этого элемента или же указание,
//что такого элемента нет.

using Geekbrains;

int m = 6;
int n = 5;
double min = -1000;
double max = 1000;
string format = " {0:F2}";

Console.Clear();

double[,] array = Double2DArray.Make(m, n, min, max);
Double2DArray.Print(array, 9, format);
int col = Input.IntNum("Введите номер столбца (начиная с 1)");
int row = Input.IntNum("Введите номер строки (начиная с 1)");
double? value = Double2DArray.GetValue(array, row - 1, col - 1);
if (value != null)
{
    Console.WriteLine($"Значение в позиции {row}, {col} равно {string.Format(format, value)}.");
}
else
{
    Console.WriteLine("Такой позиции в массиве нет");
}