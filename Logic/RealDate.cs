using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RealDate : IDate
    {
        public DateTime Today()
        {
            return DateTime.Today;
        }

        public int Year()
        {
            int year = Convert.ToInt32(DateTime.Today.Year);
            return year;
        }
    }
}
