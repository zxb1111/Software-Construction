using System;
using System.Collections.Generic;
using System.Linq;

namespace AlarmDemo
{
    // 闹钟事件参数
    class AlarmEventArgs : EventArgs
    {
        public DateTime AlarmTime { get; }

        public AlarmEventArgs(DateTime time)
        {
            AlarmTime = time;
        }
    }

    // Tick事件参数（带剩余时间）
    class TickEventArgs : EventArgs
    {
        public DateTime Now { get; }
        public TimeSpan? TimeToNextAlarm { get; }

        public TickEventArgs(DateTime now, TimeSpan? timeToNext)
        {
            Now = now;
            TimeToNextAlarm = timeToNext;
        }
    }

    class AlarmClock
    {
        public event EventHandler<TickEventArgs> Tick;
        public event EventHandler<AlarmEventArgs> Alarm;
        public event EventHandler AllAlarmsFinished;

        private System.Timers.Timer timer;

        private List<DateTime> alarmTimes = new List<DateTime>();
        private HashSet<DateTime> triggered = new HashSet<DateTime>();

        public AlarmClock()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
        }

        // 添加闹钟（支持运行中添加）
        public void AddAlarm(DateTime time)
        {
            alarmTimes.Add(time);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            // 找下一个未触发的闹钟
            var nextAlarm = alarmTimes
                .Where(t => !triggered.Contains(t) && t > now)
                .OrderBy(t => t)
                .FirstOrDefault();

            TimeSpan? remaining = nextAlarm == default ? (TimeSpan?)null : nextAlarm - now;

            // 触发 Tick
            Tick?.Invoke(this, new TickEventArgs(now, remaining));

            // 检查每个闹钟
            foreach (var time in alarmTimes)
            {
                if (!triggered.Contains(time) && now >= time)
                {
                    triggered.Add(time);
                    Alarm?.Invoke(this, new AlarmEventArgs(time));
                }
            }

            // 是否全部完成
            if (triggered.Count == alarmTimes.Count && alarmTimes.Count > 0)
            {
                AllAlarmsFinished?.Invoke(this, EventArgs.Empty);
                Stop();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();

            // 添加闹钟
            clock.AddAlarm(DateTime.Now.AddSeconds(5));
            clock.AddAlarm(DateTime.Now.AddSeconds(10));

            // Tick事件
            clock.Tick += (sender, e) =>
            {
                if (e.TimeToNextAlarm.HasValue)
                {
                    Console.WriteLine($"当前时间：{e.Now:T}，下一个闹钟：{e.TimeToNextAlarm.Value.Seconds} 秒");
                }
                else
                {
                    Console.WriteLine($"当前时间：{e.Now:T}，没有未触发的闹钟");
                }
            };

            // Alarm事件
            clock.Alarm += (sender, e) =>
            {
                Console.WriteLine($"闹钟响了：{e.AlarmTime:T}");
            };

            // 所有结束事件
            clock.AllAlarmsFinished += (sender, e) =>
            {
                Console.WriteLine("所有闹钟已结束。");
            };

            clock.Start();

            Console.WriteLine("闹钟已启动。");

            // 模拟运行中添加新闹钟
            Console.ReadLine();
            clock.AddAlarm(DateTime.Now.AddSeconds(5));
            Console.WriteLine("新增一个闹钟（5秒后）");

            Console.ReadLine();
        }
    }
}
