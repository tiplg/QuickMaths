using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Tijmen\Desktop\stddiv.csv";
            string tempstring = "";

            Random RandomGen = new Random();
            int samplesize = 500000;

            double basePercent = 0.02;
            double stackPercent = 0.002;

            int startingFailstacks = 0;
            int failstacks = startingFailstacks;

            int totalNumberOfCrafts = 0;
            int numberOfCrafts = 0;
            
            int downgradeNeeded = 0;
            int failCount = 0;

            for (int x = 40; x <= 60; x++)
            {
                failstacks = startingFailstacks;

                totalNumberOfCrafts = 0;
               
                downgradeNeeded = 0;
                failCount = 0;
  
                failstacks = 0;

                for (int i = 0; i < samplesize; i++)
                {
                    failstacks = startingFailstacks;
                    numberOfCrafts = 0;

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

                        totalNumberOfCrafts++;
                        numberOfCrafts++;
                    }
                    //stack complete

                    /*
                    tempstring += numberOfCrafts.ToString() + ",\n";

                    if (i%10000 == 0)
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(tempstring);
                            tempstring = "";
                            Console.WriteLine(i);
                        }
                    }
                    */

                }
                //Console.WriteLine("Succes: " + succesCount.ToString() + " failed: " + failCount.ToString() + " persentage: " + string.Format("{0:0.00}", (double)succesCount / totalCrafts * 100) + "%  maxfailstacks: " + maxFailstack.ToString());

                //Console.WriteLine("Failstacks: " + x.ToString() + "\tSucces: " + string.Format("{0:0.00}", (1-(double)downgradeNeeded / (samplesize+downgradeNeeded)) * 100) + "\t craftsNeeded " + string.Format("{0:0.00}", (double)numberOfCrafts / samplesize) + "\t downgrades Needed: " + string.Format("{0:0.00}", (double)downgradeNeeded / samplesize));

                Console.WriteLine(x.ToString() + " ," + string.Format("{0:0.00}", (1 - (double)downgradeNeeded / (samplesize + downgradeNeeded)) * 100) + " ," + string.Format("{0:0.000}", (double)totalNumberOfCrafts / samplesize) + " ," + string.Format("{0:0.000}", (double)downgradeNeeded / samplesize));

            }

            Console.ReadKey();


        }
    }
}
