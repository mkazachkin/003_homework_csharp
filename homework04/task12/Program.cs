//Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
//1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
//6, 1, 33 -> [6, 1, 33]

Console.Clear();

int len = NumberInput("Введите количество элементов массива");
int min = NumberInput("Введите минимально допустимое число в массиве");
int max = NumberInput("Введите максимально допустимое число в массиве");

PrintIntArray(GetRandomNumbersArray(len, min, max));

int NumberInput(string message)
{
    string someString;
    int someIntNumber;
    do
    {
        Console.Write($"{message}: ");
        someString = Console.ReadLine()!;
    } while (!int.TryParse(someString, out someIntNumber));
    return someIntNumber;
}
int[] GetRandomNumbersArray(int len, int min, int max)
{
    if (max < min)
    {
        int tmp = max;
        max = min;
        min = tmp;
    }
    int[] result = new int[len];
    for (int i = 0; i < len; i++) result[i] = new Random().Next(min, max + 1);
    return result;
}
void PrintIntArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if (i != (array.Length - 1)) Console.Write(", ");
    }
    Console.WriteLine("]");
}