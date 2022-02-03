using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ACheck
{
    class Program
    {
        static void Main()
        {
            //char[][] a = new char[9][] {
            //    new char[9] {'8', '3', '.', '.', '7', '.', '.', '.', '.'}
            //    ,new char[9]{'6', '.', '.', '1', '9', '5', '.', '.', '.'}
            //    ,new char[9]{'.', '9', '8', '.', '.', '.', '.', '6', '.'}
            //    ,new char[9]{'2', '.', '.', '.', '6', '.', '.', '.', '3'}
            //    ,new char[9]{'4', '7', '.', '8', '.', '3', '.', '.', '1'}
            //    ,new char[9]{'7', '.', '.', '.', '2', '.', '.', '.', '6'}
            //    ,new char[9]{'.', '6', '.', '.', '.', '.', '2', '8', '.'}
            //    ,new char[9]{'.', '.', '.', '4', '1', '9', '.', '.', '5'}
            //    ,new char[9]{'.', '.', '.', '.', '8', '.', '.', '7', '9'} };
            //ListNode n = new ListNode(1);
            //n.next = new ListNode(2);
            //n.next.next = new ListNode(2);
            //n.next.next.next = new ListNode(1);
            TreeNode n = new TreeNode(3);
            n.left = new TreeNode(9);
            n.right = new TreeNode(20);
            n.right.left = new TreeNode(15);
            n.right.right = new TreeNode(7);
            MaxDepth(n);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Partition(nums, 0, nums.Length - 1);
        }

        public TreeNode Partition(int[] nums, int left, int right)
        {
            if (right < left) return null;
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = Partition(nums, left, mid - 1);
            root.right = Partition(nums, mid + 1, right);

            return root;
        }


        public bool IsValidBST(TreeNode root)
        {
            bool result = true;
            if (root.left != null && root.left.val > root.val) return false;
            else if (root.right != null && root.right.val < root.val) return false;
            result = IsValidBST(root.left);
            result = IsValidBST(root.right);
            return result;

        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode first = new ListNode(0);
            first.next = head;
            first = first.next;
            head = head.next;
            first = first.next.next;
            while(first.next != null && first.next.next != null)
            {
                if (head == first) return true;
                head = head.next;
                first = first.next.next;
            }
            return false;
        }

        public static bool IsPalindrome(ListNode head)
        {
            int size = 0;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            while (head != null)
            {
                size++;
                head = head.next;
            }
            int half = size % 2 == 0 ? size / 2 : size / 2 + 1;
            size = 0;
            dummy = dummy.next;
            ListNode check = new ListNode(0);
            check.next = dummy;

            //Reverse second half
            while(size < half)
            {
                dummy = dummy.next;
                size++;
            }
            ListNode secondhalf = ReverseList(dummy);
            check = check.next;
            while(secondhalf != null)
            {
                if (check.val != secondhalf.val) return false;
                check = check.next;
                secondhalf = secondhalf.next;
            }
            return true;
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else if (l1.val > l2.val)
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                current = current.next;
            }
            return dummy.next;
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode note = new ListNode(0);
            ListNode prev = null;
            while (head != null)
            {
                note = new ListNode(0);
                note.val = head.val;
                note.next = prev;
                prev = note;
                head = head.next;
            }
            return note;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int counter = 0;
            int i = 0;
            ListNode current = head;
            ListNode start = current;
            while (head != null)
            {
                counter++;
                if (i == n) current = current.next;
                else i++;
                head = head.next;
            }
            if (counter == n) return start.next;
            if (current.next != null)
            {
                current.val = current.next.val;
                current.next = current.next.next;
            }
            else
            {
                head = start;
                while (head != null)
                {
                    if (head.next.next == null)
                    {
                        head.next = null;

                    }
                    head = head.next;
                }
            };
            return start;
        }

        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            //StringBuilder a = new StringBuilder(20);
            //Array.Sort(strs);
            //for (int i = 0; i < strs[0].Length; i++)
            //{
            //    if (strs[0][i] == strs[strs.Length - 1][i]) a.Append(strs[0][i]);
            //    else break;
            //}
            //return a.ToString();
            int k = -1;
            Array.Sort(strs);
            int len = strs[0].Length < strs[^1].Length ? strs[0].Length : strs[^1].Length;
            for (int i = 0; i < len; i++)
            {
                if (strs[0][i] == strs[^1][i]) k++;
                else break;
            }
            return k > -1 ? strs[0].Substring(0, k) : "";
        }

        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return -1;
            if (needle.Length == 0) return 0;
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if(haystack[i] == needle[0] && haystack[i + needle.Length] == needle[^1])
                {
                    if (haystack.Substring(i, needle.Length) == needle) return i;
                }
            }
            return -1;
        }

        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public static int MyAtoi(string s)
        {
            bool flag = false;
            StringBuilder number = new StringBuilder(200);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (flag) break;
                    continue;
                }
                else if(!IsDigit(s[i]) && s[i] != ' ' && s[i] != '-' && s[i] != '+')
                {
                    return 0;
                }
                else if (IsDigit(s[i]) || s[i] == '-' || s[i] == '+')
                {
                    number.Append(s[i]);
                    i++;
                    while(i < s.Length && IsDigit(s[i]))
                    {
                        number.Append(s[i]);
                        i++;
                    }
                    break;
                }
            }
            if (number.Length == 0) return 0;
            Int32 k;
            if ((number[0] == '-' || number[0] == '+') && number.Length < 2) return 0;
            else if (number[0] == '-' || number[0] == '+') k = 1;
            else k = 0;
                
            while(k < number.Length)
            {
                if (number[k] == '0') number.Remove(k, 1);
                else break;
            }
            if (number.Length > 11 && number[0] == '-') return Int32.MinValue;
            if (number.Length > 11) return Int32.MaxValue;

            Int64 current;
            Int64.TryParse(number.ToString(), out current);
            if (current > Int32.MaxValue) return Int32.MaxValue;
            if (current < Int32.MinValue) return Int32.MinValue;
            return (Int32)current;
        }

        public static bool IsPalindrome(string s)
        {
            StringBuilder str = new StringBuilder(s.Length);
            HashSet<char> alphabet = new HashSet<char>();
            for (char c = 'a'; c <= 'z'; ++c)
            {
                alphabet.Add(c);
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (alphabet.Contains(Char.ToLower(s[i]))) str.Append(Char.ToLower(s[i]));
            }
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i]) return false;
            }
            return true;
        }

        public bool IsAnagram(String s, String t)
        {
            if (s.Length != t.Length) return false;
            Char[] s_array = s.ToCharArray();
            Char[] t_array = t.ToCharArray();
            Array.Sort(s_array);
            Array.Sort(t_array);
            for (int i = 0; i < s.Length; i++)
            {
                if (s_array[i] != t_array[i]) return false;
            }
            return true;
        }

        public int FirstUniqChar(string s)
        {
            HashSet<char> repeated = new HashSet<char>();
            Dictionary<Char, Int32> unique = new Dictionary<Char, Int32>();
            for (int i = 0; i < s.Length; i++)
            {
                if (repeated.Contains(s[i])) continue;
                else if (unique.ContainsKey(s[i]))
                {
                    unique.Remove(s[i]);
                    repeated.Add(s[i]);
                }
                else unique.Add(s[i], i);
            }
            if(unique.Count > 0) return unique.OrderBy(kvp => kvp.Value).First().Value;
            else return -1;
        }

        public void ReverseString(char[] s)
        {
            Char beb;
            for (int i = 0; i < s.Length / 2; i++)
            {
                beb = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = s[i];
                s[i] = beb;
            }
        }

        public int Reverse(int x)
        {
            Boolean minus = x < 0 ? true : false;
            String s;
            if (minus) s = x.ToString().Substring(1);
            else s = x.ToString();
            Char[] a = s.ToCharArray();
            Array.Reverse(a);
            if (minus) s = "-" + new string(a);
            else s = new string(a);
            Int32 result;
            Int32.TryParse(s, out result);
            return result;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            List<Char> current_list = new List<Char>();
            for (Int32 i = 0; i < board.Length; i++)
            {
                for (Int32 k = 0; k < 9; k++)
                {
                    if (board[i][k] == '.') continue;
                    if (current_list.Contains(board[i][k])) return false;
                    current_list.Add(board[i][k]);
                }
                current_list.Clear();
            }

            for (Int32 i = 0; i < board.Length; i++)
            {
                for (Int32 k = 0; k < 9; k++)
                {
                    if (board[k][i] == '.') continue;
                    if (current_list.Contains(board[k][i])) return false;
                    current_list.Add(board[k][i]);
                }
                current_list.Clear();
            }

            Int32 width = 3;
            Int32 heigth = 3;
            while(true)
            {
                for (int i = width - 3; i < width; i++)
                {
                    for (int k = heigth - 3; k < heigth; k++)
                    {
                        if (board[i][k] == '.') continue;
                        if (current_list.Contains(board[i][k])) return false;
                        current_list.Add(board[i][k]);
                    }
                }
                current_list.Clear();
                if (width != 9)
                {
                    width += 3;
                    continue;
                }
                if(heigth != 9)
                {
                    width = 3;
                    heigth += 3;
                    continue;
                }
                break;
            }

            Console.WriteLine("f");
            return true;
        }

        public Int32 RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            Int32 place = 1;
            Int32 min = nums[0];
            for (Int32 i = 1; i < nums.Length; i++)
            {
                if (nums[i] > min)
                {
                    nums[place] = nums[i];
                    place += 1;
                    min = nums[i];
                } 
            }
            return place;
        }

        public Int32 MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;
            Int32 result = 0;
            Int32 min = Int32.MaxValue;
            Int32 max;
            for (int i = 0 ; i < prices.Length; i++)
            {
                if (prices[i] < min) min = prices[i];
                if (prices[i] > min)
                {
                    max = prices[i];
                    result = result + max - min;
                    min = max;
                }
            }
            return result;
        }

        public void Rotate(int[] nums, int k)
        {
            Int32 current;
            Int32 inner = nums[0];
            Int32 place = 0;
            Int32 step = nums.Length / k;
            Boolean flag = step == 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (place + k >= nums.Length)
                {
                    place -= nums.Length;
                }
                current = nums[place + k];
                nums[place + k] = inner;
                inner = current;
                place += k;
                step--;
                if (step == 0 && flag)
                {
                    place += 1;
                    step = nums.Length / k;
                }
            }
        }

        public bool ContainsDuplicate(Int32[] nums)
        {
            if (nums.Length <= 1) return false;
            Array.Sort(nums);
            for (Int32 i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i]) return true;
            }
            return false;
        }

        public int SingleNumber(Int32[] nums)
        {
            Int32 result = 0;
            Array.Sort(nums);
            Boolean sign = true;
            for (Int32 i = 0; i < nums.Length; i++)
            {
                if (sign)
                {
                    result += nums[i];
                    sign = false;
                }
                else
                {
                    result -= nums[i];
                    sign = true;
                }
            }
            return result;
        }

        public int[] Intersect(Int32[] nums1, Int32[] nums2)
        {
            Int32[] min = nums1.Length < nums2.Length ? nums1 : nums2;
            Int32[] max = nums2.Length <= nums1.Length ? nums1 : nums2;
            Array.Sort(min);
            Array.Sort(max);
            Int32[] result = new int[min.Length];
            Int32 slice = 0;
            Int32 i = 0;
            Int32 k = 0;
            while(i < min.Length && k < max.Length)
            {
                if (min[i] < max[k]) i += 1;
                else if (min[i] > max[k]) k += 1;
                else
                {
                    result[slice] = min[i];
                    slice += 1;
                    i += 1;
                    k += 1;
                }
            }
            return result.Take(slice).ToArray();
        }

        public int[] PlusOne(Int32[] digits)
        {
            for (Int32 i = digits.Length - 1; i >= 0; i--)
            {
                if(digits[i] != 9)
                {
                    digits[i] += 1;
                    return digits;
                }
                else if(i == 0 && digits[i] == 9)
                {
                    Int32[] result = new int[digits.Length + 1];
                    result[0] = 1;
                    for (Int32 k = 1; k < result.Length; k++)
                    {
                        result[k] = 0;
                    }
                    return result;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            return digits;
        }

        public void MoveZeroes(Int32[] nums)
        {
            Int32 zero_numb = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    zero_numb += 1;
                }
                else
                {
                    nums[i - zero_numb] = nums[i];
                }
            }

            for (int i = 0; i < zero_numb; i++)
            {
                nums[nums.Length - 1 - i] = 0;
            }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Int32[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int k = i + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[k] > target) break;
                    else if (nums[i] + nums[k] == target)
                    {
                        result[0] = nums[i];
                        result[1] = nums[k];
                    }
                }
            }
            return result;
        }
    }
}
