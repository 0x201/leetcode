#include "pch.h"

#include "../src/solution.h"
#include "../src/utils.h"

using namespace std;
namespace leetcode {
class GarbageCollectionFixture {
public:
  vector<string> garbage;
  vector<int> travel;
  int expected;

  GarbageCollectionFixture(vector<string> garbage, vector<int> travel,
                           int expected)
      : garbage(garbage), travel(travel), expected(expected){};
};

class GarbageCollectionTest
    : public testing::TestWithParam<GarbageCollectionFixture> {};

INSTANTIATE_TEST_SUITE_P(
    GarbageCollectionTestCases, GarbageCollectionTest,
    testing::Values(
        GarbageCollectionFixture({"G", "P", "GP", "GG"}, {2, 4, 3}, 21),
        GarbageCollectionFixture({"MMM", "PGM", "GP"}, {3, 10}, 37)));

TEST_P(GarbageCollectionTest, Test) {
  GarbageCollectionFixture param = GetParam();
  Solution solution;
  int actual = solution.garbage_collection(param.garbage, param.travel);
  EXPECT_EQ(param.expected, actual);
}
} // namespace leetcode