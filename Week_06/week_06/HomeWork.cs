using System;
using System.Collections.Generic;

namespace week_06
{
    public class HomeWork
    {
        //91. 解码方法
        public int NumDecodings(string s)
        {
            if (s[0] == '0') return 0;

            int pre = 1, cur = 1; //dp[-1] dp[0] = 1;

            for (int i = 1; i < s.Length; ++i)
            {
                int temp = cur;
                if (s[i] == '0')
                {
                    if (s[i - 1] != '1' && s[i - 1] != '2') return 0;
                    else cur = pre;
                }
                else
                {
                    if (s[i - 1] == '1' || (s[i - 1] == '2' && int.Parse(s[i] + "") > 0 && int.Parse(s[i] + "") < 7))
                    {
                        cur = cur + pre;
                    }
                }
                pre = temp;
            }
            return cur;
        }

        //64. 最小路径和 时间O(m*n)  空间O(1)
        public int MinPathSum(int[][] grid)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    if (i == 0 && j == 0) continue;
                    else if (i == 0) grid[i][j] = grid[i][j - 1] + grid[i][j];
                    else if (j == 0) grid[i][j] = grid[i - 1][j] + grid[i][j];
                    else grid[i][j] = Math.Min(grid[i - 1][j], grid[i][j - 1]) + grid[i][j];
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
    }
}