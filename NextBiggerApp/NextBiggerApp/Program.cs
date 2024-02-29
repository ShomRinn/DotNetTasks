int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
bool k;
int number;
int result = 0;
int temp = 0; // добавить еще 10 переменных для вычисления всего этого кринжа или нет я не знаю.

number = int.Parse(Console.ReadLine());


if (number < 10)
{
    Console.WriteLine(-1);
}
else if (number < 100)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {
        result = n1 + (n2 * 10);
    }
}
else if (number < 1000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {
        result = n1 + (n2 * 10) + (n3 * 100);
    }
}
else if (number < 10_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n2 > n3 && n2 > n1)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }

    else if (n3 > n4 && n3 > n2)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }

    else if (n2 > n4 && n2 > n1)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {
        result = n1 + (n2 * 10) + (n3 * 100) + (n4 * 1000);
    }
}
else if (number < 100_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }
    result = int.Parse(Console.ReadLine());
}
else if (number < 1_000_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    number /= 10;
    n6 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n1 > n6)
    {
        temp = n1;
        n1 = n6;
        n6 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n2 > n6)
    {
        temp = n2;
        n2 = n6;
        n6 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n3 > n6)
    {
        temp = n3;
        n3 = n6;
        n6 = temp;
    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else if (n4 > n6)
    {
        temp = n4;
        n4 = n6;
        n6 = temp;
    }
    else if (n5 > n6)
    {
        temp = n5;
        n5 = n6;
        n6 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n6);
        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }
    
    result = int.Parse(Console.ReadLine());

}
else if (number < 10_000_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    number /= 10;
    n6 = number % 10;
    number /= 10;
    n7 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n1 > n6)
    {
        temp = n1;
        n1 = n6;
        n6 = temp;
    }
    else if (n1 > n7)
    {
        temp = n1;
        n1 = n7;
        n7 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n2 > n6)
    {
        temp = n2;
        n2 = n6;
        n6 = temp;
    }
    else if (n2 > n7)
    {
        temp = n2;
        n2 = n7;
        n7 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n3 > n6)
    {
        temp = n3;
        n3 = n6;
        n6 = temp;
    }
    else if (n3 > n7)
    {
        temp = n3;
        n3 = n7;
        n7 = temp;
    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else if (n4 > n6)
    {
        temp = n4;
        n4 = n6;
        n6 = temp;
    }
    else if (n4 > n7)
    {
        temp = n4;
        n4 = n7;
        n7 = temp;
    }
    else if (n5 > n6)
    {
        temp = n5;
        n5 = n6;
        n6 = temp;
    }
    else if (n5 > n7)
    {
        temp = n5;
        n5 = n7;
        n7 = temp;
    }
    else if (n6 > n7)
    {
        temp = n6;
        n6 = n7;
        n7 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n7);
        Console.Write(n6);
        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }
    
    result = int.Parse(Console.ReadLine());
    
}
else if (number < 100_000_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    number /= 10;
    n6 = number % 10;
    number /= 10;
    n7 = number % 10;
    number /= 10;
    n8 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n1 > n6)
    {
        temp = n1;
        n1 = n6;
        n6 = temp;
    }
    else if (n1 > n7)
    {
        temp = n1;
        n1 = n7;
        n7 = temp;
    }
    else if (n1 > n8)
    {
        temp = n1;
        n1 = n8;
        n8 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n2 > n6)
    {
        temp = n2;
        n2 = n6;
        n6 = temp;
    }
    else if (n2 > n7)
    {
        temp = n2;
        n2 = n7;
        n7 = temp;
    }
    else if (n2 > n8)
    {
        temp = n2;
        n2 = n8;
        n8 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n3 > n6)
    {
        temp = n3;
        n3 = n6;
        n6 = temp;
    }
    else if (n3 > n7)
    {
        temp = n3;
        n3 = n7;
        n7 = temp;
    }
    else if (n3 > n8)
    {
        temp = n3;
        n3 = n8;
        n8 = temp;
    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else if (n4 > n6)
    {
        temp = n4;
        n4 = n6;
        n6 = temp;
    }
    else if (n4 > n7)
    {
        temp = n4;
        n4 = n7;
        n7 = temp;
    }
    else if (n4 > n8)
    {
        temp = n4;
        n4 = n8;
        n8 = temp;
    }
    else if (n5 > n6)
    {
        temp = n5;
        n5 = n6;
        n6 = temp;
    }
    else if (n5 > n7)
    {
        temp = n5;
        n5 = n7;
        n7 = temp;
    }
    else if (n5 > n8)
    {
        temp = n5;
        n5 = n8;
        n8 = temp;
    }
    else if (n6 > n7)
    {
        temp = n6;
        n6 = n7;
        n7 = temp;
    }
    else if (n6 > n8)
    {
        temp = n6;
        n6 = n8;
        n8 = temp;
    }
    else if (n7 > n8)
    {
        temp = n7;
        n7 = n8;
        n8 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n8);
        Console.Write(n7);
        Console.Write(n6);
        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }

    result = int.Parse(Console.ReadLine());
}
else if (number < 1_000_000_000)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    number /= 10;
    n6 = number % 10;
    number /= 10;
    n7 = number % 10;
    number /= 10;
    n8 = number % 10;
    number /= 10;
    n9 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n1 > n6)
    {
        temp = n1;
        n1 = n6;
        n6 = temp;
    }
    else if (n1 > n7)
    {
        temp = n1;
        n1 = n7;
        n7 = temp;
    }
    else if (n1 > n8)
    {
        temp = n1;
        n1 = n8;
        n8 = temp;
    }
    else if (n1 > n9)
    {
        temp = n1;
        n1 = n9;
        n9 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n2 > n6)
    {
        temp = n2;
        n2 = n6;
        n6 = temp;
    }
    else if (n2 > n7)
    {
        temp = n2;
        n2 = n7;
        n7 = temp;
    }
    else if (n2 > n8)
    {
        temp = n2;
        n2 = n8;
        n8 = temp;
    }
    else if (n2 > n9)
    {
        temp = n2;
        n2 = n9;
        n9 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n3 > n6)
    {
        temp = n3;
        n3 = n6;
        n6 = temp;
    }
    else if (n3 > n7)
    {
        temp = n3;
        n3 = n7;
        n7 = temp;
    }
    else if (n3 > n8)
    {
        temp = n3;
        n3 = n8;
        n8 = temp;
    }
    else if (n3 > n9)
    {
        temp = n3;
        n3 = n9;
        n9 = temp;
    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else if (n4 > n6)
    {
        temp = n4;
        n4 = n6;
        n6 = temp;
    }
    else if (n4 > n7)
    {
        temp = n4;
        n4 = n7;
        n7 = temp;
    }
    else if (n4 > n8)
    {
        temp = n4;
        n4 = n8;
        n8 = temp;
    }
    else if (n4 > n9)
    {
        temp = n4;
        n4 = n9;
        n9 = temp;
    }
    else if (n5 > n6)
    {
        temp = n5;
        n5 = n6;
        n6 = temp;
    }
    else if (n5 > n7)
    {
        temp = n5;
        n5 = n7;
        n7 = temp;
    }
    else if (n5 > n8)
    {
        temp = n5;
        n5 = n8;
        n8 = temp;
    }
    else if (n5 > n9)
    {
        temp = n5;
        n5 = n9;
        n9 = temp;
    }
    else if (n6 > n7)
    {
        temp = n6;
        n6 = n7;
        n7 = temp;
    }
    else if (n6 > n8)
    {
        temp = n6;
        n6 = n8;
        n8 = temp;
    }
    else if (n6 > n9)
    {
        temp = n6;
        n6 = n9;
        n9 = temp;
    }
    else if (n7 > n8)
    {
        temp = n7;
        n7 = n8;
        n8 = temp;
    }
    else if (n7 > n9)
    {
        temp = n7;
        n7 = n9;
        n9 = temp;
    }
    else if (n8 > n9)
    {
        temp = n8;
        n8 = n9;
        n9 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n9);
        Console.Write(n8);
        Console.Write(n7);
        Console.Write(n6);
        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }

        result = int.Parse(Console.ReadLine());
}
else if (number <= int.MaxValue)
{
    n1 = number % 10;
    number /= 10;
    n2 = number % 10;
    number /= 10;
    n3 = number % 10;
    number /= 10;
    n4 = number % 10;
    number /= 10;
    n5 = number % 10;
    number /= 10;
    n6 = number % 10;
    number /= 10;
    n7 = number % 10;
    number /= 10;
    n8 = number % 10;
    number /= 10;
    n9 = number % 10;
    number /= 10;
    n10 = number % 10;
    k = true;

    if (n1 > n2)
    {
        temp = n1;
        n1 = n2;
        n2 = temp;
    }
    else if (n1 > n3)
    {
        temp = n1;
        n1 = n3;
        n3 = temp;
    }
    else if (n1 > n4)
    {
        temp = n1;
        n1 = n4;
        n4 = temp;
    }
    else if (n1 > n5)
    {
        temp = n1;
        n1 = n5;
        n5 = temp;
    }
    else if (n1 > n6)
    {
        temp = n1;
        n1 = n6;
        n6 = temp;
    }
    else if (n1 > n7)
    {
        temp = n1;
        n1 = n7;
        n7 = temp;
    }
    else if (n1 > n8)
    {
        temp = n1;
        n1 = n8;
        n8 = temp;
    }
    else if (n1 > n9)
    {
        temp = n1;
        n1 = n9;
        n9 = temp;
    }
    else if (n1 > n10)
    {
        temp = n1;
        n1 = n10;
        n10 = temp;
    }
    else if (n2 > n3)
    {
        temp = n2;
        n2 = n3;
        n3 = temp;
    }
    else if (n2 > n4)
    {
        temp = n2;
        n2 = n4;
        n4 = temp;
    }
    else if (n2 > n5)
    {
        temp = n2;
        n2 = n5;
        n5 = temp;
    }
    else if (n2 > n6)
    {
        temp = n2;
        n2 = n6;
        n6 = temp;
    }
    else if (n2 > n7)
    {
        temp = n2;
        n2 = n7;
        n7 = temp;
    }
    else if (n2 > n8)
    {
        temp = n2;
        n2 = n8;
        n8 = temp;
    }
    else if (n2 > n9)
    {
        temp = n2;
        n2 = n9;
        n9 = temp;
    }
    else if (n2 > n10)
    {
        temp = n2;
        n2 = n10;
        n10 = temp;
    }
    else if (n3 > n4)
    {
        temp = n3;
        n3 = n4;
        n4 = temp;
    }
    else if (n3 > n5)
    {
        temp = n3;
        n3 = n5;
        n5 = temp;
    }
    else if (n3 > n6)
    {
        temp = n3;
        n3 = n6;
        n6 = temp;
    }
    else if (n3 > n7)
    {
        temp = n3;
        n3 = n7;
        n7 = temp;
    }
    else if (n3 > n8)
    {
        temp = n3;
        n3 = n8;
        n8 = temp;
    }
    else if (n3 > n9)
    {
        temp = n3;
        n3 = n9;
        n9 = temp;
    }
    else if (n3 > n10)
    {
        temp = n3;
        n3 = n10;
        n10 = temp;

    }
    else if (n4 > n5)
    {
        temp = n4;
        n4 = n5;
        n5 = temp;
    }
    else if (n4 > n6)
    {
        temp = n4;
        n4 = n6;
        n6 = temp;
    }
    else if (n4 > n7)
    {
        temp = n4;
        n4 = n7;
        n7 = temp;
    }
    else if (n4 > n8)
    {
        temp = n4;
        n4 = n8;
        n8 = temp;
    }
    else if (n4 > n9)
    {
        temp = n4;
        n4 = n9;
        n9 = temp;
    }
    else if (n4 > n10)
    {
        temp = n4;
        n4 = n10;
        n10 = temp;

    }
    else if (n5 > n6)
    {
        temp = n5;
        n5 = n6;
        n6 = temp;
    }
    else if (n5 > n7)
    {
        temp = n5;
        n5 = n7;
        n7 = temp;
    }
    else if (n5 > n8)
    {
        temp = n5;
        n5 = n8;
        n8 = temp;
    }
    else if (n5 > n9)
    {
        temp = n5;
        n5 = n9;
        n9 = temp;
    }
    else if (n5 > n10)
    {
        temp = n5;
        n5 = n10;
        n10 = temp;
    }
    else if (n6 > n7)
    {
        temp = n6;
        n6 = n7;
        n7 = temp;
    }
    else if (n6 > n8)
    {
        temp = n6;
        n6 = n8;
        n8 = temp;
    }
    else if (n6 > n9)
    {
        temp = n6;
        n6 = n9;
        n9 = temp;
    }
    else if (n6 > n10)
    {
        temp = n6;
        n6 = n10;
        n10 = temp;
    }
    else if (n7 > n8)
    {
        temp = n7;
        n7 = n8;
        n8 = temp;
    }
    else if (n7 > n9)
    {
        temp = n7;
        n7 = n9;
        n9 = temp;
    }
    else if (n7 > n10)
    {
        temp = n7;
        n7 = n10;
        n10 = temp;
    }
    else if (n8 > n9)
    {
        temp = n8;
        n8 = n9;
        n9 = temp;
    }
    else if (n8 > n10)
    {
        temp = n8;
        n8 = n10;
        n10 = temp;
    }
    else if (n9 > n10)
    {
        temp = n9;
        n9 = n10;
        n10 = temp;
    }
    else
    {
        k = false;
    }

    if (!k)
    {
        result = -1;
    }
    else
    {

        Console.Write(n10);
        Console.Write(n9);
        Console.Write(n8);
        Console.Write(n7);
        Console.Write(n6);
        Console.Write(n5);
        Console.Write(n4);
        Console.Write(n3);
        Console.Write(n2);
        Console.Write(n1);
    }
    result = int.Parse(Console.ReadLine());
    
}
return result;


Console.WriteLine(result);