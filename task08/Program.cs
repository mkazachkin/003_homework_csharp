// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

//Инициализируем переменные
double?[] checkX = new double?[2];
double?[] checkY = new double?[2];
double?[] checkZ = new double?[2];
double[] x = new double[2];
double[] y = new double[2];
double[] z = new double[2];
int counter;
double result;

counter = 0;
//Введем координаты двух точек
while (counter < 2)
{
    checkX[counter] = userNumInput($"Введите координату x{counter} в диапазоне от -99999 до +99999: ");
    x[counter] = getOrGenerate(checkX[counter], -99999, +99999, true);
    checkY[counter] = userNumInput($"Введите координату y{counter} в диапазоне от -99999 до +99999: ");
    y[counter] = getOrGenerate(checkY[counter], -99999, +99999, true);
    checkZ[counter] = userNumInput($"Введите координату z{counter} в диапазоне от -99999 до +99999: ");
    z[counter] = getOrGenerate(checkZ[counter], -99999, +99999, true);
    //Принудительно загоняем число в указанный  диапазон третим опциональным аргументом.
    //Функция getOrGenerate доработана.
    counter++;
}
Console.Clear();
result = Math.Round(Math.Sqrt(Math.Pow(x[1] - x[0], 2) + Math.Pow(y[1] - y[0], 2) + Math.Pow(z[1] - z[0], 2)), 2);
Console.WriteLine($"Расстояние между точками с координатами ({x[0]}, {y[0]}, {z[0]}) и ({x[1]}, {y[1]}, {z[1]}) составляет {result}");

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
double getOrGenerate(double? someNum, int generateMin, int generateMax, bool forceRange = false)
{
    double theNum;                         // Число! Оно обязательно вернется.
    // Оно там есть?
    if ((someNum == null) || ((forceRange) && ((someNum < generateMin) || (someNum > generateMax))))
    {
        // Числа нет или оно вне диапазона. Получаем случайное число.
        Console.WriteLine("Введенное число не может быть обработано.");
        theNum = new Random().Next(generateMin, generateMax + 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Число {theNum} было сгенерировано автоматически.");
        Console.ResetColor();
    }
    else
    {
        // someNum у нас double?, поэтому конвертируем в Int32 и работаем с ним.
        theNum = someNum.Value;
    }
    return theNum;
}