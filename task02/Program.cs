// Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).
// 4->да
// - 3->нет
// 7->нет

Console.Clear();                                            //Let's clear terminal to make it look better
Console.Write("Введите число: ");                           //Asking user for enter any number
double firstNumber = double.Parse(Console.ReadLine()!)!;    //User may type any number, so we use double

if ((firstNumber % 2) != 0)
{
    Console.WriteLine("Введенное число нечетное.");         //Number is odd 
}
else
{
    Console.WriteLine("Введенное число четное.");           //Number is even
}