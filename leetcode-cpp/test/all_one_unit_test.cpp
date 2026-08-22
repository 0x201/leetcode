#include "pch.h"

#include "../src/all_one.h"

using namespace std;

namespace leetcode {

TEST(AllOneUnitTest, OperationTest) {
  AllOne allOne;
  allOne.inc("hello");
  allOne.inc("hello");
  string actualMaxKey1 = allOne.get_max_key();
  string expected1 = "hello";
  EXPECT_EQ(expected1, actualMaxKey1);
  string actualMinKey1 = allOne.get_min_key();
  string expected2 = "hello";
  EXPECT_EQ(expected2, actualMinKey1);
  allOne.inc("leet");
  string actualMaxKey2 = allOne.get_max_key();
  string expected3 = "hello";
  EXPECT_EQ(expected3, actualMaxKey2);
  string actualMinKey2 = allOne.get_min_key();
  string expected4 = "leet";
  EXPECT_EQ(expected4, actualMinKey2);
}
} // namespace leetcode