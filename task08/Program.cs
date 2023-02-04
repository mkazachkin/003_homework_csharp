// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

//Инициализируем переменные
double x1, y1, z1, x2, y2, z2;
double result;
int max, min;

Console.Clear();
// Ограничимся диапазоном координат от -9999999 до +9999999
max = 9999999;
min = -9999999;

Console.Write("Введите координату x1: ");
x1 = NumberMakeProper(NumberInput(), min, max);

Console.Write("Введите координату y1: ");
y1 = NumberMakeProper(NumberInput(), min, max);

Console.Write("Введите координату z1: ");
z1 = NumberMakeProper(NumberInput(), min, max);

Console.Write("Введите координату x2: ");
x2 = NumberMakeProper(NumberInput(), min, max);

Console.Write("Введите координату y2: ");
y2 = NumberMakeProper(NumberInput(), min, max);

Console.Write("Введите координату z2: ");
z2 = NumberMakeProper(NumberInput(), min, max);

result = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)), 2);
Console.Clear();
Console.WriteLine($"Координаты точек:\n1. ({x1}, {y1}, {z1})\n2. ({x2}, {y2}, {z2})\nРасстояние между точками: {result}.");

//------------------------------------
//----- Пользовательские функции -----
//------------------------------------

double? NumberInput()
//Запрашивает пользовательский ввод в консоли.
//Возвращает либо число, либо null в зависимости от того, что ввел пользователь
{
    //Инициализация переменных
    double resultDigitInput;
    bool resultTest;
    string? resultString;

    resultString = Console.ReadLine();

    if ((resultString == null) || (resultString == "")) return null;
    else
    {
        //Вечная проблема с десятичными точками и запятыми.
        resultString = resultString.Replace(".", ",");
        resultTest = double.TryParse(resultString, out resultDigitInput);
        if (!resultTest) return null;
        else return resultDigitInput;
    }
}

double NumberMakeProper(double? inputDigit, double min, double max, bool force = false, bool quiet = false)
//Если в inputDigit null, то вернет произвольное число из диапазона min max
//При включенном force проверит, попадает ли inputDigit в диапазон min max.
//Если не попадает, считает, что inputDigit = null.
//При включенном quiet не выводит сообщения в консоль.
{
    double theNum;
    if ((inputDigit == null) || ((force) && ((inputDigit < min) || (inputDigit > max))))
    {
        theNum = new Random().NextDouble() * (max - min) + min;
        if (!quiet)
        {
            Console.Write("Введенное число не может быть обработано.\nЧисло ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(theNum);
            Console.ResetColor();
            Console.WriteLine(" было сгенерировано автоматически.");
        }
    }
    else theNum = inputDigit.Value;
    return theNum;
}