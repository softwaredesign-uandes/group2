using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz6FranciscoAlvarez
{
    class Mathemagic
    {
        public int Add(string input)
        {
            int result = 0;
            string[] numberArray = input.Split(',');
            foreach(string stringNumber in numberArray)
            {
                int number = Convert.ToInt32(stringNumber);
                if (number >= 0)
                {
                    result = result + number;
                }
            }
            return result;
        }

    }
}
