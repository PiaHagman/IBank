using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace csharp_projektarbete
{
    class MockDate : IDate
    {
        DateTime _dateUsedForTests = DateTime.Today;

        public DateTime Today()
        {
            return _dateUsedForTests;
        }

        public void SetTimeTo (DateTime givenDate)
        {
            _dateUsedForTests = givenDate;
        }

    }
}
