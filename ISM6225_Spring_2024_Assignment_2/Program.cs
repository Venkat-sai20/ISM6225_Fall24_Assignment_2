using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // This method finds all the missing numbers in the range [1, n] from the input array.
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> result = new List<int>();

                // Mark indices corresponding to the numbers in the array as negative.
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }

                // Collect indices that remain positive, as they represent missing numbers.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1);
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        // This method sorts the array such that all even numbers appear before odd numbers.
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int evenIndex = 0;

                // Swap even numbers to the front of the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        int temp = nums[evenIndex];
                        nums[evenIndex] = nums[i];
                        nums[i] = temp;
                        evenIndex++;
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        // This method finds two indices in the array whose values add up to the target.
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>();

                // Use a dictionary to store the complement of each number and its index.
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }

                    if (!map.ContainsKey(nums[i]))
                    {
                        map[nums[i]] = i;
                    }
                }

                return new int[0]; // Return an empty array if no solution is found.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        // This method calculates the maximum product of any three numbers in the array.
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array to easily access the largest and smallest numbers.

                int n = nums.Length;
                // Option 1: Product of the three largest numbers.
                // Option 2: Product of the two smallest numbers (negative) and the largest number.
                int option1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int option2 = nums[0] * nums[1] * nums[n - 1];
                return Math.Max(option1, option2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // This method converts a decimal number to its binary representation as a string.
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // This method finds the minimum element in a rotated sorted array.
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                // Use binary search to find the minimum element.
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If mid element is greater than the rightmost element, the minimum is to the right.
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left]; // The left pointer will point to the minimum element.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        // This method checks if a given integer is a palindrome.
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false; // Negative numbers are not palindromes.

                string str = x.ToString();
                char[] charArray = str.ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);

                return str == reversed; // Check if the original and reversed strings are equal.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        // Efficient iterative method to compute the nth Fibonacci number.
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0; // Base case: Fibonacci(0) = 0.
                if (n == 1) return 1; // Base case: Fibonacci(1) = 1.

                int a = 0, b = 1;

                // Calculate Fibonacci numbers iteratively up to n.
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }

                return b; // The nth Fibonacci number.
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
