using System;
using System.Collections.Generic;

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
        #region 两种方式

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
            if (l1 == null) return l2;
            else if (l2 == null) return l1;
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists1(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists1(l1, l2.next);
                return l2;
            }
        }
        #endregion


        ///88. 合并两个有序数组 
        #region 两种方式

        //创建新的数组 直接合并num1和num2 空间O(1) 时间O(m+n)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums3 = new int[m + n];
            int index1 = 0;
            int index2 = 0;
            int index = 0;
            while (index1 < m && index2 < n)
            {
                if (nums1[index1] <= nums2[index2])
                {
                    nums3[index] = nums1[index1];
                    ++index1;
                }
                else
                {
                    nums3[index] = nums2[index2];
                    ++index2;
                }
                index++;
            }

            while (index1 < m)
            {
                nums3[index] = nums1[index1];
                ++index1;
                ++index;
            }
            while (index2 < n)
            {
                nums3[index] = nums2[index2];
                ++index2;
                ++index;
            }

            Array.Copy(nums3, nums1, nums3.Length);
        }

        //从尾部开始， 将数据直接填充进nums1 空间O(m) 时间O(m+n)
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            --m; --n;
            for (int i = nums1.Length - 1; i >= 0; --i)
            {
                if (m > -1 && n > -1)
                {
                    if (nums1[m] > nums2[n])
                    {
                        nums1[i] = nums1[m];
                        --m;
                    }
                    else
                    {
                        nums1[i] = nums2[n];
                        --n;
                    }
                }
                else if (n > -1)
                {
                    nums1[i] = nums2[n];
                    --n;
                }
            }
        }
        #endregion


        ///1. 两数之和 时间O(n) 空间O(1)
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (dic.ContainsKey(target - nums[i])) return new int[2] { dic[target - nums[i]], i };
                else dic.TryAdd(nums[i], i);
            }
            return new int[0];
        }


        //283. 移动零 时间O(n) 空间O(1)
        public void MoveZeroes(int[] nums)
        {
            if (nums.Length <= 1) return;
            int j = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = temp;
                    ++j;
                }
            }
        }


        //66 加一  递归解法 时间复杂度O(n) 空间O(1)
        #region  method
        public int[] PlusOne(int[] digits)
        {
            if (Helper(digits, 0) == 0) return digits;
            else
            {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
                return digits;
            }
        }
        public int Helper(int[] digits, int index)
        {
            if (index == digits.Length) return 1;

            int result = digits[index] + Helper(digits, index + 1);
            if (result == 10)
            {
                digits[index] = 0;
                return 1;
            }
            digits[index] = result;
            return 0;
        }
        #endregion

        //641. 设计循环双端队列
        public class MyCircularDeque
        {
            int[] array;
            int head;
            int tail;
            int capacity;
            /** Initialize your data structure here. Set the size of the deque to be k. */    /** Initialize your data structure here. Set the size of the deque to be k. */
            public MyCircularDeque(int k)
            {
                this.capacity = k + 1;
                this.array = new int[capacity];
                this.head = 0;
                this.tail = 0;
            }

            /** Adds an item at the front of Deque. Return true if the operation is successful. */
            public bool InsertFront(int value)
            {
                if (IsFull()) return false;
                head = ((head - 1) + capacity) % capacity;
                array[head] = value;
                return true;
            }

            /** Adds an item at the rear of Deque. Return true if the operation is successful. */
            public bool InsertLast(int value)
            {
                if (IsFull()) return false;
                array[tail] = value;
                tail = (tail + 1) % capacity;
                return true;
            }

            /** Deletes an item from the front of Deque. Return true if the operation is successful. */
            public bool DeleteFront()
            {
                if (IsEmpty()) return false;
                head = (head + 1) % capacity;
                return true;
            }

            /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
            public bool DeleteLast()
            {
                if (IsEmpty()) return false;
                tail = ((tail - 1) + capacity) % capacity;
                return true;
            }

            /** Get the front item from the deque. */
            public int GetFront()
            {
                if (IsEmpty()) return -1;
                return array[head];
            }

            /** Get the last item from the deque. */
            public int GetRear()
            {
                if (IsEmpty()) return -1;
                return array[((tail - 1) + capacity) % capacity];
            }

            /** Checks whether the circular deque is empty or not. */
            public bool IsEmpty()
            {
                return head == tail;
            }

            /** Checks whether the circular deque is full or not. */
            public bool IsFull()
            {
                return (tail + 1) % capacity == head;
            }
        }

        //42. 接雨水 单调栈 时间O(n)  空间O(1)
        public int Trap(int[] height)
        {
            if (height == null || height.Length < 3) return 0;
            Stack<int> stack = new Stack<int>(height.Length);
            int result = 0;
            for (int i = 0; i < height.Length; ++i)
            {
                while (stack.Count > 0 && height[stack.Peek()] < height[i])
                {
                    int cur = stack.Pop();
                    while (stack.Count > 0 && height[stack.Peek()] == height[cur])
                    {
                        stack.Pop();
                    }
                    if (stack.Count > 0)
                    {
                        result += (Math.Min(height[stack.Peek()], height[i]) - height[cur]) * (i - stack.Peek() - 1);
                    }
                }
                stack.Push(i);
            }
            return result;
        }
    }
}