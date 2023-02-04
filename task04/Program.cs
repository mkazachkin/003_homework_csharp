// Напишите программу, которая принимает на вход трёхзначное число
// и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

// Инициализируем переменные
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
int result;                             // В эту переменную мы поместим ответ.
int min = 100;
int max = 999;

Console.Clear();
Console.Write($"Введите число от {min} до {max} или от -{max} до -{min} : ");
userNumber = Convert.ToInt32(NumberMakeProper(NumberInput(), min, max, true, true, true));

// Решаем задачу.
result = Math.Abs(((userNumber / 10) % 10));
Console.WriteLine($"Вторая цифра числа {userNumber}: {result}");

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