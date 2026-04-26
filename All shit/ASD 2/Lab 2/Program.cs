using System;

class Test
{
    static void Main()
{

Console.Write("Введіть кількість елементів n: ");
if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
{
    MyList list = new MyList();
    list.Create(n);
}
else
{
    Console.WriteLine("Помилка: n має бути числом > 0");
}
}
}