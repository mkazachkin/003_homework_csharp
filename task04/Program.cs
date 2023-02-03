// Напишите программу, которая принимает на вход трёхзначное число
// и на выходе показывает вторую цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

// Очистка консоли и инициализация переменных
Console.Clear();
// Инициализируем переменные
double? checkInput;                     // Сюда мы положим введенное "число" пользователя
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
int result;                             // В эту переменную мы поместим ответ.

// Попробуем получить число, но может придти null
checkInput = userNumInput("Введите трехзначное число: ");
// Проверим число, если считать его не получилось, сгенерируем его в диапазоне от 100 до 999.
userNumber = getOrGenerate(checkInput, 100, 999);

// Нам нужно трехзначное число. Можно отрицательное, но трехзначное. Оно такое?
if ((Math.Abs(userNumber) < 100) || (Math.Abs(userNumber) > 999))
{
    //Число не удовлетворяет условиям задачи. Прощаемся с пользователем
    Console.WriteLine("Очень жаль, но введенное число не трехзначное.\nПопробуйте в следующий раз.");
    Environment.Exit(1);
}

// Решаем задачу.
result = Math.Abs(((userNumber / 10) % 10));
Console.WriteLine($"Вторая цифра введенного числа: {result}");

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