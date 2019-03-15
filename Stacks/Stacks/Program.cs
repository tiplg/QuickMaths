using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Random RandomGen = new Random();
            int samplesize = 100000;

            double basePercent = 0.02;
            double stackPercent = 0.002;

            int startingFailstacks = 0;
            int failstacks = startingFailstacks;

            int numberOfCrafts = 0;
            
            int downgradeNeeded = 0;
            int failCount = 0;

            for (int x = 0; x <= 50; x++)
            {
                failstacks = startingFailstacks;

                numberOfCrafts = 0;
               
                downgradeNeeded = 0;
                failCount = 0;
  
                failstacks = 0;

                for (int i = 0; i < samplesize; i++)
                {
                    while (failstacks < x)
                    {
                        if (RandomGen.NextDouble() < (basePercent + (stackPercent * failstacks)))
                        {
                            // succes
                            downgradeNeeded++;
                            failstacks = startingFailstacks;
                        }
                        else
                        {
                            //fail
                            failCount++;
                            failstacks++;
                        }

                        numberOfCrafts++;
                    }
                    //stack complete
                    failstacks = startingFailstacks;

                }
                //Console.WriteLine("Succes: " + succesCount.ToString() + " failed: " + failCount.ToString() + " persentage: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%  maxfailstacks: " + maxFailstack.ToString());

                Console.WriteLine("Failstacks: " + x.ToString() + "\tSucces: " + string.Format("{0:0.00}", (1-(double)downgradeNeeded / (samplesize+downgradeNeeded)) * 100) + "\t craftsNeeded " + string.Format("{0:0.00}", (double)numberOfCrafts / samplesize) + "\t downgrades Needed: " + string.Format("{0:0.00}", (double)downgradeNeeded / samplesize));
            }

            Console.ReadKey();


        }
    }
}
