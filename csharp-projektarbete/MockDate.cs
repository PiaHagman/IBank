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
       int _yearUsedForTests;

        public MockDate()
        {
            _yearUsedForTests = _dateUsedForTests.Year;
        }

        public DateTime Today()
        {
            return _dateUsedForTests;
        }

        public int Year()
        {
            return _yearUsedForTests;
        }

        public void SetYearTo(DateTime givenDate)
        {
            _yearUsedForTests = givenDate.Year;
        }
        public void SetDateTo (DateTime givenDate)
        {
            _dateUsedForTests = givenDate;
        }

    }
}
