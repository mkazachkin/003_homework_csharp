//Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
//2, 3, 7 -> 7
//44 5 78 -> 78
//22 3 9 -> 22

using Geekbrains;

Console.Clear();
double firstNumber = Input.DoubleNum("Введите первое число");
double maxNumber = firstNumber;

double secondNumber = Input.DoubleNum("Введите второе число");
if (secondNumber > maxNumber) maxNumber = secondNumber;

double thirdNumber = Input.DoubleNum("Введите третье число");
if (thirdNumber > maxNumber) maxNumber = thirdNumber;

Console.WriteLine("Максимальное число из введенных " + maxNumber);