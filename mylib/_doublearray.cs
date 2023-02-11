namespace Geekbrains;
public class DoubleArray
{
    public static double[] Make(int size, double min, double max)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа double с указанными параметрами.
        if (size < 1) size = 1;
        if (max < min) { double tmp = max; max = min; min = tmp; }
        double[] resArray = new double[size];
        for (int i = 0; i < size; i++) resArray[i] = new Random().NextDouble() * (max - min) + min;
        return resArray;
    }
    public static double[] MakeCustom()
    {
        //Запрашивает пользователя о параметрах массива и возвращает массив с этими параметрами
        int siz = IntNumber.Input("Задайте размер массива");
        double min = DoubleNumber.Input("Задайте минимальное число в массиве");
        double max = DoubleNumber.Input("Задайте максимальное число в массиве");
        return DoubleArray.Make(siz, min, max);
    }
    public static double SumEvenIndexes(double[] someArray)
    {
        //Принимает массив чисел.
        //Возвращает сумму чисел на четных местах в массиве.
        double sum = 0;
        for (int i = 0; i < someArray.Length; i += 2) sum += someArray[i];
        return sum;
    }
    public static int SumOddIndexes(int[] someArray)
    {
        //Принимает массив чисел.
        //Возвращает сумму чисел на нечетных местах в массиве.
        int sum = 0;
        for (int i = 1; i < someArray.Length; i += 2) sum += someArray[i];
        return sum;
    }
    public static void WriteLine(double[] array, string format = "{0:F8}")
    {
        //Плолучает массив чисел и выводит его в консоль в виде [x1; x2..] в опционально указываемом формате
        Console.Write("[");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(string.Format(format, array[i]));
            if (i != (array.Length - 1)) Console.Write("; ");
        }
        Console.WriteLine("]");
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
}