// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.Clear();

int sizeA = 2;
int sizeB = 2;
int sizeC = 2;
int min = 10;
int max = 99;
int uniqueValues = max - min + 1;
bool[] checkValue = new bool[max - min + 1];
int tmp;

for (int i = 0; i < checkValue.Length; i++)
{
    checkValue[i] = false;
}

int[,,] matrix3d = new int[sizeA, sizeB, sizeC];
for (int a = 0; a < sizeA; a++)
{
    for (int b = 0; b < sizeB; b++)
    {
        for (int c = 0; c < sizeC; c++)
        {
            //Проверка на уникальность
            do
            {
                tmp = new Random().Next(min, max + 1);
            } while (checkValue[tmp - min]);
            checkValue[tmp - min] = true;
            matrix3d[a, b, c] = tmp;
            Console.WriteLine($"{matrix3d[a, b, c]} ({a}, {b}, {c})");
        }
    }
}