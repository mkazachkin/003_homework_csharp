namespace Geekbrains;
public class IntArray
{
    public static int[] Make(int size, int min, int max)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа int с указанными параметрами.
        if (size < 1) size = 1;
        if (max < min) { int tmp = max; max = min; min = tmp; }
        int[] resArray = new int[size];
        for (int i = 0; i < size; i++) resArray[i] = new Random().Next(min, max + 1);
        return resArray;
    }
    public static int[] MakeCustom()
    {
        //Запрашивает пользователя о параметрах массива и возвращает массив с этими параметрами
        int siz = IntNumber.Input("Задайте размер массива");
        int min = IntNumber.Input("Задайте минимальное число в массиве");
        int max = IntNumber.Input("Задайте максимальное число в массиве");
        return IntArray.Make(siz, min, max);
    }
    public static int CountEven(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает количество четных чисел в массиве.
        int count = 0;
        foreach (int el in someArray) if (el % 2 == 0) count++;
        return count;
    }
    public static int SumEven(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму четных чисел в массиве.
        int sum = 0;
        foreach (int el in someArray) if (el % 2 == 0) sum += el;
        return sum;
    }
    public static int SumEvenIndexes(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму чисел на четных местах в массиве.
        int sum = 0;
        for (int i = 0; i < someArray.Length; i += 2) sum += someArray[i];
        return sum;
    }
    public static int CountOdd(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает количество нечетных чисел в массиве.
        int count = 0;
        foreach (int el in someArray) if (el % 2 != 0) count++;
        return count;
    }
    public static int SumOdd(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму нечетных чисел в массиве.
        int sum = 0;
        foreach (int el in someArray) if (el % 2 != 0) sum += el;
        return sum;
    }
    public static int SumOddIndexes(int[] someArray)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму чисел на нечетных местах в массиве.
        int sum = 0;
        for (int i = 1; i < someArray.Length; i += 2) sum += someArray[i];
        return sum;
    }
    public static void WriteLine(int[] array)
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
    public static int Max(int[] array)
    {
        //Возвращает максимальное значение в массиве
        int max = array[0];
        for (int i = 1; i < array.Length; i++) if (max < array[i]) max = array[i];
        return max;
    }
    public static int Min(int[] array)
    {
        //Возвращает минимальное значение в массиве
        int min = array[0];
        for (int i = 1; i < array.Length; i++) if (min > array[i]) min = array[i];
        return min;
    }
}