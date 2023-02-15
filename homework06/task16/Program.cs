//Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
//0, 7, 8, -2, -2 -> 2
//1, -7, 567, 89, 223-> 3

using System;
using Geekbrains;
double[] array;

Console.Clear();
array = Input.DoubeNumsString("Введите несколько чисел через пробел", " ");
Console.Write("Количество введенных чисел больше нуля равно: ");
Console.WriteLine(array.Length - DoubleArray.LessOrEqual(array, 0, true));