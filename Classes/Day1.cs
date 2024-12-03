namespace c_sharp
{
   public class Day1
   {
      static List<int> numbersA = new List<int>();
      static List<int> numbersB = new List<int>();

      // Main entry point
      public void Run()
      {
         int result = Parse_Input("DataFiles/Data1.txt");
         Console.WriteLine(result);
      }

      // Parse the input file, process each line, and return the result
      static int Parse_Input(string path)
      {
         List<string> resultA = [];
         List<string> resultB = [];
         var file_contents = File.ReadLines(path);

         foreach (var line in file_contents)
         {
            string[] splitLine = line.Split("   ");
            resultA.Add(splitLine[0]);
            resultB.Add(splitLine[1]);
         }

         numbersA = ParseToInt(resultA.ToArray());
         numbersB = ParseToInt(resultB.ToArray());

         numbersA.Sort();
         numbersB.Sort();

         return CountAndMultiply(numbersA, numbersB);

      }
      static List<int> ParseToInt(string[] input)
      {
         List<int> ints = new List<int>();

         foreach (string line in input)
         {
            ints.Add(int.Parse(line));
         }

         return ints;
      }

      static int CountAndMultiply(List<int> a, List<int> b)
      {
         int result = 0;
         for (int i = 0; i < a.Count; i++)
         {
            int count = 0;
            for (int j = 0; j < b.Count; j++)
            {
               if (b[j] == a[i])
                  count += 1;
            }

            result += a[i] * count;
         }
         return result;
      }

      static int CompareAndAdd(List<int> a, List<int> b)
      {
         int result = 0;
         for (int i = 0; i < a.Count; i++)
         {
            int difference = Math.Abs(a[i] - b[i]);

            result += difference;
         }

         return result;
      }
   }
}
