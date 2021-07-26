using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Greedy
{
    public class IPO
    {
        public static int FindMaximizedCaptital(int K,int W,int[] profits,int[] capitial)
        {
            PriorityQueue<Project> minCost = new PriorityQueue<Project>(new MinCostComparator());
            PriorityQueue<Project> maxProfites = new PriorityQueue<Project>(new MaxProfitComparator());

            for(int i = 0; i < profits.Length; i++)
            {
                minCost.Enqueue(new Project(profits[i], capitial[i]));
            }

            for (int i = 0; i < K; i++)
            {
                while (minCost.Count > 0 && minCost.Peek().Cost <= W)
                {
                    maxProfites.Enqueue(minCost.Dequeue());
                }

                if (maxProfites.Count == 0)
                    return W;

                W += maxProfites.Dequeue().Profit;
            }

            return W;
        }
    }

    public class Project
    {
        public int Profit { get; set; }

        public int Cost { get; set; }

        public Project(int p,int c)
        {
            Profit = p;
            Cost = c;
        }
    }

    public class MinCostComparator : IComparer<Project>
    {
        public int Compare([AllowNull] Project x, [AllowNull] Project y)
        {
            return x.Cost - y.Cost;
        }
    }

    public class MaxProfitComparator : IComparer<Project>
    {
        public int Compare([AllowNull] Project x, [AllowNull] Project y)
        {
            return y.Cost - x.Cost;
        }
    }
}
