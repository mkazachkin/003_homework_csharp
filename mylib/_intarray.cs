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
        int siz = Input.IntNum("Задайте размер массива");
        int min = Input.IntNum("Задайте минимальное число в массиве");
        int max = Input.IntNum("Задайте максимальное число в массиве");
        return IntArray.Make(siz, min, max);
    }
    public static int CountEven(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает количество четных чисел в массиве.
        int count = 0;
        foreach (int el in array) if (el % 2 == 0) count++;
        return count;
    }
    public static int SumEven(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму четных чисел в массиве.
        int sum = 0;
        foreach (int el in array) if (el % 2 == 0) sum += el;
        return sum;
    }
    public static int SumEvenIndexes(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму чисел на четных местах в массиве.
        int sum = 0;
        for (int i = 0; i < array.Length; i += 2) sum += array[i];
        return sum;
    }
    public static int CountOdd(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает количество нечетных чисел в массиве.
        int count = 0;
        foreach (int el in array) if (el % 2 != 0) count++;
        return count;
    }
    public static int SumOdd(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму нечетных чисел в массиве.
        int sum = 0;
        foreach (int el in array) if (el % 2 != 0) sum += el;
        return sum;
    }
    public static int SumOddIndexes(int[] array)
    {
        //Принимает массив целых чисел.
        //Возвращает сумму чисел на нечетных местах в массиве.
        int sum = 0;
        for (int i = 1; i < array.Length; i += 2) sum += array[i];
        return sum;
    }
    public static void Print(int[] array, int cellSize = 4)
    {
        //Плолучает массив целых чисел и выводит его в консоль
        string str = "";
        for (int i = 0; i < array.Length; i++)
        {
            str += $" {array[i]}".PadLeft(cellSize);
        }
        Console.WriteLine(str);
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