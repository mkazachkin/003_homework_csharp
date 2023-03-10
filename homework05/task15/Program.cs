//Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
//[3 7 22 2 78] -> 76

using Geekbrains;

string format = " {0:F2}";                   //Формат вывода чисел типа double
Console.Clear();

double[] arr = DoubleArray.MakeCustom();    //Задаем массив случайных чисел
DoubleArray.Print(arr, 9, format);
double dif = DoubleArray.Max(arr) - DoubleArray.Min(arr);
Console.WriteLine($"Разница между максимумом и минимумом в массиве равна {string.Format(format, dif)}.");