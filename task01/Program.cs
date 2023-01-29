//Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
//2, 3, 7 -> 7
//44 5 78 -> 78
//22 3 9 -> 22

Console.Clear();                                            //Let's clear terminal to make it look better
Console.Write("Введите первое число: ");                    //Asking user for enter any number
double firstNumber = double.Parse(Console.ReadLine()!)!;    //User may type any number, so we use double
                                                            //as data type. Null values don't accepted
double maxNumber = firstNumber;                             //Maximum for now is the first number

Console.Write("Введите второе число: ");                    //Let's enter the second number
double secondNumber = double.Parse(Console.ReadLine()!)!;
if (secondNumber > maxNumber) maxNumber = secondNumber;     //Let's check for maximux

Console.Write("Введите третье число: ");                    //Let's enter the third number
double thirdNumber = double.Parse(Console.ReadLine()!)!;
if (thirdNumber > maxNumber) maxNumber = thirdNumber;       //Let's check for maximux

Console.WriteLine("Максимальное число из введенных " + maxNumber);    //We inform the user about maximum