﻿// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

// Решаем математически, не строками, хотя строками проще

// Очистка консоли и инициализация переменных
Console.Clear();
// Инициализируем переменные
double? checkInput;                     // Сюда мы положим введенное "число" пользователя
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
bool flag;                              // Флажок
// Переменные для проверки
int dec, counter, rightNum, leftNum, test, index;

// Попробуем получить число, но может придти null
checkInput = userNumInput("Введите как минимум трехзначное число: ");
// Проверим число, если считать его не получилось, сгенерируем его в диапазоне от 100 до 99999999.
userNumber = getOrGenerate(checkInput, 100, 99999999);
//Пользователь ошибся? сгенерируем число сами
if (userNumber < 100) userNumber = getOrGenerate(null, 100, 99999999);

// Нужно определить поряок введенного числа. int у нас может иметь значения до 2147483647, т. е. 10 порядков
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
Console.WriteLine($"В числе {counter} цифр");
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
if (flag) Console.WriteLine("Введенное число является полиндромом.");
else Console.WriteLine("Введенное число не является полиндромом.");

//------------------------------------
//----- Пользовательские функции -----
//------------------------------------

// Функция перевода строки пользователя в число. Может вернуть null
double? userNumInput(string welcomeText = "Введите строку: ")
{
    // Инициализация переменных
    double resultNum;                   // Вернем в ней ответ
    bool resultTest;                    // Проверим, возможно ли преобразование типов
    string? resultString;               // Строка, введенная пользователем

    Console.Write(welcomeText);         // Выводим приглашение на ввод числа
    resultString = Console.ReadLine();  // Получаем строку

    // Начинаем обработку
    if ((resultString == null) || (resultString == ""))
    {
        return null;                    // Возвращаем null, т. к. мы не получили на вводе число
    }
    else
    {
        // Вечная проблема с десятичными точками и запятыми. В России меняем точки на запятые
        resultString = resultString.Replace(".", ",");
        // Попробуем парсить в double
        resultTest = double.TryParse(resultString, out resultNum);
        if (!resultTest)
        {
            return null;                // Возвращаем null, т. к. мы не получили на вводе число            
        }
        else
        {
            return resultNum;           // Возвращаем число
        }
    }
}

// Проверяем введенное пользователем число, если оно введено неверно, то получаем число рандомом от Min до Max
int getOrGenerate(double? someNum, int generateMin, int generateMax)
{
    int theNum;                         // Число! Оно обязательно вернется.
    // Оно там есть?
    if (someNum == null)
    {
        // Числа нет. Получаем случайное число.
        Console.WriteLine("Очень жаль, но введенное число не может быть обработано.\nЕсли вы считаете это ошибкой, пожалуйста, обратитесь в техническую поддержку.");
        theNum = new Random().Next(generateMin, generateMax + 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Число {theNum} было сгенерировано автоматически.");
        Console.ResetColor();
    }
    else
    {
        // someNum у нас double?, поэтому конвертируем в Int32 и работаем с ним.
        theNum = Convert.ToInt32(someNum.Value);
    }
    return theNum;
}