using System;
using System.Collections.Generic;
using System.Text;

namespace ViolenceRecursive
{
    public class PrintAllSubsquences
    {
        public static void Process1(char[] str,int index,List<string> ans,string path)
        {
            if (index == str.Length)
            {
                ans.Add(path);
                return;
            }

            string no = path;
            Process1(str, index + 1, ans, no);
            string yes = path + str[index].ToString();
            Process1(str, index + 1, ans, yes);
        }
    }
}
