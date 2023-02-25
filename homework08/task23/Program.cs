// Задайте две матрицы. Напишите программу, которая будет находить
// произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

using Geekbrains;

double[,] result;
bool flag = false;

// Изменить эти три параметра, если нужно работать с вещественными числами
bool makeInteger = true;
int cellSize = 6;
string format = " {0:f0}";

Console.Clear();
Console.WriteLine("Параметры матрицы A:");
double[,] matrixA = Double2DArray.MakeCustom(makeInteger);
Console.WriteLine();
Console.WriteLine("Параметры матрицы B:");
double[,] matrixB = Double2DArray.MakeCustom(makeInteger);
Console.WriteLine();

Console.WriteLine("Матрица A:");
Double2DArray.Print(matrixA, cellSize, format);
Console.WriteLine("Матрица B:");
Double2DArray.Print(matrixB, cellSize, format);

int widthA = matrixA.GetLength(0);
int lengthA = matrixA.GetLength(1);
int widthB = matrixB.GetLength(0);
int lengthB = matrixB.GetLength(1);

if (lengthA == widthB)
{
    result = Double2DArray.Multiplication(matrixA, matrixB);
    Console.WriteLine("Произведение матриц AxB:");
    flag = true;
    Double2DArray.Print(result, cellSize, format);
}
//Тут не стоит else и используется флажок, чтобы отработать вариант BxA при квадратных матрицах
if (lengthB == widthA)
{
    result = Double2DArray.Multiplication(matrixB, matrixA);
    Console.WriteLine("Произведение матриц BxA:");
    flag = true;
    Double2DArray.Print(result, cellSize, format);
}

if (!flag)
{
    Console.WriteLine("Матрицы A и B не совместимы.");
}