using System;
using System.Linq;

namespace TrieTree {
    public class TrieTree {
        private TrieTreeNode root;

        public TrieTree() {
            root = new TrieTreeNode ();
        }

        public void Insert (string word) {
            if (word == null) {
                return;
            }

            char[] str = word.ToArray ();
            TrieTreeNode node = root;
            node.pass++;
            int path = 0;
            for (int i = 0; i < str.Length;i++)
            {
                path = str[i] - 'a';
                if(node.Nexts[path]==null)
                {
                    node.Nexts[path] = new TrieTreeNode();
                }
                node = node.Nexts[path];
                node.pass++;
            }
            node.end++;
        }

        public void Delete(string word)
        {
            if (Search(word) != 0)
            {
                char[] chs = word.ToCharArray();
                var node = root;
                node.pass--;
                int path = 0;
                for (int i = 0; i < chs.Length; i++)
                {
                    path = chs[i] - 'a';
                    if (--node.Nexts[path].pass == 0)
                    {
                        node.Nexts[path] = null;
                        return;
                    }
                    node = node.Nexts[path];
                }
                node.end--;
            }
        }

        public int Search(string word)
        {
            if (word == null)
                return 0;

            char[] chs = word.ToCharArray();
            var node = root;
            int index = 0;

            for(var i = 0; i < chs.Length; i++)
            {
                index = chs[i] - 'a';
                if (node.Nexts[index] == null)
                    return 0;
                node = node.Nexts[index];
            }
            return node.end;
        }

        public int PrefixNumber(string pre)
        {
            if (pre == null)
                return 0;

            char[] chs = pre.ToCharArray();
            var node = root;
            int index = 0;
            for (var i = 0; i < chs.Length; i++)
            {
                index = chs[i] - 'a';
                if (node.Nexts[index] == null)
                    return 0;
                node = node.Nexts[index];
            }

            return node.pass;
        }
        


    }

    public class TrieTreeNode {
        public int pass { get; set; }

        public int end { get; set; }

        public TrieTreeNode[] Nexts { get; set; } = new TrieTreeNode[26];
    }
}