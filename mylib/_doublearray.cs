namespace Geekbrains;
public class DoubleArray
{
    public static double[] Make(int size, double min, double max)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа double с указанными параметрами.
        if (size < 1)
        {
            size = 1;
        }
        if (max < min)
        {
            double tmp = max; max = min; min = tmp;
        }
        double[] array = new double[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = new Random().NextDouble() * (max - min) + min;
        }
        return array;
    }
    public static double[] MakeCustom()
    {
        //Запрашивает пользователя о параметрах массива и возвращает массив с этими параметрами
        int siz = Input.IntNum("Задайте размер массива");
        double min = Input.DoubleNum("Задайте минимальное число в массиве");
        double max = Input.DoubleNum("Задайте максимальное число в массиве");
        return DoubleArray.Make(siz, min, max);
    }
    public static double SumEvenIndexes(double[] array)
    {
        //Принимает массив чисел.
        //Возвращает сумму чисел на четных местах в массиве.
        double sum = 0;
        for (int i = 0; i < array.Length; i += 2) sum += array[i];
        return sum;
    }
    public static int SumOddIndexes(int[] array)
    {
        //Принимает массив чисел.
        //Возвращает сумму чисел на нечетных местах в массиве.
        int sum = 0;
        for (int i = 1; i < array.Length; i += 2) sum += array[i];
        return sum;
    }
    public static void Print(double[] array, int cellSize = 12, string format = "{0:F8}")
    {
        //Плолучает массив чисел и выводит его в консоль в опционально указываемом формате
        string str = "";
        for (int i = 0; i < array.Length; i++)
        {
            str += string.Format(format, array[i]).PadLeft(cellSize);
        }
        Console.WriteLine(str);
    }
    public static double Max(double[] array)
    {
        //Возвращает максимальное значение в массиве
        double max = array[0];
        for (int i = 1; i < array.Length; i++) if (max < array[i]) max = array[i];
        return max;
    }
    public static double Min(double[] array)
    {
        //Возвращает минимальное значение в массиве
        double min = array[0];
        for (int i = 1; i < array.Length; i++) if (min > array[i]) min = array[i];
        return min;
    }
    public static int LessOrEqual(double[] array, double boundaryNum = 0, bool boundaryEqual = true)
    {
        int count = 0;
        if (boundaryEqual)
        {
            for (int i = 0; i < array.Length; i++) if (array[i] <= boundaryNum) count++;
        }
        else
        {
            for (int i = 0; i < array.Length; i++) if (array[i] < boundaryNum) count++;
        }
        return count;
    }
}
