// Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели,
// и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет

// Инициализируем переменные
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
string[] week = new string[7] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
int min = 1;
int max = 7;


Console.Clear();
Console.Write("Введите номер дня недели: ");
userNumber = Convert.ToInt16(NumberMakeProper(NumberInput(), min, max, true, true));
Console.Write($"{week[userNumber - 1]} - это {userNumber} день недели. ");

//Пятница прошла, а понедельник не начался? Weekend!
if ((userNumber > 5) && (userNumber < 8))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Выходной.");
    Console.ResetColor();
}
else Console.WriteLine("Рабочий день.");

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
    double theNum;
    bool flag = false;
    if (inputDigit == null) flag = true;
    if ((!flag) && (force) && (absCheck) && ((Math.Abs(inputDigit.Value) < min) || (Math.Abs(inputDigit.Value) > max))) flag = true;
    if ((!flag) && (force) && (!absCheck) && ((inputDigit.Value < min) || (inputDigit.Value > max))) flag = true;
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
    else theNum = inputDigit.Value;
    return theNum;
}