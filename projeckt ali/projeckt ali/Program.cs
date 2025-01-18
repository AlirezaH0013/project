
// الگوریتمی بنویسید که حقوق کارگری را دریافت کرده ده درصد از بیمه و پنج درصد از حق مسکن کم بکند و نمایش دهد
Console.Write("Hoghogh:");
decimal A = decimal.Parse(Console.ReadLine());
decimal B = A * 10 / 100;
decimal M = A * 5 / 100;
decimal S = M + B;
decimal H = A - S;
Console.WriteLine($"Hoghoogh:{H}");
Console.WriteLine($"bymeh:{B}");
Console.WriteLine($"maskan:{M}");

//الگوریتمی بنویسید که یک زمان بر حسب ثانیه دریافت کرده ساعت دقیقه و ثانیه آن را محاسبه کند
Console.Write("Enter Time:");
int T = int.Parse(Console.ReadLine());
int H = T / 3600;
Console.WriteLine(H);
int R = T - 3600 * H;
int M = R / 60;
Console.WriteLine(M);
int S = R - 60 * M;
Console.WriteLine(S);

//الگوریتمنی بنویسید که اعداد روج دورقمی را حساب کند
for (int i = 10; i <= 98; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}

//الگوریتمی بنویسید که آعداد فرد قبل از ورودی کاربر را نمایش دهد
Console.Write("Enter a number:");
int n = int.Parse(Console.ReadLine());
for (int i = 0; i <= n; i++)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
    }
}

//الگوریتمی بنویسید که اعداد زوج بین 1000تا 2000 را چاپ کرده و با هم جمع کند
for (int i = 1000; i <= 2000; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);

        int sum = +i;
        Console.WriteLine(sum);

    }

}