using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tring
{
    class Program
    {
        static void Main(string[] args)
        {
            Random RandomGen = new Random();

            int sampleSize = 10000000;

            int succes = 0;
            int fail = 0;

            int enchant = 0;




            for (int i = 1; i < sampleSize; i++)
            {

                enchant = 0;

                if (i % 100000 == 0)
                {
                    Console.WriteLine((double)succes / i);
                }

                for (int x = 0; x < 48; x++)
                {
                    if (enchant == 0)
                    {
                        if (RandomGen.NextDouble() < 0.8)
                        {
                            enchant++;
                           // Console.WriteLine("Upgrade to: 1");
                        }
                    }
                    else if (enchant == 1)
                    {
                        if (RandomGen.NextDouble() < 0.4)
                        {
                            enchant++;
                           // Console.WriteLine("Upgrade to: 2");
                        }
                        else
                        {
                            enchant--;
                            //Console.WriteLine("Downgrade to: 0");
                        }
                    }
                    else if (enchant == 2)
                    {
                        if (RandomGen.NextDouble() < 0.05)
                        {
                            succes++;
                            //Console.WriteLine("Upgrade to: 3!!!!");
                            break;
                        }
                        else
                        {
                            enchant--;
                            //Console.WriteLine("Downgrade to: 1");
                        }
                    }
                }
            }

            Console.WriteLine(succes / sampleSize);
            Console.ReadKey();

        }
    }
}
