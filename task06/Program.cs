// Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели,
// и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет

// Очистка консоли и инициализация переменных
Console.Clear();
// Инициализируем переменные
double? checkInput;                     // Сюда мы положим введенное "число" пользователя
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 

// Массивы на лекциях были. И раз уж функции используем, то и массивы тоже можно. Но решение без них
string[] week = new string[7] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

// Попробуем получить число, но может придти null
checkInput = userNumInput("Введите номер дня недели: ");
// Проверим число, если считать его не получилось, сгенерируем его в диапазоне от 1 до 7.
userNumber = getOrGenerate(checkInput, 1, 7);
if ((userNumber > 7) || (userNumber < 1))
{
    // Нет такого дня недели. Сгенерируем число сами.
    userNumber = getOrGenerate(null, 1, 7);
}

//Пятница прошла, а понедельник не начался? Weekend!
if ((userNumber > 5) && (userNumber < 8))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{week[userNumber - 1]} - выходной.");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"{week[userNumber - 1]} - рабочий день.");
}

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