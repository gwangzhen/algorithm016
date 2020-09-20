using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace week_02
{
    public class HomeWork
    {
        //242. 有效的字母异位词  时间O(N)  空间(1)
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] arr = new int[26];
            for (int i = 0; i < s.Length; ++i)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }
            for (int j = 0; j < arr.Length; ++j)
            {
                if (arr[j] != 0) return false;
            }
            return true;
        }



        //1. 两数之和 时间O(N)  空间O(N)
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length < 2) return null;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (dic.ContainsKey(target - nums[i])) return new int[2] { dic[target - nums[i]], i };
                else dic.TryAdd(nums[i], i);
            }
            return null;
        }


        //589. N叉树的前序遍历  时间0(N)  空间O(N)
        public IList<int> Preorder(Node root)
        {
            IList<int> list = new List<int>();
            Helper(root, list);
            return list;
        }
        public void Helper(Node root, IList<int> list)
        {
            if (root != null)
            {
                list.Add(root.val);

                foreach (var item in root.children)
                {
                    Helper(item, list);
                }
            }
        }


        //49. 字母异位词分组 时间O(NKlogN)  空间O(NK)
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; ++i)
            {
                var ch = strs[i].ToCharArray();
                Array.Sort(ch);
                var ch_str = new string(ch);
                if (dic.ContainsKey(ch_str)) dic[ch_str].Add(strs[i]);
                else dic.Add(ch_str, new List<string>() { strs[i] });
            }

            return new List<IList<string>>(dic.Values);
        }

        //94. 二叉树的中序遍历 时间O(N)  空间O(N)
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> ls = new List<int>();
            Helper(root, ls);
            return ls;
        }
        public void Helper(TreeNode root, IList<int> ls)
        {
            if (root != null)
            {
                Helper(root.left, ls);
                ls.Add(root.val);
                Helper(root.right, ls);
            }
        }


        //144. 二叉树的前序遍历 时间O(N) 空间O(N)
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>(0);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            IList<int> ls = new List<int>();
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                ls.Add(node.val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return ls;
        }


        //429. N叉树的层序遍历 时间O(N)  空间O(N)
        public IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null) return new List<IList<int>>(0);
            var ls = new List<IList<int>>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                IList<int> layer = new List<int>();
                for (int i = 0; i < size; ++i)
                {
                    var node = queue.Dequeue();
                    layer.Add(node.val);
                    foreach (var item in node.children)
                    {
                        queue.Enqueue(item);
                    }
                }
                ls.Add(layer);
            }
            return ls;
        }

        //347. 前 K 个高频元素
        public int[] TopKFrequent(int[] nums, int k)
        {
            int[] res = new int[k];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                if (dic.ContainsKey(nums[i])) dic[nums[i]]++;
                else dic.Add(nums[i], 0);
            }
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(dic);
            list.Sort((x, y) => -x.Value + y.Value);

            for(int i=0;i<res.Length;++i){
                res[i] = list[i].Key;
            }
            return res;
        }
    }
}