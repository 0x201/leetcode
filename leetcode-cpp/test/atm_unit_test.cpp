#include "pch.h"

#include "../src/atm.h"

using namespace std;

namespace leetcode {

TEST(ATMUnitTest, OperationTest) {
  ATM atm;
  atm.deposit({0, 0, 1, 2, 1});
  std::vector<int> actual1 = atm.withdraw(600);
  std::vector<int> expected1{0, 0, 1, 0, 1};
  EXPECT_EQ(expected1, actual1);
  atm.deposit({0, 1, 0, 1, 1});
  std::vector<int> actual2 = atm.withdraw(600);
  std::vector<int> expected2{-1};
  EXPECT_EQ(expected2, actual2);
  std::vector<int> actual3 = atm.withdraw(550);
  std::vector<int> expected3{0, 1, 0, 0, 1};
  EXPECT_EQ(expected3, actual3);
}
} // namespace leetcode