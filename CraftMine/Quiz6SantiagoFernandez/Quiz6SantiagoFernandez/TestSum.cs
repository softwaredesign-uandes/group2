using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz6SantiagoFernandez
{
    class TestSum
    {

        public int sum(string listOfNumbers, char delimeter)
        {
            string[] numberList = listOfNumbers.Split(delimeter);
            int answer = 0;
            foreach (string number in numberList){
                int numberINT = Convert.ToInt32(number);
                if (numberINT >= 0)
                {
                    answer += numberINT;
                }
            }
            return answer;
        }
    }
}
