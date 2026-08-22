#pragma once

#include <cstdint>
#include <vector>
#include <string>

#include "data_structure.h"
namespace leetcode {
class Solution {
public:
  /// <summary>
  /// 1. Two Sum
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<int> two_sum(std::vector<int> &nums, int target);

  /// <summary>
  /// 2. Add Two Numbers
  /// </summary>
  /// <param name="l1"></param>
  /// <param name="l2"></param>
  /// <returns></returns>
  ListNode *add_two_numbers(ListNode *l1, ListNode *l2);

  /// <summary>
  /// 3. Longest Substring Without Repeating Characters
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int length_of_longest_substring(std::string s);

  /// <summary>
  ///  4. Median of Two Sorted Arrays
  /// </summary>
  /// <param name="nums1"></param>
  /// <param name="nums2"></param>
  /// <returns></returns>
  double find_median_sorted_arrays(std::vector<int> &nums1,
                                   std::vector<int> &nums2);

  /// <summary>
  /// 5. Longest Palindromic Substring
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  std::string longest_palindrome(std::string s);

  /// <summary>
  /// 6. ZigZag Conversion
  /// </summary>
  /// <param name="s"></param>
  /// <param name="numRows"></param>
  /// <returns></returns>
  std::string convert(std::string s, int num_rows);

  /// <summary>
  /// 7. Reverse Integer
  /// </summary>
  /// <param name="x"></param>
  /// <returns></returns>
  int reverse(int x);

  /// <summary>
  /// 8. String to Integer(atoi)
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  int atoi(std::string str);

  /// <summary>
  /// 9. Palindrome Number
  /// </summary>
  /// <param name="x"></param>
  /// <returns></returns>
  bool is_palindrome(int x);

  /// <summary>
  /// 10. Regular Expression Matching
  /// </summary>
  /// <param name="s"></param>
  /// <param name="p"></param>
  /// <returns></returns>
  bool is_match(std::string s, std::string p);

  /// <summary>
  /// 11. Container With Most Water
  /// </summary>
  /// <param name="height"></param>
  /// <returns></returns>
  int max_area(std::vector<int> &height);

  /// <summary>
  /// 12. Integer to Roman
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns>
  std::string int_to_roman(int num);

  /// <summary>
  /// 13. Roman to Integer
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int roman_to_integer(std::string s);

  /// <summary>
  /// 14. Longest Common Prefix
  /// </summary>
  /// <param name="strs"></param>
  /// <returns></returns>
  std::string longest_common_prefix(std::vector<std::string> &strs);

  /// <summary>
  /// 15. 3Sum
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> three_sum(std::vector<int> &nums);

  /// <summary>
  /// 16. 3Sum Closest
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int three_sum_closest(std::vector<int> &nums, int target);

  /// <summary>
  /// 17. Letter Combinations of a Phone Number
  /// </summary>
  /// <param name="digits"></param>
  /// <returns></returns>
  std::vector<std::string> letter_combinations(std::string digits);

  /// <summary>
  /// 18. 4Sum
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> four_sum(std::vector<int> &nums, int target);

  /// <summary>
  /// 19. Remove Nth Node From End of List
  /// </summary>
  /// <param name="head"></param>
  /// <param name="n"></param>
  /// <returns></returns>
  ListNode *remove_nth_from_end(ListNode *head, int n);

  /// <summary>
  /// 20. Valid Parentheses
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  bool is_valid(std::string s);

  /// <summary>
  /// 21. Merge Two Sorted Lists
  /// </summary>
  /// <param name="l1"></param>
  /// <param name="l2"></param>
  /// <returns></returns>
  ListNode *merge_two_lists(ListNode *l1, ListNode *l2);

  /// <summary>
  /// 22. Generate Parentheses
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<std::string> generate_parenthesis(int n);

  /// <summary>
  /// 23. Merge K Sorted Lists
  /// </summary>
  /// <param name="lists"></param>
  /// <returns></returns>
  ListNode *merge_k_lists(std::vector<ListNode *> &lists);

  /// <summary>
  /// 24. Swap Node in Pairs
  /// </summary>
  /// <param name="head"></param>
  /// <returns></returns>
  ListNode *swap_pairs(ListNode *head);

  /// <summary>
  /// 25. Reverse Nodes in k-Group
  /// </summary>
  /// <param name="head"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  ListNode *reverse_k_group(ListNode *head, int k);

  /// <summary>
  /// 26. Remove Duplicates from Sorted Array
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int remove_duplicates(std::vector<int> &nums);

  /// <summary>
  /// 27. Remove Element
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="val"></param>
  /// <returns></returns>
  int remove_element(std::vector<int> &nums, int val);

  /// <summary>
  /// 28. Implement strStr()
  /// </summary>
  /// <param name="haystack"></param>
  /// <param name="needle"></param>
  /// <returns></returns>
  int str_str(std::string haystack, std::string needle);

  /// <summary>
  /// 29. Divide Two Integers
  /// </summary>
  /// <param name="dividend"></param>
  /// <param name="divisor"></param>
  /// <returns></returns>
  int divide(int dividend, int divisor);

  /// <summary>
  /// 30. Substring with Concatenation of All Words
  /// </summary>
  /// <param name="s"></param>
  /// <param name="words"></param>
  /// <returns></returns>
  std::vector<int> find_substring(std::string s,
                                  std::vector<std::string> &words);

  /// <summary>
  /// 31. Next Permutation
  /// </summary>
  /// <param name="nums"></param>
  void next_permutation(std::vector<int> &nums);

  /// <summary>
  /// 32. Longest Valid Parentheses
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int longest_valid_parentheses(std::string &s);

  /// <summary>
  /// 33. Search in Rotated Sorted Array
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int search_in_sorted_array(std::vector<int> &nums, int target);

  /// <summary>
  /// 34. Find First and Last Position of Element in Sorted Array
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<int> search_range(std::vector<int> &nums, int target);

  /// <summary>
  /// 35. Search Insert Position
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int search_insert(std::vector<int> &nums, int target);

  /// <summary>
  /// 36. Valid Sudoku
  /// </summary>
  /// <param name="board"></param>
  /// <returns></returns>
  bool is_valid_sudoku(std::vector<std::vector<char>> &board);

  /// <summary>
  /// 37. Sudoku Solver
  /// </summary>
  /// <param name="board"></param>
  void solve_sudoku(std::vector<std::vector<char>> &board);

  /// <summary>
  /// 38. Count and Say
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::string count_and_say(int n);

  /// <summary>
  /// 39. Combination Sum
  /// </summary>
  /// <param name="candidates"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> combination_sum(std::vector<int> &candidates,
                                                int target);

  /// <summary>
  /// 40. Combination Sum II
  /// </summary>
  /// <param name="candidates"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> combination_sum2(std::vector<int> &candidates,
                                                 int target);

  /// <summary>
  /// 41. First Missing Positive
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int first_missing_positive(std::vector<int> &nums);

  /// <summary>
  /// 43. Multiply String
  /// </summary>
  /// <param name="num1"></param>
  /// <param name="num2"></param>
  /// <returns></returns>
  std::string multiply(std::string num1, std::string num2);

  /// <summary>
  /// 50. Power(x, n)
  /// </summary>
  /// <param name="x"></param>
  /// <param name="n"></param>
  /// <returns></returns>
  double my_power(double x, int n);

  /// <summary>
  /// 51. N-Queens
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<std::vector<std::string>> solve_n_queens(int n);

  /// <summary>
  /// 54. Spiral Matrix
  /// </summary>
  /// <param name="matrix"></param>
  /// <returns></returns>
  std::vector<int> spiral_order(std::vector<std::vector<int>> &matrix);

  /// <summary>
  /// 55. Jump Game
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  bool can_jump(std::vector<int> &nums);

  /// <summary>
  /// 58. Length of Last Word
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int length_of_last_word(std::string s);

  /// <summary>
  /// 59. Spiral Matrix II
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> generate_matrix(int n);

  /// <summary>
  /// 61. Rotate List
  /// </summary>
  /// <param name="head"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  ListNode *rotate_right(ListNode *head, int k);

  /// <summary>
  /// 62. Unique Paths
  /// </summary>
  /// <param name="m"></param>
  /// <param name="n"></param>
  /// <returns></returns>
  int unique_paths(int m, int n);

  /// <summary>
  /// 63. Unique Paths II
  /// </summary>
  /// <param name="obstacleGrid"></param>
  /// <returns></returns>
  int unique_paths_with_obstacles(std::vector<std::vector<int>> &obstacle_grid);

  /// <summary>
  /// 66. Plus One
  /// </summary>
  /// <param name="digits"></param>
  /// <returns></returns>
  std::vector<int> plus_one(std::vector<int> &digits);

  /// <summary>
  /// 67. Add Binary
  /// </summary>
  /// <param name="a"></param>
  /// <param name="b"></param>
  /// <returns></returns>
  std::string add_binary(std::string a, std::string b);

  /// <summary>
  /// 68. Text Justification
  /// </summary>
  /// <param name="words"></param>
  /// <param name="maxWidth"></param>
  /// <returns></returns>
  std::vector<std::string> full_justify(std::vector<std::string> &words,
                                        int max_width);

  /// <summary>
  /// 69. Sqrt(x)
  /// </summary>
  /// <param name="x"></param>
  /// <returns></returns>
  int my_sqrt(int x);

  /// <summary>
  /// 70. Climb Stairs
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  int climb_stairs(int n);

  /// <summary>
  /// 74. Search a 2D Matrix
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  bool search_matrix(std::vector<std::vector<int>> &nums, int target);

  /// <summary>
  /// 77. Combinations
  /// </summary>
  /// <param name="n"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> combine(int n, int k);

  /// <summary>
  /// 92. Reverse Linked List II
  /// </summary>
  /// <param name="head"></param>
  /// <param name="left"></param>
  /// <param name="right"></param>
  /// <returns></returns>
  ListNode *reverse_between(ListNode *head, int left, int right);

  /// <summary>
  /// 94. Binary Tree Inorder Traversal
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  std::vector<int> inorder_traversal(TreeNode *root);

  /// <summary>
  /// 100. Same Tree
  /// </summary>
  /// <param name="p"></param>
  /// <param name="q"></param>
  /// <returns></returns>
  bool is_same_tree(TreeNode *p, TreeNode *q);

  /// <summary>
  /// 101. Symmetric Tree
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  bool is_symmetric(TreeNode *root);

  /// <summary>
  /// 104. Maximum Depth of Binary Tree
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  int max_depth(TreeNode *root);

  /// <summary>
  /// 107. Binary Tree Level Order Traversal II
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> level_order_bottom(TreeNode *root);

  /// <summary>
  /// 111. Minimum Depth of Binary Tree
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  int min_depth(TreeNode *root);

  /// <summary>
  /// 112. Path Sum
  /// </summary>
  /// <param name="root"></param>
  /// <param name="sum"></param>
  /// <returns></returns>
  bool has_path_sum(TreeNode *root, int sum);

  /// <summary>
  /// 118. Pascal's Triangle
  /// </summary>
  /// <param name="numRows"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> generate(int numRows);

  /// <summary>
  /// 125. Valid Palindrome
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  bool is_palindrome(std::string s);

  /// <summary>
  /// 136. Single Number
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int single_number(std::vector<int> &nums);

  /// <summary>
  /// 141. Linked List Cycle
  /// </summary>
  /// <param name="head"></param>
  /// <returns></returns>
  bool has_cycle(ListNode *head);

  /// <summary>
  /// 144. Binary Tree Preorder Traversal
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  std::vector<int> preorder_traversal(TreeNode *root);

  /// <summary>
  /// 145. Binary Tree Postorder Traversal
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  std::vector<int> postorder_traversal(TreeNode *root);

  /// <summary>
  /// 148. Sort List
  /// </summary>
  /// <param name="head"></param>
  /// <returns></returns>
  ListNode *sort_list(ListNode *head);

  /// <summary>
  /// 167. Two Sum II - Input array is sorted
  /// </summary>
  /// <param name="numbers"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  std::vector<int> two_sum_ii(std::vector<int> &numbers, int target);

  /// <summary>
  /// 169. Majority Element
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int majority_element(std::vector<int> &nums);

  /// <summary>
  /// 172. Factorial Trailing Zeroes
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  int trailing_zeroes(int n);

  /// <summary>
  /// 189. Rotate Array
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="k"></param>
  void rotate(std::vector<int> &nums, int k);

  /// <summary>
  /// 190. Reverse Bits
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  uint32_t reverse_bits(uint32_t n);

  /// <summary>
  /// 191. Number of 1 Bits
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  int hamming_weight(uint32_t n);

  /// <summary>
  /// 198. House Robber
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int rob(std::vector<int> &nums);

  /// <summary>
  /// 206. Reverse Linked List
  /// </summary>
  /// <param name="head"></param>
  /// <returns></returns>
  ListNode *reverse_list(ListNode *head);

  /// <summary>
  /// 231. Power of Two
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  bool is_power_of_two(int n);

  /// <summary>
  /// 242. Valid Anagram
  /// </summary>
  /// <param name="s"></param>
  /// <param name="t"></param>
  /// <returns></returns>
  bool is_anagram(std::string s, std::string t);

  /// <summary>
  /// 268. Missing Number
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int missing_number(std::vector<int> &nums);

  /// <summary>
  /// 283. Move Zeroes
  /// </summary>
  /// <param name="nums"></param>
  void move_zeroes(std::vector<int> &nums);

  /// <summary>
  /// 287. Find the Duplicate Number
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int find_duplicate(std::vector<int> &nums);

  /// <summary>
  /// 331. Verify Preorder Serialization of a Binary Tree
  /// </summary>
  /// <param name="preorder"></param>
  /// <returns></returns>
  bool is_valid_serialization(std::string preorder);

  /// <summary>
  /// 344. Reverse String
  /// </summary>
  /// <param name="s"></param>
  void reverse_string(std::vector<char> &s);

  /// <summary>
  /// 357. Count Numbers with Unique Digits
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  int count_numbers_with_unique_digits(int n);

  /// <summary>
  /// 386. Lexicographical Numbers
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<int> lexical_order(int n);

  /// <summary>
  /// 396. Rotate Function
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int max_rotate_function(std::vector<int> &nums);

  /// <summary>
  /// 401. Binary Watch
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns>
  std::vector<std::string> read_binary_watch(int num);

  /// <summary>
  /// 415. Add Strings
  /// </summary>
  /// <param name="num1"></param>
  /// <param name="num2"></param>
  /// <returns></returns>
  std::string add_strings(std::string &num1, std::string &num2);

  /// <summary>
  /// 429. N-ary Tree Level Order Traversal
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> level_order(Node *root);

  /// <summary>
  /// 453. Minimum Moves to Equal Array Elements
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int min_moves(std::vector<int> &nums);

  /// <summary>
  /// 477. Total Hamming Distance
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int total_hamming_distance(std::vector<int> &nums);

  /// <summary>
  /// 498. Diagonal Traverse
  /// </summary>
  /// <param name="mat"></param>
  /// <returns></returns>
  std::vector<int> find_diagonal_order(std::vector<std::vector<int>> &mat);

  /// <summary>
  /// 504. Base 7
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns>
  std::string convert_to_base7(int num);

  /// <summary>
  /// 509. Fibonacci Number
  /// </summary>
  /// <param name="N"></param>
  /// <returns></returns>
  int fib(int N);

  /// <summary>
  /// 518. Coin Change II
  /// </summary>
  /// <param name="amount"></param>
  /// <param name="coins"></param>
  /// <returns></returns>
  int change(int amount, std::vector<int> &coins);

  /// <summary>
  /// 537. Complex Number Multiply
  /// </summary>
  /// <param name="num1"></param>
  /// <param name="num2"></param>
  /// <returns></returns>
  std::string complex_number_multiply(std::string num1, std::string num2);

  /// <summary>
  /// 557. Reverse Words in a String III
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  std::string reverse_words(std::string s);

  /// <summary>
  /// 617. Merge Two Binary Trees
  /// </summary>
  /// <param name="t1"></param>
  /// <param name="t2"></param>
  /// <returns></returns>
  TreeNode *merge_trees(TreeNode *t1, TreeNode *t2);

  /// <summary>
  /// 636. Exclusive Time of Functions
  /// </summary>
  /// <param name="n"></param>
  /// <param name="logs"></param>
  /// <returns></returns>
  std::vector<int> exclusive_time(int n, std::vector<std::string> &logs);

  /// <summary>
  /// 646. Maximum Length of Pair Chain
  /// </summary>
  /// <param name="pairs"></param>
  /// <returns></returns>
  int find_longest_chain(std::vector<std::vector<int>> &pairs);

  /// <summary>
  /// 652. Find Duplicate Subtrees
  /// </summary>
  /// <param name="arr"></param>
  /// <returns></returns>
  std::vector<TreeNode *> find_duplicate_subtrees(TreeNode *root);

  /// <summary>
  /// 658. Find K Closest Elements
  /// </summary>
  /// <param name="arr"></param>
  /// <param name="k"></param>
  /// <param name="x"></param>
  /// <returns></returns>
  std::vector<int> find_closest_elements(std::vector<int> &arr, int k, int x);

  /// <summary>
  /// 662. Maximum Width of Binary Tree
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  int width_of_binary_tree(TreeNode *root);

  /// <summary>
  /// 667. Beautiful Arrangement II
  /// </summary>
  /// <param name="n"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  std::vector<int> construct_array(int n, int k);

  /// <summary>
  /// 669. Trim a Binary Search Tree
  /// </summary>
  /// <param name="root"></param>
  /// <param name="L"></param>
  /// <param name="R"></param>
  /// <returns></returns>
  TreeNode *trim_bst(TreeNode *root, int L, int R);

  /// <summary>
  /// 670. Maximum Swap
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns>
  int maximum_swap(int num);

  /// <summary>
  /// 672. Bulb Switcher II
  /// </summary>
  /// <param name="n"></param>
  /// <param name="presses"></param>
  /// <returns></returns>
  int flip_lights(int n, int presses);

  /// <summary>
  /// 687. Longest Univalue Path
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  int longest_univalue_path(TreeNode *root);

  /// <summary>
  /// 700. Search in a Binary Search Tree
  /// </summary>
  /// <param name="root"></param>
  /// <param name="val"></param>
  /// <returns></returns>
  TreeNode *search_bst(TreeNode *root, int val);

  /// <summary>
  /// 701. Insert into a Binary Search Tree
  /// </summary>
  /// <param name="root"></param>
  /// <param name="val"></param>
  /// <returns></returns>
  TreeNode *insertInto_bst(TreeNode *root, int val);

  /// <summary>
  /// 704. Binary Search
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int binary_search(std::vector<int> &nums, int target);

  /// <summary>
  /// 709. To Lower Case
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  std::string to_lowerCase(std::string str);

  /// <summary>
  /// 724. Find Pivot Index
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int pivot_index(std::vector<int> &nums);

  /// <summary>
  /// 728. Self Dividing Numbers
  /// </summary>
  /// <param name="left"></param>
  /// <param name="right"></param>
  /// <returns></returns>
  std::vector<int> self_dividing_numbers(int left, int right);

  /// <summary>
  /// 739. Daily Temperatures
  /// </summary>
  /// <param name="T"></param>
  /// <returns></returns>
  std::vector<int> daily_temperatures(std::vector<int> &T);

  /// <summary>
  /// 793. Preimage Size of Factorial Zeroes Function
  /// </summary>
  /// <param name="k"></param>
  /// <returns></returns>
  int preimage_size_fzf(int k);

  /// <summary>
  /// 804. Unique Morse Code Words
  /// </summary>
  /// <param name="words"></param>
  /// <returns></returns>
  int unique_morse_representations(std::vector<std::string> &words);

  /// <summary>
  /// 806. Number of Lines To Write String
  /// </summary>
  /// <param name="widths"></param>
  /// <param name="s"></param>
  /// <returns></returns>
  std::vector<int> number_of_lines(std::vector<int> &widths, std::string &s);

  /// <summary>
  /// 821. Shortest Distance to a Character
  /// </summary>
  /// <param name="S"></param>
  /// <param name="C"></param>
  /// <returns></returns>
  std::vector<int> shortest_to_char(std::string S, char C);

  /// <summary>
  /// 828. Count Unique Characters of All Substrings of a Given String
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int unique_letter_string(std::string &s);

  /// <summary>
  /// 852. Peak Index in a Mountain Array
  /// </summary>
  /// <param name="A"></param>
  /// <returns></returns>
  int peak_index_in_mountain_array(std::vector<int> &A);

  /// <summary>
  /// 857. Minimum Cost to Hire K Workers
  /// </summary>
  /// <param name="quality"></param>
  /// <param name="wage"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  double min_cost_to_hire_workers(std::vector<int> &quality,
                                  std::vector<int> &wage, int k);

  /// <summary>
  /// 876. Middle of the Linked List
  /// </summary>
  /// <param name="head"></param>
  /// <returns></returns>
  ListNode *middle_node(ListNode *head);

  /// <summary>
  /// 883. Projection Area of 3D Shapes
  /// </summary>
  /// <param name="grid"></param>
  /// <returns></returns>
  int projection_area(std::vector<std::vector<int>> &grid);

  /// <summary>
  /// 884. Uncommon Words from Two Sentences
  /// </summary>
  /// <param name="A"></param>
  /// <param name="B"></param>
  /// <returns></returns>
  std::vector<std::string> uncommon_from_sentences(std::string A,
                                                   std::string B);

  /// <summary>
  /// 892. Surface Area of 3D Shapes
  /// </summary>
  /// <param name="grid"></param>
  /// <returns></returns>
  int surface_area(std::vector<std::vector<int>> &grid);

  /// <summary>
  /// 894. All Possible Full Binary Trees
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<TreeNode *> all_possible_fbt(int n);

  /// <summary>
  /// 905. Sort Array By Parity
  /// </summary>
  /// <param name="A"></param>
  /// <returns></returns>
  std::vector<int> sort_array_by_parity(std::vector<int> &A);

  /// <summary>
  /// 938. Range Sum of BST
  /// </summary>
  /// <param name="root"></param>
  /// <param name="L"></param>
  /// <param name="R"></param>
  /// <returns></returns>
  int range_sum_bst(TreeNode *root, int L, int R);

  /// <summary>
  /// 944. Delete Columns to Make Sorted
  /// </summary>
  /// <param name="strs"></param>
  /// <returns></returns>
  int min_deletion_size(std::vector<std::string> &strs);

  /// <summary>
  /// 946. Validate Stack Sequences
  /// </summary>
  /// <param name="pushed"></param>
  /// <param name="popped"></param>
  /// <returns></returns>
  bool validate_stack_sequences(std::vector<int> &pushed,
                                std::vector<int> &popped);

  /// <summary>
  /// 961. N-Repeated Element in Size 2N Array
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int repeated_n_times(std::vector<int> &nums);

  /// <summary>
  /// 965. Univalued Binary Tree
  /// </summary>
  /// <param name="root"></param>
  /// <returns></returns>
  bool is_unival_tree(TreeNode *root);

  /// <summary>
  /// 977. Squares of a Sorted Array
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<int> sorted_squares(std::vector<int> &nums);

  /// <summary>
  /// 998. Maximum Binary Tree II
  /// </summary>
  /// <param name="root"></param>
  /// <param name="val"></param>
  /// <returns></returns>
  TreeNode *insert_into_max_tree(TreeNode *root, int val);

  /// <summary>
  /// 1260. Shift 2D Grid
  /// </summary>
  /// <param name="grid"></param>
  /// <param name="k"></param>
  /// <returns></returns>
  std::vector<std::vector<int>> shift_grid(std::vector<std::vector<int>> &grid,
                                           int k);

  /// <summary>
  /// 1263. Minimum Moves to Move a Box to Their Target Location
  /// </summary>
  /// <param name="grid"></param>
  /// <returns></returns>
  int min_push_box(std::vector<std::vector<char>> &grid);

  /// <summary>
  /// 1380. Lucky Numbers in a Matrix
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<int> lucky_numbers(std::vector<std::vector<int>> &matrix);

  /// <summary>
  /// 1403. Minimum Subsequence in Non-Increasing Order
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<int> min_subsequence(std::vector<int> &nums);

  /// <summary>
  /// 1450. Number of Students Doing Homework at a Given Time
  /// </summary>
  /// <param name="startTime"></param>
  /// <param name="endTime"></param>
  /// <param name="queryTime"></param>
  /// <returns></returns>
  int busy_student(std::vector<int> &start_time, std::vector<int> &end_time,
                   int query_time);

  /// <summary>
  /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
  /// </summary>
  /// <param name="sentence"></param>
  /// <param name="searchWord"></param>
  /// <returns></returns>
  int is_prefix_of_word(std::string sentence, std::string search_word);

  /// <summary>
  /// 1464. Maximum Product of Two Elements in an Array
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int max_product(std::vector<int> &nums);

  /// <summary>
  /// 1470. Shuffle the Array
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="n"></param>
  /// <returns></returns>
  std::vector<int> shuffle(std::vector<int> &nums, int n);

  /// <summary>
  /// 1475. Final Prices With a Special Discount in a Shop
  /// </summary>
  /// <param name="prices"></param>
  /// <returns></returns>
  std::vector<int> final_prices(std::vector<int> &prices);

  /// <summary>
  /// 1486. XOR Operation in an Array
  /// </summary>
  /// <param name="n"></param>
  /// <param name="start"></param>
  /// <returns></returns>
  int xor_operation(int n, int start);

  /// <summary>
  /// 1582. Special Positions in a Binary Matrix
  /// </summary>
  /// <param name="mat"></param>
  /// <returns></returns>
  int num_special(std::vector<std::vector<int>> &mat);

  /// <summary>
  /// 1592. Rearrange Spaces Between Words
  /// </summary>
  /// <param name="text"></param>
  /// <returns></returns>
  std::string reorder_spaces(std::string text);

  /// <summary>
  /// 1598. Crawler Log Folder
  /// </summary>
  /// <param name="logs"></param>
  /// <returns></returns>
  int min_operations(std::vector<std::string> &logs);

  /// <summary>
  /// 1608. Special Array With X Elements Greater Than or Equal X
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int special_array(std::vector<int> &nums);

  /// <summary>
  /// 1619. Mean of Array After Removing Some Elements
  /// </summary>
  /// <param name="arr"></param>
  /// <returns></returns>
  double trim_mean(std::vector<int> &arr);

  /// <summary>
  /// 1624. Largest Substring Between Two Equal Characters
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int max_length_between_equal_characters(std::string &s);

  /// <summary>
  /// 1636. Sort Array by Increasing Frequency
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<int> frequency_sort(std::vector<int> &nums);

  /// <summary>
  /// 1658. Minimum Operations to Reduce X to Zero
  /// </summary>
  /// <param name="nums"></param>
  /// <param name="x"></param>
  /// <returns></returns>
  int min_operations(std::vector<int> &nums, int x);

  /// <summary>
  /// 1672. Richest Customer Wealth
  /// </summary>
  /// <param name="accounts"></param>
  /// <returns></returns>
  int maximum_wealth(std::vector<std::vector<int>> &accounts);

  /// <summary>
  /// 1694. Reformat Phone Number
  /// </summary>
  /// <param name="number"></param>
  /// <returns></returns>
  std::string reformat_number(std::string number);

  /// <summary>
  /// 1750. Minimum Length of String After Deleting Similar Ends
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int minimum_length(std::string s);

  /// <summary>
  /// 1784. Check if Binary String Has at Most One Segment of Ones
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  bool check_ones_segment(std::string s);

  /// <summary>
  /// 1991. Find the Middle Index in Array
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int find_middle_index(std::vector<int> &nums);

  /// <summary>
  /// 2027. Minimum Moves to Convert String
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  int minimum_moves(std::string s);

  /// <summary>
  /// 2032. Two Out of Three
  /// </summary>
  /// <param name="nums1"></param>
  /// <param name="nums2"></param>
  /// <param name="nums3"></param>
  /// <returns></returns>
  std::vector<int> two_out_of_three(std::vector<int> &nums1,
                                    std::vector<int> &nums2,
                                    std::vector<int> &nums3);

  /// <summary>
  /// 2037. Minimum Number of Moves to Seat Everyone
  /// </summary>
  /// <param name="seats"></param>
  /// <param name="students"></param>
  /// <returns></returns>
  int min_moves_to_seat(std::vector<int> &seats, std::vector<int> &students);

  /// <summary>
  /// 2042. Check if Numbers Are Ascending in a Sentence
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  bool are_number_ascending(std::string s);

  /// <summary>
  /// 2055. Plates Between Candles
  /// </summary>
  /// <param name="s"></param>
  /// <param name="queries"></param>
  /// <returns></returns>
  std::vector<int>
  plates_between_candles(std::string s, std::vector<std::vector<int>> &queries);

  /// <summary>
  /// 2180. Count Integers With Even Digit Sum
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns>
  int count_even(int num);

  /// <summary>
  /// 2185. Counting Words With a Given Prefix
  /// </summary>
  /// <param name="words"></param>
  /// <param name="pref"></param>
  /// <returns></returns>
  int prefix_count(std::vector<std::string> &words, std::string pref);

  /// <summary>
  /// 2351. First Letter to Appear Twice
  /// </summary>
  /// <param name="s"></param>
  /// <returns></returns>
  char repeated_character(std::string s);

  /// <summary>
  /// 2391. Minimum Amount of Time to Collect Garbage
  /// </summary>
  /// <param name="garbages"></param>
  /// <param name="travel"></param>
  /// <returns></returns>
  int garbage_collection(std::vector<std::string> &garbage,
                         std::vector<int> &travel);

  /// <summary>
  /// 2908. Minimum Sum of Mountain Triplets I
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  int minimum_sum(std::vector<int> nums);

  /// <summary>
  /// 2952. Minimum Number of Coins to be Added
  /// </summary>
  /// <param name="coins"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int minimum_added_coins(std::vector<int> coins, int target);

  /// <summary>
  /// 3289. The Two Sneaky Numbers of Digitville
  /// </summary>
  /// <param name="nums"></param>
  /// <returns></returns>
  std::vector<int> get_sneaky_numbers(std::vector<int> nums);

  /// <summary>
  /// 6078. Rearrange Characters to Make Target String
  /// </summary>
  /// <param name="s"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  int rearrange_characters(std::string s, std::string target);
};
} // namespace leetcode