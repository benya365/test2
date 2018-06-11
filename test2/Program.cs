using System;

class Program
{
    //метод 1, ленивый
    public static int method_1_lazy(int num)
    {
        int temp = 0, numBak = num;

        if (num.ToString().Length < 2)
            return num;
        else
        {
            for (int i = 0; i < num.ToString().Length; i++)
            {
                temp += numBak % 10;
                numBak /= 10;
            }

            if (temp.ToString().Length < 2)
                return temp;
            else
                return method_1_lazy(temp);
        }
    }

    //метод 2, по уму
    public static int method_2_norm(int num)
    {
        int temp = 0, numBak = num, counter = 0;
        while (numBak != 0)
        {
            numBak /= 10;
            counter++;
        }

        if (counter < 2)
            return num;
        else
        {
            numBak = num;

            for (int i = 0; i < counter; i++)
            {
                temp += numBak % 10;
                numBak /= 10;
            }

            numBak = temp; counter = 0;
            while (numBak != 0)
            {
                numBak /= 10;
                counter++;
            }

            if (counter < 2)
                return temp;
            else
                return method_2_norm(temp);
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter a number:\t");
        int num;
        int.TryParse(Console.ReadLine(), out num);
        if (method_1_lazy(num) != method_2_norm(num))
        {
            Console.WriteLine("Something is wrong");
            Console.ReadKey();
            Environment.Exit(0);
        }

        Console.WriteLine("Number - {0}, Result - {1}", num, method_2_norm(num));

        Console.ReadKey();
    }
}