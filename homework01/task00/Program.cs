//   Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.
//    a = 5; b = 7 -> max = 7
//    a = 2 b = 10 -> max = 10
//    a = -9 b = -3 -> max = -3

using Geekbrains;


double firstNumber = Input.DoubleNum("Введите первое число");
double secondNumber = Input.DoubleNum("Введите второе число");

if (firstNumber > secondNumber)
{
    Console.WriteLine("Максимальное число из введенных - " + firstNumber);
}
else
{
    Console.WriteLine("Максимальное число из введенных - " + secondNumber);

}