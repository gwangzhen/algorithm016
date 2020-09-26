using System;
using System.Collections.Generic;
using System.Linq;

namespace week_03
{
    public class HomeWork
    {
        //236. 二叉树的最近公共祖先
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left == null) return right;
            if (right == null) return left;

            return root;
        }

        

        //105. 从前序与中序遍历序列构造二叉树
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Helper(0, 0, inorder.Length - 1, preorder, inorder);
        }

        public TreeNode Helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preStart > preorder.Length - 1 || inStart > inEnd) return null;

            TreeNode root = new TreeNode(preorder[preStart]);

            int inIndex = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == root.val)
                {
                    inIndex = i;
                    break;
                }
            }

            root.left = Helper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            root.right = Helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);

            return root;
        }


        //77. 组合
        List<int> temp = new List<int>();
        List<IList<int>> ans = new List<IList<int>>();
        public IList<IList<int>> Combine(int n, int k)
        {
            var res = new List<IList<int>>();
            recruion(1, n, k, new int[k], res);
            return res;
        }

        void recruion(int start, int n, int k, int[] item, IList<IList<int>> res)
        {
            if (k == 0)
            {
                res.Add(item.ToList());
                return;
            }
            for (var i = start; i <= n - k + 1; i++)
            {
                item[item.Length - k] = i;
                recruion(i + 1, n, k - 1, item, res);
            }
        }




        //46. 全排列
        public IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> res = new List<IList<int>>();
            LinkedList<int> track = new LinkedList<int>();
            backrack(nums, track, res);
            return res;
        }

        public static void backrack(int[] nums, LinkedList<int> track, IList<IList<int>> res)
        {
            if (track.Count == nums.Length)
            {
                res.Add(new List<int>(track));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i]))
                {
                    continue; ;
                }
                track.AddLast(nums[i]);
                backrack(nums, track, res);
                track.RemoveLast();
            }
        }



        //47. 全排列 II
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            permute(0, result, nums);
            return result;
        }
        
        private void permute(int nextIndex, IList<IList<int>> result, int[] nums)
        {
            if (nextIndex == nums.Length)
            {
                result.Add(nums.ToList());
                return;
            }

            HashSet<int> visited = new HashSet<int>();
            for (int i = nextIndex; i < nums.Length; i++)
            {
                if (visited.Add(nums[i]))
                {
                    int t = nums[i];
                    nums[i] = nums[nextIndex];
                    nums[nextIndex] = t;

                    permute(nextIndex + 1, result, nums);

                    t = nums[i];
                    nums[i] = nums[nextIndex];
                    nums[nextIndex] = t;
                }
            }
        }
    }
}