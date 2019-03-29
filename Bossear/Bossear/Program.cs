using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossear
{
    class Program
    {
        static void Main(string[] args)
        {
            Random RandomGen = new Random();
            int sampleSize = 1000000;

            double basePercent = 0.1429;
            double stackPercent = 0.01425;
            double succesPrecent = 0;

            int startingFailstacks = 0;
            int failstacks = startingFailstacks;

            int succesCount = 0;
            int failCount = 0;
            int totalCrafts = 0;

            bool upgraded = false;

            for (int x = 0; x <= 60; x++)
            {
                startingFailstacks = x;
                failstacks = startingFailstacks;

                totalCrafts = 0;
                succesCount = 0;
                failCount = 0;
                failstacks = 0;

                for (int i = 0; i < sampleSize; i++)
                {
                    upgraded = false;
                    while (!upgraded)
                    {
                        totalCrafts++;
                        succesPrecent = basePercent + (stackPercent * failstacks);

                        if (succesPrecent > 0.7) // hard cap soft cap
                        {
                            succesPrecent = 0.7;
                        }

                        if (RandomGen.NextDouble() < succesPrecent)
                        {
                            // succes
                            succesCount++;
                            failstacks = startingFailstacks;
                            upgraded = true;
                        }
                        else
                        {
                            //fail
                            failCount++;
                            failstacks++;
                        }
                    }
                }
                //Console.WriteLine("Succes: " + succesCount.ToString() + " failed: " + failCount.ToString() + " persentage: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%  maxfailstacks: " + maxFailstack.ToString());

                //Console.WriteLine("Failstacks: " + startingFailstacks.ToString() + "\tSucces: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%\tmaxfailstacks: " + maxFailstack.ToString() + "\tBaseItem per +1: " + string.Format("{0:0.00}", (double)baseItemsUsed / plusoneCreated));

                Console.WriteLine(startingFailstacks.ToString() + ", " + string.Format("{0:0.00}", (double)failCount / succesCount) + ", " + string.Format("{0:0.000}", (double)succesCount / totalCrafts));

            }

            Console.ReadKey();
        }
    }
}

