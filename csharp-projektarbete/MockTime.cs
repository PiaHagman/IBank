using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace csharp_projektarbete
{
    class MockTime : ITime
    {
        DateTime _timeUsedForTests = DateTime.Now;

        public DateTime Now()
        {
            return _timeUsedForTests;
        }

        public void SetTimeTo (DateTime givenTime)
        {
            _timeUsedForTests = givenTime;
        }

    }
}
