using System;

namespace Homework3_2
{
    using System;
    /*******发布器类*********/
    //倒计时类
    public class Countdown
    {
        public int count;//倒计时秒数

        public delegate void CountdownDelegate();

        public event CountdownDelegate countdown;
        public virtual void OnCountdown(int count)
        {
            for (; count > 0; count--)
            {
                if (count == 1) { countdown();/*事件触发，闹钟响铃*/ }
                else
                {
                    Console.WriteLine("Tick! Tock!");/*闹钟滴答*/
                    Thread.Sleep(1000);
                }
            }
        }
        public void CountdownTest()
        {
            Console.WriteLine("Countdown to ( ) seconds.");
            count = Convert.ToInt32(Console.ReadLine());
            OnCountdown(count);
        }
    }

    //闹钟类
    class Alarm
    {
        public String hour, minute, second;
        public delegate void AlarmDelegate();
        public event AlarmDelegate alarm;
        public virtual void OnAlarm()
        {
            while (true)
            {
                string T = DateTime.Now.ToLongTimeString().ToString();
                string[] time = T.Split(':');
                Console.WriteLine("{0}:{1}:{2}", time[0], time[1], time[2]);
                if (hour == time[0] && minute == time[1] && second == time[2])
                { alarm(); break; }/*触发事件响铃*/
                else
                {
                    Console.WriteLine("Tick! Tock!");/*闹钟滴答*/
                    Thread.Sleep(1000);
                }
            }

        }
        public void AlarmTest()
        {
            Console.WriteLine("What time do you want to order an alarm?");
            Console.WriteLine("Hour:");
            hour = Console.ReadLine();
            Console.WriteLine("Minute:");
            minute = Console.ReadLine();
            Console.WriteLine("Second:");
            minute = Console.ReadLine();
            OnAlarm();
        }
    }
    /********订阅器类**********/
    public class subscribEvent
    {
        public void P()
        {
            Console.WriteLine("Time's up!");
            Console.WriteLine("Press ENTER to exit!");
            Console.ReadKey(); /* 回车继续 */
        }
    }
    /********触发*************/
    public class Program
    {
        public static void Main()
        {
            Countdown c = new Countdown();
            Alarm a = new Alarm();
            subscribEvent v = new subscribEvent();
            Console.WriteLine("Please select alarm mode :");
            Console.WriteLine("(1 countdown; 2 set the alarm)");
            int s = Convert.ToInt32(Console.ReadLine());
            switch (s)
            {
                case 1:
                    c.countdown += new Countdown.CountdownDelegate(v.P);
                    c.CountdownTest();
                    break;
                case 2:
                    a.alarm += new Alarm.AlarmDelegate(v.P);
                    a.AlarmTest();
                    break;
            }




        }
    }
}
