using System;
using System.Collections.Generic;

namespace week_08
{
    public class HomeWork
    {
        //191. 位1的个数
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n > 0)
            {
                n = (n & (n - 1));
                count++;
            }
            return count;
        }

        //231. 2的幂
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        //190. 颠倒二进制位
        public uint reverseBits(uint n)
        {
            return 1;
        }

        //1122. 数组的相对排序
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] ans = new int[arr1.Length];
            int index = -1;

            int[] bucket = new int[1001];
            foreach (var item in arr1)
            {
                bucket[item]++;
            }

            foreach (var item in arr2)
            {
                while (bucket[item] > 0)
                {
                    ans[++index] = item;
                    --bucket[item];
                }
            }
            for (int i = 0; i < bucket.Length; ++i)
            {
                while (bucket[i] > 0)
                {
                    ans[++index] = i;
                    --bucket[i];
                }
            }
            return ans;
        }

        //242. 有效的字母异位词
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] arr = new int[26];

            for (int i = 0; i < s.Length; ++i)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }
            foreach (var item in arr)
            {
                if (item != 0) return false;
            }
            return true;
        }


        //146. LRU缓存机制
        #region LRU缓存机制
        public class LRUCache
        {
            public class DLinkedNode
            {
                public DLinkedNode() { }
                public DLinkedNode(int key, int val)
                {
                    this.key = key;
                    this.val = val;
                }
                public int val { get; set; }
                public int key { get; set; }
                public DLinkedNode Pre { get; set; }
                public DLinkedNode Next { get; set; }
            }

            private DLinkedNode head { get; set; }
            private DLinkedNode tail { get; set; }
            private Dictionary<int, DLinkedNode> dictionary;
            private int _capacity;

            public LRUCache(int capacity)
            {
                this._capacity = capacity;
                this.dictionary = new Dictionary<int, DLinkedNode>(capacity + 1);
                head = new DLinkedNode();
                tail = new DLinkedNode();
                head.Next = tail;
                tail.Pre = head;
            }

            public int Get(int key)
            {
                if (!dictionary.ContainsKey(key)) return -1;
                MoveToHead(dictionary[key]);
                return dictionary[key].val;
            }

            public void Put(int key, int val)
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].val = val;
                    MoveToHead(dictionary[key]);
                }
                else
                {
                    DLinkedNode node = new DLinkedNode(key, val);
                    dictionary.Add(key, node);
                    AddToHead(node);
                    if (dictionary.Count > _capacity)
                    {
                        RemoveTail();
                    }
                }
            }
            private void AddToHead(DLinkedNode node)
            {
                node.Pre = this.head;
                node.Next = this.head.Next;

                this.head.Next.Pre = node;
                this.head.Next = node;
            }
            private void RemoveNode(DLinkedNode node)
            {
                node.Pre.Next = node.Next;
                node.Next.Pre = node.Pre;
            }
            private void MoveToHead(DLinkedNode node)
            {
                RemoveNode(node);
                AddToHead(node);
            }
            private void RemoveTail()
            {
                var n = tail.Pre;
                RemoveNode(n);
                dictionary.Remove(n.key);
            }

            // private void RemoveTail()
            // {
            //     var temp = tail.Pre;
            //     RemoveNode(temp);
            //     dictionary.Remove(temp.key);
            // }
            // private void MoveToHead(DLinkedNode node)
            // {
            //     RemoveNode(node);
            //     AddToHead(node);
            // }

            // private void RemoveNode(DLinkedNode node)
            // {
            //     node.Pre.Next = node.Next;
            //     node.Next.Pre = node.Pre;
            // }

            // private void AddToHead(DLinkedNode node)
            // {
            //     head.Next.Pre = node;
            //     node.Next = head.Next.Pre;
            //     head.Next = node;
            //     node.Pre = head;
            // }
        }
        #endregion

        //56. 合并区间
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length < 2) return intervals;

            Array.Sort(intervals, (x, y) => x[0] - y[0]);

            var ans = new List<int[]>(intervals.Length);
            foreach (var item in intervals)
            {
                if (ans.Count == 0 || ans[^1][1] < item[0]) ans.Add(item);
                else ans[^1][1] = Math.Max(ans[^1][1], item[1]);
            }
            return ans.ToArray();
        }
    }
}