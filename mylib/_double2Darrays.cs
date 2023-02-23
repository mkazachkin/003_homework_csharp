namespace Geekbrains;
public class Double2DArray
{
    public static double[,] Make(
        int rows,
        int cols,
        double min,
        double max,
        bool integerNums = false)
    {
        //Принимает размер массива, а также минимальное и максимальное целое число в массиве.
        //Возвращает массив произвольных чисел типа double с указанными параметрами.
        if (rows < 1)
        {
            rows = 1;
        }
        if (cols < 1)
        {
            cols = 1;
        }
        if (max < min)
        {
            double tmp = max;
            max = min;
            min = tmp;
        }
        double[,] array = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = new Random().NextDouble() * (max - min) + min;
                if (integerNums)
                {
                    array[i, j] = Math.Round(array[i, j]);
                }
            }
        }
        return array;
    }
    public static double[,] MakeCustom(bool integerNums = false)
    {
        //Запрашивает пользователя о параметрах массива и возвращает массив с этими параметрами
        int rows = Input.IntNum("Задайте размер количество строк в массиве");
        int cols = Input.IntNum("Задайте размер количество столбцов в массиве");
        double min = Input.DoubleNum("Задайте минимальное число в массиве");
        double max = Input.DoubleNum("Задайте максимальное число в массиве");
        return Double2DArray.Make(rows, cols, min, max, integerNums);
    }
    public static void Print(
        double[,] array,
        int cellSize = 12,
        string format = " {0:F2}",
        ConsoleColor evenLineColor = ConsoleColor.White,
        ConsoleColor oddLineColor = ConsoleColor.DarkGray)
    {
        //Выводит принятый массив вещественных чисел array в консоль в формате format
        //Ширина ячейки в символах cellSize 
        bool flag = true;
        string str;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (flag)
            {
                Console.ForegroundColor = evenLineColor;
            }
            else
            {
                Console.ForegroundColor = oddLineColor;
            }
            flag = !flag;
            str = "";
            for (int j = 0; j < array.GetLength(1); j++)
            {
                str += string.Format(format, array[i, j]).PadLeft(cellSize);
            }
            Console.WriteLine(str);
        }
        Console.ResetColor();
    }
    public static double? GetValue(
        double[,] array,
        int row,
        int col)
    {
        //Возвращает значение в массиве, расположенное в ряду row и колонке col.
        //Если такой позиции нет, возвращает null
        double? res;
        if ((row > array.GetLength(0) - 1)
            || (row < 0)
            || (col > array.GetLength(1) - 1)
            || (col < 0))
        {
            res = null;
        }
        else
        {
            res = array[row, col];
        }
        return res;
    }
    public static double[,] FrequencyDictionary(double[,] array)
    {
        //Возвращает частотный словарь принимаемого массива
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        double?[] frequencyMatrix = new double?[rows * cols];
        double[,] res = new double[2, rows * cols];
        int position = 0;
        int counter;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                frequencyMatrix[position] = array[i, j];
                position++;
            }
        }
        position = 0;
        for (int i = 0; i < frequencyMatrix.Length; i++)
        {
            if (!(frequencyMatrix[i] is null))
            {
                res[0, position] = Convert.ToDouble(frequencyMatrix[i]);
                counter = 0;
                for (int j = frequencyMatrix.Length - 1; j >= i; j--)
                {
                    if (frequencyMatrix[j] == frequencyMatrix[i])
                    {
                        counter++;
                        frequencyMatrix[j] = null;
                    }
                }
                res[1, position] = Convert.ToDouble(counter);
                position++;
            }
        }
        res = Double2DArray.Resize(res, 2, position);
        res = Double2DArray.SortRow(res, 0, true, true);
        return res;
    }
    public static double[,] SortRow(double[,] array, int row,
        bool asc = true, bool concatenateCols = false)
    {
        //Сортирует ряд row принимаемого массива по возрастанию (если asc=true),
        //или убыванию (asc=false). При включенном concatenateCols (true), остальные
        //колонки сортируются в соотвествии с рядом row
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        double[,] res = new double[rows, cols];
        double tmp;
        res = array;
        for (int i = 1; i < cols; i++)
        {
            if ((asc && ((i != 0) && (res[row, i] < res[row, i - 1]))) ||
               (!asc && ((i != 0) && (res[row, i] > res[row, i - 1]))))
            {
                tmp = res[row, i];
                res[row, i] = res[row, i - 1];
                res[row, i - 1] = tmp;
                if (concatenateCols)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (j != row)
                        {
                            tmp = res[j, i];
                            res[j, i] = res[j, i - 1];
                            res[j, i - 1] = tmp;
                        }
                    }
                }
                i = i - 2;
            }
        }
        return res;
    }
    public static double[,] Resize(double[,] array, int rows, int cols)
    {
        //Возвращает указанного в rows и cols размера.
        //Производит перезапись совпадающих  ячеек массива из array.
        //Если размер array больше, то обрезанные ячейки выкидываются.
        //Если меньше, то ячейки за пределами array заполняются 0.
        int oldCols = array.GetLength(0);
        int oldRows = array.GetLength(1);
        double[,] res = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if ((i < oldRows) && (j < oldCols))
                {
                    res[i, j] = array[i, j];
                }
                else
                {
                    res[i, j] = 0;
                }
            }
        }
        return res;
    }
    public static double SumRow(double[,] array, int row)
    {
        //Выдает сумму ячеек массива в указанном ряде.
        double res = 0;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            res += array[row, i];
        }
        return res;
    }
    public static double SumColumn(double[,] array, int column)
    {
        //Выдает сумму ячеек массива в указанной колонке.
        double res = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            res += array[i, column];
        }
        return res;
    }
    public static double[,] Multiplication(double[,] arrayA, double[,] arrayB)
    {
        //Производит умножение массивов (матриц). Матрицы должны быть совместимыми.
        //Проверка на совместимость на входе не проводится.
        double[,] res = new double[arrayA.GetLength(0), arrayB.GetLength(1)];
        for (int i = 0; i < res.GetLength(0); i++)
        {
            for (int j = 0; j < res.GetLength(1); j++)
            {
                res[i, j] = 0;
                for (int k = 0; k < arrayB.GetLength(0); k++)
                {
                    res[i, j] += arrayA[i, k] * arrayB[k, j];
                }
            }
        }
        return res;
    }
}