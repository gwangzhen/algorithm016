using System;

namespace week1
{
    public class HomeWork
    {

        /// 26. 删除排序数组中的重复项 空间o(1) 时间o(n)
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;
            int j = 0;
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] != nums[j])
                {
                    nums[++j] = nums[i];
                }
            }
            return j + 1;
        }


        /// 189. 旋转数组
        #region 两种种方式

        /// 暴力法 空间O(1) 时间O(N*K)
        public void Rotate(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                int previous = nums[nums.Length - 1];
                for (int j = 0; j < nums.Length; ++j)
                {
                    int temp = nums[j];
                    nums[j] = previous;
                    previous = temp;

                }
            }
        }

        /// 采用额外的数组 空间O(N) 时间O(1)
        public void Rotate1(int[] nums, int k)
        {
            int[] newArr = new int[nums.Length];
            for (int i = 0; i < nums.Length; ++i)
            {
                newArr[(i + k) % nums.Length] = nums[i];
            }
            Array.Copy(newArr, nums, nums.Length);
        }

        #endregion


        /// 21. 合并两个有序链表
        #region  两种方式

        /// 迭代 T:O(N)  S:O(1) 为什么不是O(N)
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode merge = new ListNode(0);
            ListNode head = merge;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    merge.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    merge.next = l2;
                    l2 = l2.next;
                }
                merge = merge.next;
            }
            merge = l1 ?? l2;
            return head;
        }

        ///递归 T:O(N)  S:O(N) 为什么是O(n)
        public ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            if(l1==null) return l2;
            else if(l2==null) return l1;
            else if(l1.val<l2.val){
                l1.next = MergeTwoLists1(l1.next,l2) ;
                return l1;
            }
            else{
                l2.next = MergeTwoLists1(l1,l2.next);
                return l2;
            }
        }
        #endregion
    }
}