using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helloworld;

namespace UnitTestProjectHelloworld
{
    class FakeTime : ITime
    {

        public DateTime DateTimeToReturn { get ; set; }


        public DateTime date
        {
            get { return DateTimeToReturn ; }
        }
    }
}
