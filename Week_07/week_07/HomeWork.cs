using System.Collections.Generic;

namespace week_07
{
    public class HomeWork
    {
        //208. 实现 Trie (前缀树)
        public class Trie
        {
            private Trie[] next;
            private bool isEnd;
            /** Initialize your data structure here. */
            public Trie()
            {
                next = new Trie[26];
                isEnd = false;
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var node = this;
                foreach (var w in word)
                {
                    if (node.next[w - 'a'] == null) node.next[w - 'a'] = new Trie();
                    node = node.next[w - 'a'];
                }
                node.isEnd = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var node = this;
                foreach (var w in word)
                {
                    node = node.next[w - 'a'];
                    if (node == null) return false;
                }
                return node.isEnd;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var node = this;
                foreach (var w in prefix)
                {
                    node = node.next[w - 'a'];
                    if (node == null) return false;
                }
                return true;
            }
        }


        //22. 括号生成
        public IList<string> GenerateParenthesis(int n)
        {
            var ls = new List<string>();
            Helper(n, 1, 0, "(", ls);
            return ls;
        }

        public void Helper(int n,int left,int right,string brackets,IList<string> ls){
            if(left==n && right==n) ls.Add(brackets);

            if(left<n) Helper(n,left+1,right,brackets+"(",ls);
            if(right<left)  Helper(n,left,right+1,brackets+")",ls);
        }
    
    }
}