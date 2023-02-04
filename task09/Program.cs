//Напишите программу, которая принимает на вход число (N)
//и выдаёт таблицу кубов чисел от 1 до N.
//3-> 1, 8, 27
//5-> 1, 8, 27, 64, 125

//Инициализация переменных
int num, increment, min, max, pow, powMin, powMax;
string column1, column2;
bool autoFix, hideFix;

//Начальная конфигурация
//Если powMin меньше -9 или powMax больше 9, то работать не будет. Нужно переделывать вывод в консоль.  
min = -999;         //Задаем минимально допустимое вводимое число
max = +999;         //Задаем максимально допустимое вводимое число
powMin = -9;        //Задаем минимальную степень вывода в таблице
powMax = +9;        //Задаем максимальную степень вывода в таблице
autoFix = true;     //Автоматически исправляем некорректный ввод
hideFix = true;     //Пользователя об этом не уведомляем

//Для красивого вывода в консоль, если utf8
int codepage = Console.OutputEncoding.CodePage;
string[] powString;
if (codepage != 65001) powString = new string[19] { "^-9", "^-8", "^-7", "^-6", "^-5", "^-4", "^-3", "^-2", "^-1", "^0", "^1", "^2", "^3", "^4", "^5", "^6", "^7", "^8", "^9" };
else powString = new string[19] { "⁻⁹", "⁻⁸", "⁻⁷", "⁻⁶", "⁻⁵", "⁻⁴", "⁻³", "⁻²", "⁻¹", "", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹" };

Console.Clear();
Console.Write($"Введите число от {min} до {max} не равное 0: ");
num = Convert.ToInt32(NumberMakeProper(NumberInput(), min, max, autoFix, hideFix));
Console.Write($"Таблицу значений какой степени вывести на экран (от {powMin} до {powMax}): ");
pow = Convert.ToInt32(NumberMakeProper(NumberInput(), powMin, powMax, autoFix, hideFix));
if (num != 0)
{
    if (num < 0) increment = -1; else increment = +1;
    int counter = increment;
    Console.WriteLine($"Таблица степени {pow} чисел от {counter} до {num}: ");
    bool flag = true;
    while (Math.Abs(counter) <= Math.Abs(num))
    {
        column1 = Convert.ToString(counter) + powString[pow + 9];

        //Собственно, сам расчет здесь
        column2 = Convert.ToString(Math.Pow(counter, pow));

        while (column1.Length < 4) column1 = " " + column1;
        if (!flag) Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{column1}: {column2}");
        if (!flag) Console.ResetColor();
        flag = !flag;

        counter = counter + increment;
    }
}
else
{
    Console.Write("Таблица считается только для чисел ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("не равных 0");
    Console.ResetColor();
    Console.WriteLine(".");
}
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

double NumberMakeProper(double? inputDigit, double min, double max, bool force = false, bool quiet = false, bool absCheck = false)
//Если в inputDigit null, то вернет произвольное число из диапазона min max
//При включенном force проверит, число не попадающее в диапазон игнорирует и возвращает произвольное от min max.
//      По-умолчанию выключено.
//При включенном quiet не выводит сообщения в консоль.
//      По-умолчанию выключено. 
//При включенном absChek проверяет диапазон по модулю.
//Произвольное число возвращает в диапазоне от min до max и от -max до min. 
//      По-умолчанию выключено.
{
    double theNum = inputDigit ?? 0.0;
    bool flag = false;
    if (inputDigit == null) flag = true;
    if ((!flag) && (force) && (absCheck) && ((Math.Abs(theNum) < min) || (Math.Abs(theNum) > max))) flag = true;
    if ((!flag) && (force) && (!absCheck) && ((theNum < min) || (theNum > max))) flag = true;
    if (flag)
    {
        theNum = new Random().NextDouble() * (max - min) + min;
        if (absCheck)
        {
            int minus = new Random().Next(0, 2);
            if (minus == 0) theNum = theNum * (-1);
        }
        if (!quiet)
        {
            Console.Write("Введенное число не может быть обработано.\nЧисло ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(theNum);
            Console.ResetColor();
            Console.WriteLine(" было сгенерировано автоматически.");
        }
    }
    return theNum;
}
