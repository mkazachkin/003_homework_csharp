//Напишите программу, которая найдёт точку пересечения двух прямых,
//заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
//значения b1, k1, b2 и k2 задаются пользователем.
//b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

using System;
using Geekbrains;

Console.Clear();
Console.WriteLine("Две прямые заданы уровнением вида уравнениями y = k1 * x + b1, y = k2 * x + b2;");
double k1 = Input.DoubleNum("Введите k1");
double b1 = Input.DoubleNum("Введите b1");
double k2 = Input.DoubleNum("Введите k2");
double b2 = Input.DoubleNum("Введите b2");

double x = (b2 - b1) / (k1 - k2);
double y = k1 * x + b1;

Console.WriteLine($"Точка пересечения двух прямых имеет координаты {x} и {y}");

