//Задайте одномерный массив, заполненный случайными числами.
//Найдите сумму элементов, стоящих на нечётных позициях.
//[3, 7, 23, 12] -> 19

using Geekbrains;

int[] arr;

Console.Clear();

//Задаем массив случайных чисел
arr = IntArray.MakeCustom();
IntArray.WriteLine(arr);
//Считаем сумму элементов на нечетных позициях
Console.WriteLine($"Сумма нечетных элементов массива равна {IntArray.SumOddIndexes(arr)}.");