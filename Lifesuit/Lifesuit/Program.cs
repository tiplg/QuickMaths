using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifesuit
{
    class Program
    {
        static void Main(string[] args)
        {
            Random RandomGen = new Random();
            int totalCrafts = 100000000;

            double basePercent = 0.3;
            double stackPercent = 0.03;
            double succesPrecent = 0;

            int startingFailstacks = 0;
            int failstacks = startingFailstacks;
            int maxFailstack = 0;

            int succesCount = 0;
            int failCount = 0;

            for (int x = 0; x <= 20; x++)
            {
                startingFailstacks = x;
                failstacks = startingFailstacks;
                maxFailstack = 0;

                succesCount = 0;
                failstacks = 0;


                for (int i = 0; i < totalCrafts; i++)
                {
                    succesPrecent = basePercent + (stackPercent * failstacks);
                    if (succesPrecent > 0.7)
                    {
                        succesPrecent = 0.7;
                    }


                    if (RandomGen.NextDouble() < succesPrecent)
                    {
                        // succes
                        succesCount++;
                        failstacks = startingFailstacks;

                    }
                    else
                    {
                        //fail
                        failCount++;
                        failstacks++;

                        if (failstacks > maxFailstack) maxFailstack = failstacks;
                    }



                }
                //Console.WriteLine("Succes: " + succesCount.ToString() + " failed: " + failCount.ToString() + " persentage: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%  maxfailstacks: " + maxFailstack.ToString());

                //Console.WriteLine("Failstacks: " + startingFailstacks.ToString() + "\tSucces: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%\tmaxfailstacks: " + maxFailstack.ToString() + "\tBaseItem per +1: " + string.Format("{0:0.00}", (double)baseItemsUsed / plusoneCreated));

                Console.WriteLine( startingFailstacks.ToString() + ", " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%, " + string.Format("{0:0.000}", (double)totalCrafts / succesCount));

            }

            Console.ReadKey();
        }
    }
}
