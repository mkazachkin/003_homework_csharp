// Напишите программу, которая выводит третью цифру заданного числа
// или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6


// Инициализируем переменные
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
int result;                             // В эту переменную мы поместим ответ.
int min = -9999;
int max = +9999;
//Диапазон задан маленьким, чтобы интереснее было с рандомом

Console.Clear();
Console.Write($"Введите число от {min} до {max}: ");
userNumber = Convert.ToInt32(NumberMakeProper(NumberInput(), min, max, true, true));

result = userNumber;
while (Math.Abs(result) > 999)
{
    result = result / 10;
}
if (Math.Abs(result) > 99)
{
    result = Math.Abs(result % 10);
    Console.WriteLine($"Третья цифра числа {userNumber} - это {result}.");
}
else Console.WriteLine($"Третья цифра в числе {userNumber} отсутствует.");

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