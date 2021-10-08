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
    }
}
