#include "pch.h"

#include "../src/solution.h"
#include "../src/utils.h"

using namespace std;
namespace leetcode {
class AddTwoNumbersFixture {
public:
  vector<int> nums1;
  vector<int> nums2;
  string expected;

  AddTwoNumbersFixture(vector<int> nums1, vector<int> nums2, string expected)
      : nums1(nums1), nums2(nums2), expected(expected){};
};

class AddTwoNumbersTest : public testing::TestWithParam<AddTwoNumbersFixture> {
};

INSTANTIATE_TEST_SUITE_P(
    AddTwoNumbersTestCases, AddTwoNumbersTest,
    testing::Values(AddTwoNumbersFixture({2, 4, 3}, {5, 6, 4}, "7->0->8"),
                    AddTwoNumbersFixture({0}, {0}, "0"),
                    AddTwoNumbersFixture({9, 9, 9, 9, 9, 9, 9}, {9, 9, 9, 9},
                                         "8->9->9->9->0->0->0->1")));

TEST_P(AddTwoNumbersTest, Test) {
  AddTwoNumbersFixture param = GetParam();
  Solution solution;

  ListNode *l1 = Utils::generate_list_node(param.nums1);
  ListNode *l2 = Utils::generate_list_node(param.nums2);

  ListNode *actual = solution.add_two_numbers(l1, l2);

  EXPECT_EQ(param.expected, Utils::list_node_to_string(actual));

  delete l1;
  delete l2;
  delete actual;
}
} // namespace leetcode