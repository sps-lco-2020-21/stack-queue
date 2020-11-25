using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues.App
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Q1 Shortest Knight's path between two squares 
             * First point: stack and queue questions that want "shortest" are generally queue-based 
             * 
             * there are several issues in this question: 
             * - generating the next squares
             * - representing the grid 
             * - counting the path length 
             * 
             * I'm going to give two approaches, 
             * - using a string to store the location and the step count to get there
             * - using a list of moves 
             * 
             * Both of these need a generator function - I'm going to introduce the IEnumerable type and yield return keyword combination 
             */
            Console.WriteLine(ShortestKnightsPath("A1", "E3"));
            Console.WriteLine(ShortestKnightsPathReport("A1", "G7"));
            // warning - this is slow! 
            Console.WriteLine(ShortestKnightsPathReport("A1", "M20", 21));
            Console.ReadKey();
        }

        static IEnumerable<string> KnightsMove(string location, int dimension)
        {
            // the expectation is that the location is a grid reference character:number meaning column:row A1 is top left, H8 is bottom right, A8 is bottom left.  
            // TODO this will break if we need more than 26 letters 
            int row;
            if (int.TryParse(location.Substring(1), out row) && char.IsUpper(location[0])) 
            {
                char column = location[0];
                foreach (int c in new List<int> { -2, -1, 1, 2 })
                {
                    foreach (int r in new List<int> { -2, -1, 1, 2 })
                    {
                        if (Math.Abs(c) == Math.Abs(r))
                            continue;

                        char newcolumn = (char)(column + c);
                        int newrow = row + r;

                        if (newcolumn >= 'A' && newcolumn < 'A' + dimension && newrow >= 1 && newrow <= dimension)
                        {
                            yield return string.Format("{0}{1}", newcolumn, newrow);
                        }
                    }
                }
            }
        }

        static int ShortestKnightsPath(string from, string to, int dimension = 8)
        {
            /* the string stored in the calculation will be of the form "CR(R)-P(P)"
                * C is a column character 
                * RR is a one or two digit row number 
                * - a dash
                * P is an integer representing path length
                */
            string initial = string.Format("{0}-0", from);
            Queue<string> q = new Queue<string>();
            q.Enqueue(initial);
            while (q.Count > 0)
            {
                string current = q.Dequeue();
                int dash = current.IndexOf("-");
                string location = current.Substring(0, dash);
                int generation = int.Parse(current.Substring(dash + 1));
                ++generation;
                foreach (string knight in KnightsMove(location, dimension))
                {
                    if (knight == to)
                        return generation;
                    string candidate = string.Format("{0}-{1}", knight, generation);
                    q.Enqueue(candidate);
                }
            }

            return -1;
        }
        static string ShortestKnightsPathReport(string from, string to, int dimension = 8)
        {
            Queue<IList<string>> q = new Queue<IList<string>>();
            q.Enqueue(new List<string> { from });
            while (q.Count > 0)
            {
                IList<string> head = q.Dequeue();
                foreach (string knight in KnightsMove(head.Last(), dimension))
                {
                    if (knight == to)
                    {
                        return string.Format("{0},{1} - {2} move{3}", string.Join(",", head), knight, head.Count, head.Count == 1 ? "" : "s");
                    }

                    IList<string> current = head.Select(c => c).ToList();
                    if (current.Contains(knight))
                        continue;

                    current.Add(knight);
                    q.Enqueue(current);
                }
            }
            return "no result - is that even possible?";
        }
    }
}