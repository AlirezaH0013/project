using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ایجاد یک فضای نام 
namespace ConsoleApp4.servises
{
    //ایجاد یک کلاس از نوع دسترسی آراد در برنامه با نام سرویس
    public class servises
    {
        //ایجاد یک متد بدون مقدار بازگشتی و دارای پارامتر ورودی برای متد حرکت به سمت راست 

        public void RotateLeft(int[] array, int steps)
        {
            // چک کردن تمام خانه های آرایه برای چک مقداری که به عنوان ورودی به برنامه میدهیم مثلا اگر تعداد جهشی که ما مشخص میکنیم بیشتر از تعداد خانه های آرایه باشد 
            //مقدار ورودی را گرفته تقسیم بر تعداد خانه های آرایه میکند و به اندازه باقی مانده تقسیم جابه جا میکند
            int length = array.Length;
            steps = steps % length;
            int[] temp = new int[steps];
            // در اینجا خانمه هاید آرایه را به تعدادی که میدهیمیکی یکی برایمان کپی میکند مثل یک مار تمام خانه های آرایخه با هم جابهجا میشوند
            Array.Copy(array, 0, temp, 0, steps);

            Array.Copy(array, steps, array, 0, length - steps);


            Array.Copy(temp, 0, array, length - steps, steps);
        }
        // عین توضیحاتی که برای متد چپ دادیم برای متد راست هم صادق است
        public void RotateRight(int[] array, int steps)
        {
            int length = array.Length;
            steps = steps % length;
            int[] temp = new int[steps];


            Array.Copy(array, length - steps, temp, 0, steps);


            Array.Copy(array, 0, array, steps, length - steps);


            Array.Copy(temp, 0, array, 0, steps);
        }
        // در اینجا متد چاپ آرایه را داریم
        public void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //در اینجا هم متد بر است یعنی چک میکند اگر آرایه اولیه با آرایه هدف یکی شود در خروجی پیام برد را برای مخاطب چاپ میکند
        public bool IsGoalAchieved(int[] array, int[] target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != target[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
