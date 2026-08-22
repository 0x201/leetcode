#pragma once

#include <vector>

namespace leetcode {

class Node {
public:
  int val;
  std::vector<Node *> children;
  Node(int _val, std::vector<Node *> _children)
      : val(_val), children(_children) {}
};

/// <summary>
/// Definition for singly-linked list.
/// </summary>
struct ListNode {
  int val;
  ListNode *next;
  ListNode() : val(0), next(nullptr) {}
  ListNode(int x) : val(x), next(nullptr) {}
  ListNode(int x, ListNode *next) : val(x), next(next) {}
};

/// <summary>
/// Definition for a binary tree node.
/// </summary>
struct TreeNode {
  int val;
  TreeNode *left;
  TreeNode *right;
  TreeNode() : val(0), left(nullptr), right(nullptr) {}
  TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
  TreeNode(int x, TreeNode *left, TreeNode *right)
      : val(x), left(left), right(right) {}
};
} // namespace leetcode