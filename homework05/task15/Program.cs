//Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
//[3 7 22 2 78] -> 76

using Geekbrains;

string format = "{0:F2}";
Console.Clear();


//Задаем массив случайных чисел
double[] arr = DoubleArray.MakeCustom();
DoubleArray.WriteLine(arr, format);
//Считаем разницу между мминимальным и максимальным значением в массиве
double dif = DoubleArray.Max(arr) - DoubleArray.Min(arr);
//Console.WriteLine($"Разница между минимумом и максимумом в массиве равна {dif}.");
Console.WriteLine(string.Format(format, dif));