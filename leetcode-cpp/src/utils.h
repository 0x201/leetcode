#pragma once

#include <string>
#include <vector>

#include "data_structure.h"

namespace leetcode {
class Utils {
public:
  static TreeNode *generate_tree_node(const std::string &data,
                                      const std::string &delimiter = ",");

  static ListNode *generate_list_node(std::vector<int> &nums);

  static ListNode *detect_cycle(ListNode *head);

  static std::string list_node_to_string(ListNode *head,
                                         const std::string &separator = "->");

  static std::vector<std::string> split(const std::string &input,
                                        const std::string &delimiter);

  static std::vector<int> inorder_traversal(TreeNode *root);

  static std::vector<int> preorder_traversal(TreeNode *root);

  static bool is_same_tree(TreeNode *lhs, TreeNode *rhs);
};
} // namespace leetcode
