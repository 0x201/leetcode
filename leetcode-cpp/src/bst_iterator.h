#pragma once
#include <stack>

#include "data_structure.h"
namespace leetcode {
class BSTIterator {
private:
  std::stack<TreeNode *> nodes;

public:
  BSTIterator(TreeNode *root) {
    while (root) {
      nodes.push(root);
      root = root->left;
    }
  }

  /// <summary>
  /// return the next smallest number.
  /// </summary>
  /// <returns></returns>
  int next() {
    const TreeNode *tmp = nodes.top();
    nodes.pop();
    TreeNode *right = tmp->right;
    while (right) {
      nodes.push(right);
      right = right->left;
    }
    return tmp->val;
  }

  /// <summary>
  ///  Check whether there is a next smallest number.
  /// </summary>
  /// <returns></returns>
  bool has_next() const { return !nodes.empty(); }
};
} // namespace leetcode