using System;
using System.Collections.Generic;
using System.Linq;

namespace week_04
{
    public class HomeWoek
    {
        //860. 柠檬水找零 时间O(N) 空间O(1)
        public bool LemonadeChange(int[] bills)
        {
            int five = 0;
            int ten = 0;
            foreach (var item in bills)
            {
                if (item == 5) ++five;
                else if (item == 10)
                {
                    if (five > 0)
                    {
                        --five;
                        ++ten;
                    }
                    else return false;
                }
                else
                {
                    if (five > 0 && ten > 0)
                    {
                        --five;
                        --ten;
                    }
                    else if (five > 2)
                    {
                        five = five - 3;
                    }
                    else return false;
                }
            }
            return true;
        }

        //122. 买卖股票的最佳时机 II 时间O(N) 空间O(1)
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1) return 0;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; ++i)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }

        //455. 分发饼干 时间O(nlogn) n = Max(g.length,s.length) 空间O(1)
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int i = 0, j = 0;
            int children = 0;

            while (i < g.Length && j < s.Length)
            {
                if (g[i] <= s[j])
                {
                    ++i; ++j;
                    ++children;
                }
                else ++j;

            }
            return children;
        }

        //127. 单词接龙
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord)) return 0;

            int Len = beginWord.Length;

            var dic = new Dictionary<string, List<string>>(wordList.Count);

            foreach (var item in wordList)
            {
                for (int i = 0; i < Len; ++i)
                {

                    string ch = $"{item.Substring(0, i)}*{item.Substring(i + 1)}";

                    if (dic.ContainsKey(ch)) dic[ch].Add(item);
                    else dic.Add(ch, new List<string> { item });
                }
            }

            Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>>(wordList.Count);
            queue.Enqueue(new KeyValuePair<string, int>(beginWord, 1));

            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                string word = point.Key;
                int count = point.Value;

                for (int i = 0; i < Len; ++i)
                {

                    string ch = $"{word.Substring(0, i)}*{word.Substring(i + 1, Len - i - 1)}";

                    if (dic.ContainsKey(ch))
                    {
                        foreach (var item in dic[ch])
                        {
                            if (item == endWord) return ++count;
                            queue.Enqueue(new KeyValuePair<string, int>(item, count + 1));
                        }
                        dic.Remove(ch);
                    }
                }
            }

            return 0;
        }


        //33. 搜索旋转排序数组
        public int Search(int[] nums, int target)
        {
            return -1;
        }

        //153. 寻找旋转排序数组中的最小值
        public int FindMin(int[] nums)
        {
            int min = nums[0], l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + ((r - l) >> 1);
                if (nums[l] <= nums[mid])
                {
                    min = Math.Min(min, nums[l]);
                    l = mid + 1;
                }
                else
                {
                    min = Math.Min(min, nums[mid]);
                    r = mid - 1;
                }
            }
            return min;
        }

        //55. 跳跃游戏
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 0) return false;

            int final = nums.Length - 1;
            int jump = nums[0];
            for (int i = 0; i < nums.Length; ++i)
            {
                if (jump < 0) return false;
                if (i + jump >= final) return true;
                if (nums[i] > jump) jump = nums[i];
                --jump;
            }
            return false;
        }
    }
}