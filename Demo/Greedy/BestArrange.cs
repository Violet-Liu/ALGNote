using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Greedy
{
    public class BestArrange
    {
        

        public static int Process(Meet[] meets,int done,int timeLine)
        {
            if (meets.Length == 0)
                return done;

            int max = done;

            for(int i = 0; i < meets.Length; i++)
            {
                if (meets[i].Start >= timeLine)
                {
                    Meet[] next = CopyButExcept(meets, i);
                    max = Math.Max(max, Process(next, done + 1, meets[i].End));
                }
            }
            return max;
        }


        public static Meet[] CopyButExcept(Meet[] meets,int i)
        {
            Meet[] ans = new Meet[meets.Length - 1];
            int index = 0;
            for(int k = 0; k < meets.Length; k++)
            {
                if (k != i)
                {
                    ans[index++] = meets[k];
                }
            }
            return ans;
        }

        public static int BestArrange2(Meet[] meets)
        {
            Array.Sort(meets, new MeetComparator());
            int timeLine = 0;
            int ans = 0;

            for(int i = 0; i < meets.Length; i++)
            {
                if (timeLine <= meets[i].Start)
                {
                    ans++;
                    timeLine = meets[i].End;
                }
            }

            return ans;
        }

    }

    public class Meet
    {
        public int Start { get; set; }

        public int End { get; set; }

        public Meet(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }

    public class MeetComparator : IComparer<Meet>
    {
        public int Compare([AllowNull] Meet x, [AllowNull] Meet y)
        {
            return x.End - y.End;
        }
    }

}
