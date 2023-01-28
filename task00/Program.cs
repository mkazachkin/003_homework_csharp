//   Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.
//    a = 5; b = 7 -> max = 7
//    a = 2 b = 10 -> max = 10
//    a = -9 b = -3 -> max = -3

Console.Clear();                                            //Let's clear terminal to make look better
Console.Write("Введите первое число: ");                    //Ask user for enter any number
double firstNumber = double.Parse(Console.ReadLine()!)!;    //User may type any number, so we use double
                                                            //as data type. Null values don't accepted
Console.Write("Введите второе число: ");                    //We repeat the similar operations for second number
double secondNumber = double.Parse(Console.ReadLine()!)!;

if (firstNumber > secondNumber)
{
    Console.WriteLine("Максимальное число из введенных " + firstNumber);    //We inform the user about which number
}                                                                           //is greater 
else
{
    Console.WriteLine("Максимальное число из введенных " + secondNumber);

}