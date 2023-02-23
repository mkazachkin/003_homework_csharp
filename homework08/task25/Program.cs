// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

using Geekbrains;

int rows = Input.IntNum("Введите количество рядов");
int cols = Input.IntNum("Введите количество колонок");
int borderRows = rows + 2;
int borderCols = rows + 2;

double[,] spiralMatrix = new double[rows, cols];
bool[,] borders = new bool[borderRows, borderCols];

//Зададим матрицу, в которой определим разрешенные для заполнения поля
for (int i = 0; i < borderRows; i++)
{
    for (int j = 0; j < borderCols; j++)
    {
        if (
            (i == 0)
            || (j == 0)
            || (i == (borderRows - 1))
            || (j == (borderCols - 1)))
        {
            borders[i, j] = false;
        }
        else
        {
            borders[i, j] = true;
        }
    }
}
//Задаем начальные параметры обхода матрицы по спирали
bool moveRows = false;  //Изначально двигаемся по колонкам
int stepRows = 1;       //Шагаем по рядам сверху вниз
int stepCols = 1;       //Шагаем по колонкам слева направо
int matrixRowPos = 0;   //Задаем стартовую позицию
int matrixColPos = 0;   //Нужна угловая позиция, иначе не заполним по спирали
int bordersRowPos = 1;  //+1 к позиции в матрице, можно и без этих переменных, но так проще
int bordersColPos = 1;
double counter = 1;         //Инициализируем счетчик
double steps = rows * cols; //Количество шагов. Сработает корректно, только если обходить с угла   

while (counter <= steps)
{
    //Заполняем номер шага
    spiralMatrix[matrixRowPos, matrixColPos] = counter;
    //Помечаем ячейку как заполненную
    borders[bordersRowPos, bordersColPos] = false;
    //Дергаем счетчик
    counter++;
    //Идем по ряду или по колонке?
    if (moveRows)
    {
        //Идем по ряду
        if (borders[bordersRowPos + stepRows, bordersColPos])
        {
            //Если в направлении движения есть свободная для заполнения ячейка, то идем дальше
            matrixRowPos += stepRows;
            bordersRowPos += stepRows;
        }
        else
        {
            //Тупик.
            //Меняем направление движения по ряду
            stepRows *= -1;
            //И начинаем обход по колонке
            moveRows = !moveRows;
            matrixColPos += stepCols;
            bordersColPos += stepCols;
        }
    }
    else
    //Аналогично рядам, идем по колонкам
    {
        if (borders[bordersRowPos, bordersColPos + stepCols])
        {
            matrixColPos += stepCols;
            bordersColPos += stepCols;
        }
        else
        {
            stepCols *= -1;
            moveRows = !moveRows;
            matrixRowPos += stepRows;
            bordersRowPos += stepRows;
        }
    }
}
Double2DArray.Print(spiralMatrix, 4, "{0:f0}");