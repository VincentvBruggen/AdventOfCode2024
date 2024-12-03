using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp
{
   public class Day2
   {

      public void Run()
      {
         string result = Parse_Input("DataFiles/Data2.txt");

         Console.WriteLine(result);
      }

      static string Parse_Input(string path)
      {
         List<string[]> levels = new List<string[]>();

         string[] fileContent = File.ReadAllLines(path);

         for (int i = 0; i < fileContent.Length; i++)
         {
            string[] level = fileContent[i].Split(new[] { ' ', '\t' });

            levels.Add(level);
         }

         return Solve(levels);
      }

      static string Solve(List<string[]> input)
      {
         int safeReports = 0;
         foreach (string[] report in input)
         {
            List<int> numbers = new List<int>();
            bool isIncreasing = false;
            bool isDecreasing = false;

            string reportFull = "";
            foreach (string key in report)
            {
               reportFull += key+" ";
               int num = int.Parse(key);

               numbers.Add(num);
            }

            if (numbers[0] < numbers[1])
               isIncreasing = true;
            else
               isDecreasing = true;


            bool isUnsafe = false;
            bool hasRemoved = false;
            int lastRemovedIndex = 0;
            for (int x = 0; x < numbers.Count; x++)
            {
               for (int i = 0; i < numbers.Count; i++)
               {
                  if (isIncreasing && i < numbers.Count - 1)
                  {
                     int difference = numbers[i + 1] - numbers[i];

                     if (difference > 3 || difference <= 0)
                     {
                        if (x == numbers.Count-1)
                        {
                           isUnsafe = true;
                           break;
                        }
                     }
                     if (i > lastRemovedIndex || i == 0)
                     {
                        numbers.RemoveAt(i); 
                        lastRemovedIndex = i;
                        hasRemoved = true;
                     }
                  }
                  else if (isDecreasing && i < numbers.Count - 1)
                  {
                     int difference = numbers[i] - numbers[i + 1];

                     if (difference > 3 || difference <= 0)
                     {
                        if (x == numbers.Count - 1)
                        {
                           isUnsafe = true;
                           break;
                        }
                        if (i > lastRemovedIndex || i == 0)
                        {
                           numbers.RemoveAt(i);
                           lastRemovedIndex = i;
                           hasRemoved = true;
                        }
                     }
                  }
               }
            }
            if (!isUnsafe)
            {
               Console.WriteLine(reportFull+"Safe");
               safeReports += 1;
            }
         }
            return safeReports.ToString();
      }
   }
}
