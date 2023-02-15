namespace Geekbrains;
public class Input
{
    public static int IntNum(string message)
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
    public static double DoubleNum(string message)
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
    public static double[] DoubeNumsString(string message, string splitChr)
    {
        double[] nums;
        string[] strNums;
        bool flag;
        string str;
        int i;
        do
        {
            flag = true;
            Console.Write($"{message}: ");
            str = Console.ReadLine()!;
            str = str.Replace(".", ",");
            strNums = str.Split(splitChr);
            nums = new double[strNums.Length];
            for (i = 0; i < strNums.Length; i++)
            {
                if (flag) flag = double.TryParse(strNums[i], out nums[i]);
            }
        } while (!flag);
        return nums;
    }
}
