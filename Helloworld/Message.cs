using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    public class Message
    {
        private int startMorning;
        private int startAfternoon;
        private int startEvenig;
        private ITime _time;

        public Message(int morning, int afternoon, int evening)
            : this(new SystemTime(), morning, afternoon, evening)
        {
        }
        
        internal Message(ITime time, int morning, int afternoon, int evening)
        {
            _time = time;
            startMorning = morning;
            startAfternoon = afternoon;
            startEvenig = evening;
        }

        public string GetHelloMessage()
        {
            DateTime date = _time.date;

            string message = "";

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                message= "Bon week-end "+ Environment.UserName;

            }
            else
            {
                if (date.DayOfWeek == DayOfWeek.Monday && date.Hour < startMorning)
                {
                    message = "Bon week-end " + Environment.UserName;

                }
                else
                {
                    if (date.Hour >= startMorning && date.Hour < startAfternoon)
                    {
                        message = "Bonjour " + Environment.UserName;
                    }
                    if (date.Hour >= startAfternoon && date.Hour < startEvenig)
                    {
                        message = "Bon après-midi " + Environment.UserName;
                    }
                    if (date.Hour >= startEvenig)
                    {
                        message = "Bonsoir " + Environment.UserName;

                    }

                }
            }

            return message;
        }
    }
}
