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
            return 1;
        }

    }
}