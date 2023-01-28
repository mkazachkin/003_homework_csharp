//    Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
//    5 -> 2, 4
//    8 -> 2, 4, 6, 8

Console.Clear();                                            //Let's clear terminal to make look better
Console.Write("Введите число: ");                           //Asking user for enter any number
double firstNumber = double.Parse(Console.ReadLine()!)!;    //User may type any number, so we use double
if (firstNumber < 2)                                        //If number below 2 no need to work
{
    Console.WriteLine("Четных чисел от 1 до " + firstNumber + " не существует. Печально.");
}
else
{
    int counter = 2;                                        //The first even number from 1 is 2
                                                            //So, the counter strarts from 2
    Console.Write("Список четных чисел от 1 до " + firstNumber + ": ");
    while (counter < (firstNumber - 1))                     //We need to print last even number outside 
    {                                                       //the cycle, so no need to count from 2 to
                                                            //(number - 1).
        Console.Write(counter + ", ");                      //We print all even numbers, exept the last one
        counter += 2;
    }
    Console.WriteLine(counter + ".");                       //We print the last even number and finish the output.
}