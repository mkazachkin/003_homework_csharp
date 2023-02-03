// Напишите программу, которая выводит третью цифру заданного числа
// или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

// Очистка консоли и инициализация переменных
Console.Clear();
// Инициализируем переменные
double? checkInput;                     // Сюда мы положим введенное "число" пользователя
int userNumber;                         // Сюда мы положим число пользователя. Int меньше Double, так что скушает 
int result;                             // В эту переменную мы поместим ответ.

// Попробуем получить число, но может придти null
checkInput = userNumInput("Введите число: ");
// Проверим число, если считать его не получилось, сгенерируем его в диапазоне от -99999 до 99999.
userNumber = getOrGenerate(checkInput, -99999, 99999);

// Нам нужна третья цифра. Уменьшим введенное число до трехзначного.
// Промежуточные вычисления будем сохранять сразу в result, чтобы не заводит новую переменную.
result = userNumber;
// Число берем по модулю
while (Math.Abs(result) > 999)
{
    //Очень большое число делим на 10. Дробная часть "улетучится", т. к. тип данных int
    result = result / 10;
}
// К этой result будет либо трехзначный, либо меньше 99 по модулю.
if (Math.Abs(result) > 99)
{
    // Третье число получаем из остатка деления на 10. И берем его по модулю.
    result = Math.Abs(result % 10);

    Console.WriteLine($"Третья цифра числа {userNumber} - это {result}.");
}
else
{
    Console.WriteLine($"Третья цифра в числе {userNumber} отсутствует.");
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