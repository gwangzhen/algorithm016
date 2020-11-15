using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace week_09
{
    public class HomeWork
    {
        //387. 字符串中的第一个唯一字符 时间O(N)  空间O(N)
        public int FirstUniqChar(string s)
        {
            var dic = new Dictionary<char, int>();

            foreach (var str in s)
            {
                if (dic.ContainsKey(str)) dic[str]++;
                else dic.Add(str, 1);
            }

            for (int i = 0; i < s.Length; ++i)
            {
                if (dic[s[i]] == 1) return i;
            }
            return -1;
        }


        //151. 翻转字符串里的单词
        public string ReverseWords(string s)
        {
            return String.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
            // var ls = new List<string>();
            // string temp = string.Empty;

            // for(int i=0;i<s.Length;++i){
            //     if(s[i]!=' ') temp += s[i];
            //     if((i==s.Length-1 || s[i]==' ') && temp!=string.Empty){
            //         ls.Add(temp);
            //         temp = string.Empty;
            //     }
            // }

            // StringBuilder builder = new StringBuilder();
            // for(int i=ls.Count-1;i>=0;--i){
            //     builder.Append($"{ls[i]}");
            //     if(i!=0) builder.Append(" ");
            // }
            // return builder.ToString();
        }

        //557. 反转字符串中的单词 III
        public string ReverseWordsIII(string s)
        {
            var arr = s.Split();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = string.Join("", arr[i].ToCharArray().Reverse());
            }

            return string.Join(" ", arr);
        }

        //917. 仅仅反转字母
        public string ReverseOnlyLetters(string S)
        {
            var stack = new Stack<char>();

            foreach (var item in S)
            {
                if ((item >= 65 && item < 91) || (item >= 97) && item < 123) stack.Push(item);
            }

            StringBuilder b = new StringBuilder();
            foreach (var item in S)
            {
                if ((item >= 65 && item < 91) || (item >= 97) && item < 123) b.Append(stack.Pop());
                else b.Append(item);
            }
            return b.ToString();
        }

        //680. 验证回文字符串 Ⅱ
        public bool ValidPalindrome(string s)
        {
            return Helper(s, 0, s.Length - 1, false);
        }

        public bool Helper(string s, int head, int tail, bool isDeleted)
        {
            if (head > tail) return true;
            if (s[head] != s[tail] && isDeleted) return false;

            if (s[head] != s[tail] && !isDeleted) return Helper(s, head + 1, tail, true) || Helper(s, head, tail - 1, true);
            else return Helper(s, head + 1, tail - 1, isDeleted);
        }
    }
}