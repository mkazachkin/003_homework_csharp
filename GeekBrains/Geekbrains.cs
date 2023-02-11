public class Geekbrains
{
    public static int[] ArrayIntMake(int size, int min, int max)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа int с указанными параметрами.
        int[] resArray = new int[size];
        for (int i = 0; i < size; i++) resArray[i] = new Random().Next(min, max + 1);
        return resArray;
    }
    public static int ArrayIntCountEven(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает количество четных чисел в массиве.
        int i = 0;
        foreach (int el in someArray) if (el % 2 == 0) i++;
        return i;
    }
    public static int ArrayIntCountOdd(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает количество четных чисел в массиве.
        int i = 0;
        foreach (int el in someArray) if (el % 2 == 0) i++;
        return i;
    }
    public static void ArrayIntPrint(int[] array)
    {
        //Плолучает массив целых чисел и выводит его в консоль в виде [x1, x2..]
        Console.Write("[");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != (array.Length - 1)) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
    public static int InputInt(string message)
    {
        //Принимает текст приглашения на ввод числа типа int
        //Возвращает число типа int, введенное пользователем.
        string someString;
        int someIntNumber;
        do
        {
            Console.Write($"{message}: ");
            someString = Console.ReadLine()!;
        } while (!int.TryParse(someString, out someIntNumber));
        return someIntNumber;
    }
}