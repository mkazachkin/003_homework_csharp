namespace Geekbrains;
public class IntNumber
{
    public static int Input(string message)
    {
        //Принимает текст приглашения на ввод числа типа int
        //Возвращает число типа int, введенное пользователем.
        string str;
        int num;
        do
        {
            Console.Write($"{message}: ");
            str = Console.ReadLine()!;
        } while (!int.TryParse(str, out num));
        return num;
    }
}
public class DoubleNumber
{
    public static double Input(string message)
    {
        //Принимает текст приглашения на ввод числа типа double
        //Возвращает число типа double, введенное пользователем.
        string str;
        double num;
        do
        {
            Console.Write($"{message}: ");
            str = Console.ReadLine()!;
        } while (!double.TryParse(str, out num));
        return num;
    }
}

