#include "pch.h"

#include "../src/codec.h"
#include "../src/utils.h"

using namespace std;

namespace leetcode {
class CodecFixture {
public:
  const char *node;
  const char *expected;

  CodecFixture(const char *node, const char *expected)
      : node(node), expected(expected) {}
};

class CodecTest : public testing::TestWithParam<CodecFixture> {};

INSTANTIATE_TEST_SUITE_P(CodecTestCases, CodecTest,
                         testing::Values(CodecFixture("1,2,3,null,null,4,5",
                                                      "1,2,3,null,null,4,5"),
                                         CodecFixture("", "")));

TEST_P(CodecTest, Test) {
  const CodecFixture param = GetParam();
  const std::string node_str = param.node;
  const std::string expected_str = param.expected;

  const TreeNode *root = Utils::generate_tree_node(node_str);
  std::string nodes = Codec::serialize(root);
  TreeNode *actual = Codec::deserialize(nodes);
  TreeNode *expected = Utils::generate_tree_node(expected_str);
  EXPECT_TRUE(Utils::is_same_tree(expected, actual));

  delete root;
  delete actual;
  delete expected;
}
} // namespace leetcode
