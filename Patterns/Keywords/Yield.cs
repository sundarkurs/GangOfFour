using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Keywords
{
    public class Yield
    {
        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;

                if(result == 128)
                {
                    yield break;
                }

                yield return result;
            }
        }

        public static void Run()
        {
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }

        //static void Main()
        //{
        //    Run();
        //}
        
    }

    
}
