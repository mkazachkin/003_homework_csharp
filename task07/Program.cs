// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

// Решаем математически, не строками, хотя строками проще

int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
bool flag;                              // Флажок

// Переменные для проверки
int dec, counter, rightNum, leftNum, test, index;

int min = -999999999;
int max = +999999999;


Console.Clear();
Console.Write($"Введите число в диапазоне от {min} до {max}: ");
//Работаем только с целой частью
userNumber = Convert.ToInt32(NumberMakeProper(NumberInput(), min, max, true, true));

// Нужно определить порядок введенного числа. int у нас может иметь значения до 2147483647, т. е. 10 порядков
dec = Convert.ToInt32(Math.Pow(10, 9));     //10 в 9 степени.
counter = 10;                               //Клдичество цифр в числе 10
do
// Уменьшаем порядок, пока не увидим число в целой части
{
    test = userNumber / dec;                //Проверяем, будет ли целая часть
    dec = dec / 10;
    counter--;
} while (test == 0);
counter++;                                  //Компенсируем вычитание в цикле
dec = dec * 10;                             //Компенсируем деление в цикле

// С порядком определились. Теперь узнаем, сколько нужно проверить чисел слева и справа
Console.WriteLine($"В числе {userNumber} - {counter} цифр.");
index = counter / 2;
// Поднимаем флажок, который нам сигнализирует, что число полиндром
flag = true;

while (index != 0)                          //Идем от края к центру index шагов
{
    // Левое число получаем, разделив на 10 в степени текущего порядка числа
    leftNum = userNumber / dec;
    // Убираем число слева, оно нам больше не нужно
    userNumber = userNumber % dec;
    // Правое число получаем, взяв остаток от деления на 10
    rightNum = userNumber % 10;
    // Убираем число справа, разделив его на 10
    userNumber = userNumber / 10;
    // Если числа не совпадают, то флажок отпускаем
    if (leftNum != rightNum) flag = false;
    // Сокращаем переменную, указывающую на порядок числа на 2 единицы
    dec = dec / 100;
    // Идем дальше
    index--;
}
// Если флажок у нас гордо реет до сих пор, то число полиндром
Console.Write("Введенное число ");
if (flag)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("является");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("не является");
    Console.ResetColor();
}
Console.WriteLine(" полиндромом.");

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