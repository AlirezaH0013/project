using System;
using ConsoleApp4.servises;
//فراخوانیه کلاس سرویس
servises servis = new servises();

//مشخص کردن آرایه اولیه و آرایه هدف براسی بازی
int[] array = { 1, 2, 3, 4, 5 };
int[] target = { 4, 5, 1, 2, 3 };
//چاپ آرایه اولیه و آرایه هدف در ابتدا برای دیدن کاربر
Console.WriteLine("Array Rotation Game!");
Console.WriteLine("Initial Array: ");
servis.PrintArray(array);
Console.WriteLine("Target Array: ");
servis.PrintArray(target);
//تعیین یک متغیر منطقی بولین برای تعیین هدف برای کاربر
bool isGoalAchieved = false;
//ایجاد یک حلقه که تا زمانی که داده های ورودی مخالف آرایه هدف باشه این لوپ ادامه داشته باشد
while (!isGoalAchieved)
{
    //چاپ و گرفتن جهت حرکت و تعداد خونه های حرکت برای حرکت آرایه
    Console.WriteLine("\nEnter your move (rotation direction and steps):");
    Console.Write("Direction (left/right): ");
    string direction = Console.ReadLine().ToLower();

    Console.Write("Number of steps to rotate: ");
    // ایجات یک متغییر برای گرفتن تعداد خونه های حرکت آرایه و ایجاد یک شرط 
    //در این شرط گفته میشود که عدد گرفته شده اگر از نوع اینت نبود و یا عدد ورودی کوچک تر مساوی 0 باشد به سر حلقه برگردد
    int steps;
    if (!int.TryParse(Console.ReadLine(), out steps) || steps <= 0)
    {
        Console.WriteLine("Please enter a valid number of steps.");
        continue;
    }
    // در اینجا شرط میگذاریم که اگر کاربر لفت را انتخاب کرد برای او چرخش آرایه از سمت چپ صورت گیرد
    if (direction == "left")
    {
        // در اینجا از کلاس سرویس متد چرخش به سمت چپ را اجرا کند
        servis.RotateLeft(array, steps);
    }
    // و در اینجا شرط میگذاریم که اگر رایت را انتخاب کرد از کلاس سرویس متد چرخش به سمت راست فراخوانی شود و آرایه به سمت راست بچرخد
    else if (direction == "right")
    {
        servis.RotateRight(array, steps);
    }

    // و اگر غیر از شرط های پیش بود اکسپشن تولید کرده برای کاربر اخطار دهد و به اول حلقه برگردد 
    else
    {
        Console.WriteLine("Invalid direction. Please choose 'left' or 'right'.");
        continue;
    }
    //در صورت همخوانی آرایه با آرایه هدف در ابتدا آرایه را نمایش داده و برد بازیکن را اعلام میکند
    Console.WriteLine("\nCurrent Array: ");
    servis.PrintArray(array);

    isGoalAchieved = servis.IsGoalAchieved(array, target);
}

Console.WriteLine("\nCongratulations! You've achieved the target configuration.");








