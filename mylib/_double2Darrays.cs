namespace Geekbrains;
public class Double2DArray
{
    public static double[,] Make(int m, int n, double min, double max)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа double с указанными параметрами.
        if (m < 1) { m = 1; }
        if (n < 1) { n = 1; }
        if (max < min) { double tmp = max; max = min; min = tmp; }
        double[,] resArray = new double[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                resArray[i, j] = new Random().NextDouble() * (max - min) + min;

            }
        }
        return resArray;
    }
    public static double[,] MakeCustom()
    {
        //Запрашивает пользователя о параметрах массива и возвращает массив с этими параметрами
        int m = Input.IntNum("Задайте размер количество строк в массиве");
        int n = Input.IntNum("Задайте размер количество столбцов в масстве");
        double min = Input.DoubleNum("Задайте минимальное число в массиве");
        double max = Input.DoubleNum("Задайте максимальное число в массиве");
        return Double2DArray.Make(m, n, min, max);
    }
    public static void Print(double[,] array, int cellSize = 12, string format = " {0:F2}")
    {
        //Выводит принятый массив вещественных чисел array в консоль в формате format
        //Ширина ячейки в символах cellSize 
        bool flag = true;
        string str;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                flag = !flag;
            }
            else
            {
                Console.ResetColor();
                flag = !flag;
            }
            for (int j = 0; j < array.GetLength(1); j++)
            {
                str = string.Format(format, array[i, j]);
                str = str.PadLeft(cellSize);
                Console.Write(str);
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }
    public static double? GetValue(double[,] array, int row, int col)
    {
        //Возвращает значение в массиве, расположенное в ряду row и колонке col.
        //Если такой позиции нет, возвращает null
        double? res;
        if ((row > array.GetLength(0) - 1) || (row < 0) || (col > array.GetLength(1) - 1) || (col < 0))
        {
            res = null;
        }
        else
        {
            res = array[row, col];
        }
        return res;
    }
}