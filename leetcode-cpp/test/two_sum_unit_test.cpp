#include "pch.h"

#include "../src/solution.h"
#include "../src/utils.h"

using namespace std;
namespace leetcode {
class TwoSumFixture {
public:
  vector<int> nums;
  int target;
  vector<int> expected;

  TwoSumFixture(vector<int> nums, int target, vector<int> expected)
      : nums(nums), target(target), expected(expected){};
};

class TwoSumTest : public testing::TestWithParam<TwoSumFixture> {};

INSTANTIATE_TEST_SUITE_P(TwoSumTestCases, TwoSumTest,
                        testing::Values(TwoSumFixture({2, 7, 11, 15}, 9,
                                                      {0, 1}),
                                        TwoSumFixture({3, 2, 4}, 6, {1, 2}),
                                        TwoSumFixture({3, 3}, 6, {0, 1})));

TEST_P(TwoSumTest, Test) {
  TwoSumFixture param = GetParam();
  Solution solution;
  vector<int> actual = solution.two_sum(param.nums, param.target);
  EXPECT_EQ(param.expected, actual);
}
} // namespace leetcode