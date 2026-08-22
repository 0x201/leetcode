#include "pch.h"

#include <algorithm>

#include "../src/solution.h"
#include "../src/utils.h"

using namespace std;

namespace leetcode {

Solution solution;

TEST(SolutionUnitTest, LengthOfLongestSubstring) {
  EXPECT_EQ(3, solution.length_of_longest_substring("abcabcbb"));
  EXPECT_EQ(1, solution.length_of_longest_substring("bbbbb"));
  EXPECT_EQ(3, solution.length_of_longest_substring("pwwkew"));
}

TEST(SolutionUnitTest, IntToRomanTest) {
  EXPECT_EQ("I", solution.int_to_roman(1));
  EXPECT_EQ("X", solution.int_to_roman(10));
  EXPECT_EQ("VI", solution.int_to_roman(6));
}

TEST(SolutionUnitTest, SearchInsertTest) {
  vector<int> nums1{1, 3, 5, 6};
  vector<int> nums2{1, 3, 5, 6};
  vector<int> nums3{1, 3, 5, 6};
  vector<int> nums4{1, 3, 5, 6};
  vector<int> nums5{1};
  EXPECT_EQ(2, solution.search_insert(nums1, 5));
  EXPECT_EQ(1, solution.search_insert(nums2, 2));
  EXPECT_EQ(4, solution.search_insert(nums3, 7));
  EXPECT_EQ(0, solution.search_insert(nums4, 0));
  EXPECT_EQ(0, solution.search_insert(nums5, 0));
}

TEST(SolutionUnitTest, TrailingZeroesTest) {
  EXPECT_EQ(0, solution.trailing_zeroes(3));
  EXPECT_EQ(1, solution.trailing_zeroes(5));
  EXPECT_EQ(0, solution.trailing_zeroes(0));
}

TEST(SolutionUnitTest, IsValidSerializationTest) {
  EXPECT_TRUE(solution.is_valid_serialization("9,3,4,#,#,1,#,#,2,#,6,#,#"));
  EXPECT_FALSE(solution.is_valid_serialization("1,#"));
  EXPECT_FALSE(solution.is_valid_serialization("9,#,#,1"));
}

TEST(SolutionUnitTest, CountNumbersWithUniqueDigitsTest) {
  EXPECT_EQ(91, solution.count_numbers_with_unique_digits(2));
  EXPECT_EQ(1, solution.count_numbers_with_unique_digits(0));
}

TEST(SolutionUnitTest, LexicalOrderTest) {
  vector<int> expected1{1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9};
  vector<int> expected2{1, 2};
  EXPECT_EQ(expected1, solution.lexical_order(13));
  EXPECT_EQ(expected2, solution.lexical_order(2));
}

TEST(SolutionUnitTest, MinMovesTest) {
  vector<int> nums1{1, 2, 3};
  vector<int> nums2{1, 1, 1};
  EXPECT_EQ(3, solution.min_moves(nums1));
  EXPECT_EQ(0, solution.min_moves(nums2));
}

TEST(SolutionUnitTest, FindDiagonalOrderTest) {
  vector<vector<int>> matrix{{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
  vector<int> expected{1, 2, 4, 7, 5, 3, 6, 8, 9};
  vector<int> actual = solution.find_diagonal_order(matrix);
  EXPECT_EQ(expected, actual);
}

TEST(SolutionUnitTest, ConvertToBase7Test) {
  EXPECT_EQ("202", solution.convert_to_base7(100));
  EXPECT_EQ("-10", solution.convert_to_base7(-7));
}

TEST(SolutionUnitTest, ChangeTest) {
  vector<int> coins1{1, 2, 5};
  vector<int> coins2{2};
  vector<int> coins3{10};
  EXPECT_EQ(4, solution.change(5, coins1));
  EXPECT_EQ(0, solution.change(3, coins2));
  EXPECT_EQ(1, solution.change(10, coins3));
}

TEST(SolutionUnitTest, ExculsiveTimeTest) {
  vector<string> logs1{"0:start:0", "1:start:2", "1:end:5", "0:end:6"};
  vector<string> logs2{"0:start:0", "0:start:2", "0:end:5",
                          "0:start:6", "0:end:6",   "0:end:7"};
  vector<string> logs3{"0:start:0", "0:start:2", "0:end:5",
                          "1:start:6", "1:end:6",   "0:end:7"};
  vector<int> expected1{3, 4};
  vector<int> expected2{8};
  vector<int> expected3{7, 1};
  EXPECT_EQ(expected1, solution.exclusive_time(2, logs1));
  EXPECT_EQ(expected2, solution.exclusive_time(1, logs2));
  EXPECT_EQ(expected3, solution.exclusive_time(2, logs3));
}

TEST(SolutionUnitTest, FindLongestChainTest) {
  vector<vector<int>> pairs1{{1, 2}, {2, 3}, {3, 4}};
  vector<vector<int>> pairs2{{1, 2}, {7, 8}, {4, 5}};
  EXPECT_EQ(2, solution.find_longest_chain(pairs1));
  EXPECT_EQ(3, solution.find_longest_chain(pairs2));
}

TEST(SolutionUnitTest, FindClosestElementsTest) {
  vector<int> arr1{1, 2, 3, 4, 5};
  vector<int> arr2{1, 2, 3, 4, 5};
  vector<int> expected1{1, 2, 3, 4};
  vector<int> expected2{1, 2, 3, 4};
  EXPECT_EQ(expected1, solution.find_closest_elements(arr1, 4, 3));
  EXPECT_EQ(expected2, solution.find_closest_elements(arr2, 4, -1));
}

TEST(SolutionUnitTest, ConstructArrayTest) {
  vector<int> expected1{1, 2, 3};
  vector<int> expected2{1, 3, 2};
  EXPECT_EQ(expected1, solution.construct_array(3, 1));
  EXPECT_EQ(expected2, solution.construct_array(3, 2));
}

TEST(SolutionUnitTest, WidthOfBinaryTreeTest) {
  string nums1{"1,3,2,5,3,null,9"};
  string nums2{"1,3,2,5,null,null,9,6,null,7"};
  string nums3{"1,3,2,5"};
  TreeNode *root1 = Utils::generate_tree_node(nums1);
  TreeNode *root2 = Utils::generate_tree_node(nums2);
  TreeNode *root3 = Utils::generate_tree_node(nums3);
  EXPECT_EQ(4, solution.width_of_binary_tree(root1));
  EXPECT_EQ(7, solution.width_of_binary_tree(root2));
  EXPECT_EQ(2, solution.width_of_binary_tree(root3));

  delete root1;
  delete root2;
  delete root3;
}

TEST(SolutionUnitTest, MaximumSwapTest) {
  EXPECT_EQ(7236, solution.maximum_swap(2736));
  EXPECT_EQ(9973, solution.maximum_swap(9973));
}

TEST(SolutionUnitTest, FlipLightsTest) {
  EXPECT_EQ(2, solution.flip_lights(1, 1));
  EXPECT_EQ(3, solution.flip_lights(2, 1));
  EXPECT_EQ(4, solution.flip_lights(3, 1));
}

TEST(SolutionUnitTest, LongestUnivaluePathTest) {
  string nums1{"5,4,5,1,1,null,5"};
  string nums2{"1,4,5,4,4,null,5"};
  TreeNode *root1 = Utils::generate_tree_node(nums1);
  TreeNode *root2 = Utils::generate_tree_node(nums2);
  EXPECT_EQ(2, solution.longest_univalue_path(root1));
  EXPECT_EQ(2, solution.longest_univalue_path(root2));

  delete root1;
  delete root2;
}

TEST(SolutionUnitTest, PivotIndexTest) {
  vector<int> nums1{1, 7, 3, 6, 5, 6};
  vector<int> nums2{1, 2, 3};
  vector<int> nums3{2, 1, -1};
  EXPECT_EQ(3, solution.pivot_index(nums1));
  EXPECT_EQ(-1, solution.pivot_index(nums2));
  EXPECT_EQ(0, solution.pivot_index(nums3));
}

TEST(SolutionUnitTest, SelfDividingNumbersTest) {
  vector<int> expected1{1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22};
  vector<int> expected2{48, 55, 66, 77};
  EXPECT_EQ(expected1, solution.self_dividing_numbers(1, 22));
  EXPECT_EQ(expected2, solution.self_dividing_numbers(47, 85));
}

TEST(SolutionUnitTest, PreimageSizeFZFTest) {
  EXPECT_EQ(5, solution.preimage_size_fzf(0));
  EXPECT_EQ(0, solution.preimage_size_fzf(5));
  EXPECT_EQ(5, solution.preimage_size_fzf(3));
}

TEST(SolutionUnitTest, UniqueMorseRepresentationsTest) {
  vector<string> words1{"gin", "zen", "gig", "msg"};
  vector<string> words2{"a"};
  EXPECT_EQ(2, solution.unique_morse_representations(words1));
  EXPECT_EQ(1, solution.unique_morse_representations(words2));
}

TEST(SolutionUnitTest, NumberOfLinesTest) {
  vector<int> widths1{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
                      10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
  vector<int> widths2{4,  10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
                      10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
  string s1{"abcdefghijklmnopqrstuvwxyz"};
  string s2{"bbbcccdddaaa"};
  vector<int> expected1 = {3, 60};
  vector<int> expected2 = {2, 4};
  EXPECT_EQ(expected1, solution.number_of_lines(widths1, s1));
  EXPECT_EQ(expected2, solution.number_of_lines(widths2, s2));
}

TEST(SolutionUnitTest, UniqueLetterStringTest) {
  string s1{"ABC"};
  string s2{"ABA"};
  string s3{"LEETCODE"};
  EXPECT_EQ(10, solution.unique_letter_string(s1));
  EXPECT_EQ(8, solution.unique_letter_string(s2));
  EXPECT_EQ(92, solution.unique_letter_string(s3));
}

TEST(SolutionUnitTest, MinCostToHireWorkersTest) {
  vector<int> quality1{10, 20, 5};
  vector<int> quality2{3, 1, 10, 10, 1};
  vector<int> wage1{70, 50, 30};
  vector<int> wage2{4, 8, 2, 2, 7};
  EXPECT_TRUE(abs(105.00000 - solution.min_cost_to_hire_workers(quality1, wage1,
                                                            2)) <= 0.00001);
  EXPECT_TRUE(abs(30.66667 - solution.min_cost_to_hire_workers(quality2, wage2,
                                                           3)) <= 0.00001);
}

TEST(SolutionUnitTest, MinDeletionSizeTest) {
  vector<string> strs1{"cba", "daf", "ghi"};
  vector<string> strs2{"a", "b"};
  vector<string> strs3{"zyx", "wvu", "tsr"};
  EXPECT_EQ(1, solution.min_deletion_size(strs1));
  EXPECT_EQ(0, solution.min_deletion_size(strs2));
  EXPECT_EQ(3, solution.min_deletion_size(strs3));
}

TEST(SolutionUnitTest, ValidateStackSequencesTest) {
  vector<int> pushed1{1, 2, 3, 4, 5};
  vector<int> popped1{4, 5, 3, 2, 1};

  vector<int> pushed2{1, 2, 3, 4, 5};
  vector<int> popped2{4, 3, 5, 1, 2};

  EXPECT_TRUE(solution.validate_stack_sequences(pushed1, popped1));
  EXPECT_FALSE(solution.validate_stack_sequences(pushed2, popped2));
}

TEST(SolutionUnitTest, RepeatedNTimesTest) {
  vector<int> nums1{1, 2, 3, 3};
  vector<int> nums2{2, 1, 2, 5, 3, 2};
  vector<int> nums3{5, 1, 5, 2, 5, 3, 5, 4};
  EXPECT_EQ(3, solution.repeated_n_times(nums1));
  EXPECT_EQ(2, solution.repeated_n_times(nums2));
  EXPECT_EQ(5, solution.repeated_n_times(nums3));
}

TEST(SolutionUnitTest, IsUnivalTreeTest) {
  string nums1{"1,1,1,1,1,null,1"};
  string nums2{"2,2,2,5,2"};

  TreeNode *root1 = Utils::generate_tree_node(nums1);
  TreeNode *root2 = Utils::generate_tree_node(nums2);

  EXPECT_TRUE(solution.is_unival_tree(root1));
  EXPECT_FALSE(solution.is_unival_tree(root2));

  delete root1;
  delete root2;
}

TEST(SolutionUnitTest, InsertIntoMaxTreeTest) {
  string nodes1 = "4,1,3,null,null,2";
  string nodes2 = "5,2,4,null,1";
  string nodes3 = "5,2,3,null,1";
  vector<int> actual1 =
      Utils::preorder_traversal(solution.insert_into_max_tree(
          Utils::generate_tree_node(nodes1), 5));
  vector<int> actual2 =
      Utils::preorder_traversal(solution.insert_into_max_tree(
          Utils::generate_tree_node(nodes2), 3));
  vector<int> actual3 =
      Utils::preorder_traversal(solution.insert_into_max_tree(
          Utils::generate_tree_node(nodes3), 4));
  vector<int> expected1 = {5, 4, 1, 3, 2};
  vector<int> expected2 = {5, 2, 1, 4, 3};
  vector<int> expected3 = {5, 2, 1, 4, 3};
  EXPECT_EQ(expected1, actual1);
  EXPECT_EQ(expected2, actual2);
  EXPECT_EQ(expected3, actual3);
}

TEST(SolutionUnitTest, MinSubsequenceTest) {
  vector<int> nums1 = {4, 3, 10, 9, 8};
  vector<int> nums2 = {4, 4, 7, 6, 7};
  vector<int> nums3 = {6};
  vector<int> expected1 = {10, 9};
  vector<int> expected2 = {7, 7, 6};
  vector<int> expected3 = {6};
  EXPECT_EQ(expected1, solution.min_subsequence(nums1));
  EXPECT_EQ(expected2, solution.min_subsequence(nums2));
  EXPECT_EQ(expected3, solution.min_subsequence(nums3));
}

TEST(SolutionUnitTest, BusyStudentTest) {
  vector<int> startTime1 = {1, 2, 3};
  vector<int> endTime1 = {3, 2, 7};
  vector<int> startTime2 = {4};
  vector<int> endTime2 = {4};
  EXPECT_EQ(1, solution.busy_student(startTime1, endTime1, 4));
  EXPECT_EQ(1, solution.busy_student(startTime2, endTime2, 4));
}

TEST(SolutionUnitTest, IsPrefixOfWordTest) {
  string sentence1 = "i love eating burger";
  string sentence2 = "this problem is an easy problem";
  string sentence3 = "i am tired";
  string searchWord1 = "burg";
  string searchWord2 = "pro";
  string searchWord3 = "you";
  EXPECT_EQ(4, solution.is_prefix_of_word(sentence1, searchWord1));
  EXPECT_EQ(2, solution.is_prefix_of_word(sentence2, searchWord2));
  EXPECT_EQ(-1, solution.is_prefix_of_word(sentence3, searchWord3));
}

TEST(SolutionUnitTest, ShuffleTest) {
  vector<int> nums1 = {2, 5, 1, 3, 4, 7};
  vector<int> nums2 = {1, 2, 3, 4, 4, 3, 2, 1};
  vector<int> nums3 = {1, 1, 2, 2};
  vector<int> expected1 = {2, 3, 5, 4, 1, 7};
  vector<int> expected2 = {1, 4, 2, 3, 3, 2, 4, 1};
  vector<int> expected3 = {1, 2, 1, 2};
  EXPECT_EQ(expected1, solution.shuffle(nums1, 3));
  EXPECT_EQ(expected2, solution.shuffle(nums2, 4));
  EXPECT_EQ(expected3, solution.shuffle(nums3, 2));
}

TEST(SolutionUnitTest, FinalPricesTest) {
  vector<int> prices1 = {8, 4, 6, 2, 3};
  vector<int> prices2 = {1, 2, 3, 4, 5};
  vector<int> prices3 = {10, 1, 1, 6};
  vector<int> expected1 = {4, 2, 4, 2, 3};
  vector<int> expected2 = {1, 2, 3, 4, 5};
  vector<int> expected3 = {9, 0, 1, 6};
  EXPECT_EQ(expected1, solution.final_prices(prices1));
  EXPECT_EQ(expected2, solution.final_prices(prices2));
  EXPECT_EQ(expected3, solution.final_prices(prices3));
}

TEST(SolutionUnitTest, MaxProductTest) {
  vector<int> nums1 = {3, 4, 5, 2};
  vector<int> nums2 = {1, 5, 4, 5};
  vector<int> nums3 = {3, 7};
  EXPECT_EQ(12, solution.max_product(nums1));
  EXPECT_EQ(16, solution.max_product(nums2));
  EXPECT_EQ(12, solution.max_product(nums3));
}

TEST(SolutionUnitTest, NumSpecialTest) {
  vector<vector<int>> mat1 = {{1, 0, 0}, {0, 0, 1}, {1, 0, 0}};
  vector<vector<int>> mat2 = {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};
  EXPECT_EQ(1, solution.num_special(mat1));
  EXPECT_EQ(3, solution.num_special(mat2));
}

TEST(SolutionUnitTest, ReorderSpacesTest) {
  string text1 = "  this   is  a sentence ";
  string text2 = " practice   makes   perfect";
  EXPECT_EQ("this   is   a   sentence", solution.reorder_spaces(text1));
  EXPECT_EQ("practice   makes   perfect ", solution.reorder_spaces(text2));
}

TEST(SolutionUnitTest, MinOperationsTest) {
  vector<string> logs1{"d1/", "d2/", "../", "d21/", "./"};
  vector<string> logs2{"d1/", "d2/", "./", "d3/", "../", "d31/"};
  vector<string> logs3{"d1/", "../", "../", "../"};
  EXPECT_EQ(2, solution.min_operations(logs1));
  EXPECT_EQ(3, solution.min_operations(logs2));
  EXPECT_EQ(0, solution.min_operations(logs3));
}

TEST(SolutionUnitTest, SpecialArrayTest) {
  vector<int> nums1{3, 5};
  vector<int> nums2{0, 0};
  vector<int> nums3{0, 4, 3, 0, 4};
  EXPECT_EQ(2, solution.special_array(nums1));
  EXPECT_EQ(-1, solution.special_array(nums2));
  EXPECT_EQ(3, solution.special_array(nums3));
}

TEST(SolutionUnitTest, TrimMeanTest) {
  vector<int> nums1{1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3};
  vector<int> nums2{6, 2, 7, 5, 1, 2, 0, 3, 10, 2,
                    5, 0, 5, 5, 0, 8, 7, 6, 8,  0};
  vector<int> nums3{6,  0, 7, 0, 7, 5, 7, 8,  3, 4, 0, 7, 8, 1,
                    6,  8, 1, 1, 2, 4, 8, 1,  9, 5, 4, 3, 8, 5,
                    10, 8, 6, 6, 1, 0, 6, 10, 8, 2, 3, 4};
  EXPECT_TRUE((solution.trim_mean(nums1) - 2.00000) <= 0.00001);
  EXPECT_TRUE((solution.trim_mean(nums2) - 4.00000) <= 0.00001);
  EXPECT_TRUE((solution.trim_mean(nums3) - 4.77778) <= 0.00001);
}

TEST(SolutionUnitTest, MaxLengthBetweenEqualCharactersTest) {
  string s1 = "aa";
  string s2 = "abca";
  string s3 = "bczyx";
  EXPECT_EQ(0, solution.max_length_between_equal_characters(s1));
  EXPECT_EQ(2, solution.max_length_between_equal_characters(s2));
  EXPECT_EQ(-1, solution.max_length_between_equal_characters(s3));
}

TEST(SolutionUnitTest, FrequencySortTest) {
  vector<int> nums1{1, 1, 2, 2, 2, 3};
  vector<int> nums2{2, 3, 1, 3, 2};
  vector<int> nums3{-1, 1, -6, 4, 5, -6, 1, 4, 1};
  vector<int> expected1{3, 1, 1, 2, 2, 2};
  vector<int> expected2{1, 3, 3, 2, 2};
  vector<int> expected3{5, -1, 4, 4, -6, -6, 1, 1, 1};
  EXPECT_EQ(expected1, solution.frequency_sort(nums1));
  EXPECT_EQ(expected2, solution.frequency_sort(nums2));
  EXPECT_EQ(expected3, solution.frequency_sort(nums3));
}

TEST(SolutionUnitTest, MinOperations2Test) {
  vector<int> nums1{1, 1, 4, 2, 3};
  vector<int> nums2{5, 6, 7, 8, 9};
  vector<int> nums3{3, 2, 20, 1, 1, 3};
  EXPECT_EQ(2, solution.min_operations(nums1, 5));
  EXPECT_EQ(-1, solution.min_operations(nums2, 4));
  EXPECT_EQ(5, solution.min_operations(nums3, 10));
}

TEST(SolutionUnitTest, MaximumWealthTest) {
  vector<vector<int>> accounts1 = {{1, 2, 3}, {3, 2, 1}};
  vector<vector<int>> accounts2 = {{1, 5}, {7, 3}, {3, 5}};
  vector<vector<int>> accounts3 = {{2, 8, 7}, {7, 1, 3}, {1, 9, 5}};
  EXPECT_EQ(6, solution.maximum_wealth(accounts1));
  EXPECT_EQ(10, solution.maximum_wealth(accounts2));
  EXPECT_EQ(17, solution.maximum_wealth(accounts3));
}

TEST(SolutionUnitTest, ReformatNumberTest) {
  EXPECT_EQ("123-456", solution.reformat_number("1-23-45 6"));
  EXPECT_EQ("123-45-67", solution.reformat_number("123 4-567"));
  EXPECT_EQ("123-456-78", solution.reformat_number("123 4-5678"));
}

TEST(SolutionUnitTest, MinimumLengthTest) {
  EXPECT_EQ(2, solution.minimum_length("ca"));
  EXPECT_EQ(0, solution.minimum_length("cabaabac"));
  EXPECT_EQ(3, solution.minimum_length("aabccabba"));
}

TEST(SolutionUnitTest, CheckOnesSegmentTest) {
  EXPECT_EQ(false, solution.check_ones_segment("1001"));
  EXPECT_EQ(true, solution.check_ones_segment("110"));
}

TEST(SolutionUnitTest, FindMiddleIndexTest) {
  vector<int> nums1 = {2, 3, -1, 8, 4};
  vector<int> nums2 = {1, -1, 4};
  vector<int> nums3 = {2, 5};
  EXPECT_EQ(3, solution.find_middle_index(nums1));
  EXPECT_EQ(2, solution.find_middle_index(nums2));
  EXPECT_EQ(-1, solution.find_middle_index(nums3));
}

TEST(SolutionUnitTest, MinimumMovesTest) {
  EXPECT_EQ(1, solution.minimum_moves("XXX"));
  EXPECT_EQ(2, solution.minimum_moves("XXOX"));
  EXPECT_EQ(0, solution.minimum_moves("OOOO"));
}

TEST(SolutionUnitTest, TwoOutOfThreeTest) {
  vector<int> nums1 = {1, 1, 3, 2};
  vector<int> nums2 = {2, 3};
  vector<int> nums3 = {3};
  vector<int> actual = solution.two_out_of_three(nums1, nums2, nums3);
  vector<int> expected = {3, 2};
  sort(actual.begin(), actual.end());
  sort(expected.begin(), expected.end());
  EXPECT_EQ(expected, actual);

  nums1 = {3, 1};
  nums2 = {2, 3};
  nums3 = {1, 2};
  actual = solution.two_out_of_three(nums1, nums2, nums3);
  expected = {2, 3, 1};
  sort(actual.begin(), actual.end());
  sort(expected.begin(), expected.end());
  EXPECT_EQ(expected, actual);

  nums1 = {1, 2, 2};
  nums2 = {4, 3, 3};
  nums3 = {5};
  actual = solution.two_out_of_three(nums1, nums2, nums3);
  expected = {};
  sort(actual.begin(), actual.end());
  sort(expected.begin(), expected.end());
  EXPECT_EQ(expected, actual);
}

TEST(SolutionUnitTest, MinMovesToSeatTest) {
  vector<int> seats1{3, 1, 5};
  vector<int> seats2{4, 1, 5, 9};
  vector<int> seats3{2, 2, 6, 6};
  vector<int> students1{2, 7, 4};
  vector<int> students2{1, 3, 2, 6};
  vector<int> students3{1, 3, 2, 6};
  EXPECT_EQ(4, solution.min_moves_to_seat(seats1, students1));
  EXPECT_EQ(7, solution.min_moves_to_seat(seats2, students2));
  EXPECT_EQ(4, solution.min_moves_to_seat(seats3, students3));
}

TEST(SolutionUnitTest, AreNumberAscendingTest) {
  EXPECT_EQ(true, solution.are_number_ascending(
                      "1 box has 3 blue 4 red 6 green and 12 yellow marbles"));
  EXPECT_EQ(false, solution.are_number_ascending("hello world 5 x 5"));
  EXPECT_EQ(false,
            solution.are_number_ascending("sunset is at 7 51 pm overnight lows "
                                        "will be in the low 50 and 60 s"));
}

TEST(SolutionUnitTest, PlatesBetweenCandlesTest) {
  vector<vector<int>> queries1 = {{2, 5}, {5, 9}};
  vector<int> expected1 = {2, 3};
  auto actual1 = solution.plates_between_candles("**|**|***|", queries1);

  vector<vector<int>> queries2 = {{1, 17}, {4, 5}, {14, 17}, {5, 11}, {15, 16}};
  vector<int> expected2 = {9, 0, 0, 0, 0};
  auto actual2 =
      solution.plates_between_candles("***|**|*****|**||**|*", queries2);

  EXPECT_EQ(expected1, actual1);
  EXPECT_EQ(expected2, actual2);
}

TEST(SolutionUnitTest, CountEvenTest) {
  EXPECT_EQ(2, solution.count_even(4));
  EXPECT_EQ(14, solution.count_even(30));
}

TEST(SolutionUnitTest, PrefixCountTest) {
  vector<string> words1{"pay", "attention", "practice", "attend"};
  vector<string> words2{"leetcode", "win", "loops", "success"};
  EXPECT_EQ(2, solution.prefix_count(words1, "at"));
  EXPECT_EQ(0, solution.prefix_count(words2, "code"));
}

TEST(SolutionUnitTest, RepeatedCharacterTest) {
  EXPECT_EQ('c', solution.repeated_character("abccbaacz"));
  EXPECT_EQ('d', solution.repeated_character("abcdd"));
  EXPECT_EQ('a', solution.repeated_character("aa"));
  EXPECT_EQ('z', solution.repeated_character("zz"));
}

TEST(SolutionUnitTest, RearrangeCharactersTest) {
  EXPECT_EQ(2, solution.rearrange_characters("ilovecodingonleetcode", "code"));
  EXPECT_EQ(1, solution.rearrange_characters("abcba", "abc"));
  EXPECT_EQ(1, solution.rearrange_characters("abbaccaddaeea", "aaaaa"));
}

} // namespace leetcode