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
            //DateTime date = new DateTime(2018, 08, 20, 8, 59, 59);
            
            

            string message = "";

            if (_time.date.DayOfWeek == DayOfWeek.Saturday || _time.date.DayOfWeek == DayOfWeek.Sunday)
            {
                message= "Bon week-end "+ Environment.UserName;

            }
            else
            {
                if (_time.date.DayOfWeek == DayOfWeek.Monday && _time.date.Hour < startMorning)
                {
                    message = "Bon week-end " + Environment.UserName;

                }
                else
                {
                    if (_time.date.Hour >= startMorning && _time.date.Hour < startAfternoon)
                    {
                        message = "Bonjour " + Environment.UserName;
                    }
                    if (_time.date.Hour >= startAfternoon && _time.date.Hour < startEvenig)
                    {
                        message = "Bon après-midi " + Environment.UserName;
                    }
                    if (_time.date.Hour >= startEvenig)
                    {
                        message = "Bonsoir " + Environment.UserName;

                    }

                }
            }

            return message;
        }
    }
}
