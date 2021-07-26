using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnionFind
{
    public class Sub
    {
        public string IdentityNo { get; set; }
        public string StudyNo { get; set; }

        public string GitNo { get; set; }
    }
    public class FindStudent
    {
        public static int MergeUsers(List<Sub> subs)
        {
            var sets = new UnionSet<Sub>(subs);
            var identityMap = new Dictionary<string, Sub>();
            var studyMap = new Dictionary<string, Sub>();
            var gitMap = new Dictionary<string, Sub>();

            subs.ForEach(t =>
            {
                if (identityMap.ContainsKey(t.IdentityNo))
                {
                    sets.Union(t, identityMap[t.IdentityNo]);
                }
                else
                {
                    identityMap.Add(t.IdentityNo, t);
                }

                if(studyMap.ContainsKey(t.StudyNo))
                {
                    sets.Union(t, studyMap[t.StudyNo]);
                }
                else
                {
                    studyMap.Add(t.StudyNo, t);
                }

                if(gitMap.ContainsKey(t.GitNo))
                {
                    sets.Union(t, gitMap[t.GitNo]);
                }
                else
                {
                    gitMap.Add(t.GitNo, t);
                }
            });

            return sets.SizeMap.Count();
        }
    }

}
