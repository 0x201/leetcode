#include "pch.h"

#include <string>
#include <vector>

#include "../src/throne_inheritance.h"

using namespace std;
namespace leetcode {
TEST(SolutionUnitTest, ThroneInheritanceTest) {
  ThroneInheritance t("king");
  t.birth("king", "andy");
  t.birth("king", "bob");
  t.birth("king", "catherine");
  t.birth("andy", "matthew");
  t.birth("bob", "alex");
  t.birth("bob", "asha");
  vector<string> actual1 = t.get_inheritance_order();
  vector<string> expected1{"king", "andy", "matthew",  "bob",
                           "alex", "asha", "catherine"};
  ASSERT_EQ(expected1, actual1);
  t.death("bob");
  vector<string> actual2 = t.get_inheritance_order();
  vector<string> expected2{"king", "andy", "matthew",
                           "alex", "asha", "catherine"};
  ASSERT_EQ(expected2, actual2);
}
} // namespace leetcode