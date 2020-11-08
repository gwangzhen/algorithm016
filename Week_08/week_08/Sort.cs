using System;

namespace week_08
{
    public class Sort
    {
        public void Test()
        {
            int[] arr = new int[] { 12, 3, 51, 12, 5, 6, 1, 7, 98 };
            // Bubble(arr);
            // Insertion(arr);
            // Selection(arr);
            // QuickSort(arr,0,arr.Length-1);
            // MergeSort(arr,0,arr.Length-1);
        }
        //冒泡排序
        public void Bubble(int[] arr)
        {
            bool flag = false;
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length - 1 - i; ++j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        if (!flag) flag = true;
                    }
                }
                if (!flag) break;
            }
        }

        //插入排序
        public void Insertion(int[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                int temp = arr[i];
                int j = i;
                for (; j > 0;)
                {
                    if (arr[j - 1] > temp) arr[j] = arr[--j];
                    else break;
                }
                arr[j] = temp;
            }
        }

        //选择排序
        public void Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int min = arr[i];
                int index = i;

                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        index = j;
                    }
                }

                if (index != i)
                {
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        //快速排序
        public void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = GetMid(arr, left, right);
                QuickSort(arr, left, mid - 1);
                QuickSort(arr, mid + 1, right);
            }
        }
        private int GetMid(int[] arr, int left, int right)
        {
            int i = left, j = left;
            while (i < right)
            {
                if (arr[i] < arr[right])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++j;
                }
                ++i;
            }
            int temp1 = arr[j];
            arr[j] = arr[right];
            arr[right] = temp1;
            return j;
        }
    
    
        //归并排序
        public void MergeSort(int[] arr, int left, int right){
            if(left<right){
                int mid = (left+right)>>1;
                MergeSort(arr,left,mid);
                MergeSort(arr,mid+1,right);
                Merge(arr,left,mid,right);
            }
        }

        private void Merge(int[] arr,int left,int mid,int right){
            int[] newArr = new int[right-left+1];

            int l=left,r = mid+1,index=-1;

            while(l<=mid && r<=right){
                if(arr[l]<=arr[r]) {newArr[++index] = arr[l];++l;} 
                else {newArr[++index] = arr[r];++r;}
            }
            while(l<=mid) {newArr[++index] = arr[l]; ++l;}
            while(r<=right) {newArr[++index] = arr[r]; ++r;}

            for(int i=0;i<newArr.Length;++i){
                arr[left+i] = newArr[i];
            }
        }
    }
}