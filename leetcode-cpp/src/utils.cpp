#include "utils.h"

#include <iostream>
#include <queue>
#include <sstream>
#include <stack>

namespace leetcode {
TreeNode *Utils::generate_tree_node(const std::string &data,
                                    const std::string &delimiter) {
  if (data.empty()) {
    return nullptr;
  }
  const std::vector<std::string> nums = split(data, delimiter);
  if (nums[0] == "null") {
    return nullptr;
  }
  auto *root = new TreeNode(std::stoi(nums[0]));
  std::queue<TreeNode *> q;
  q.push(root);
  bool fill_left = true;
  for (int i = 1; i < nums.size(); i++) {
    TreeNode *node =
        nums[i] == "null" ? nullptr : new TreeNode(std::stoi(nums[i]));
    if (fill_left) {
      q.front()->left = node;
      fill_left = false;
    } else {
      q.front()->right = node;
      fill_left = true;
    }

    if (node != nullptr) {
      q.push(node);
    }

    if (fill_left) {
      q.pop();
    }
  }
  return root;
}

ListNode *Utils::generate_list_node(std::vector<int> &nums) {
  if (nums.empty()) {
    return nullptr;
  }
  auto *head = new ListNode(0);
  ListNode *dummy = head;
  for (const auto &item : nums) {
    dummy->next = new ListNode(item);
    dummy = dummy->next;
  }
  return head->next;
}

ListNode *Utils::detect_cycle(ListNode *head) {
  if (!head) {
    return nullptr;
  }

  const ListNode *slow = head;
  const ListNode *fast = head;

  while (fast) {
    slow = slow->next;
    if (fast->next) {
      fast = fast->next->next;
    } else {
      return nullptr;
    }

    if (fast == slow) {
      ListNode *ptr = head;
      while (ptr != slow) {
        ptr = ptr->next;
        slow = slow->next;
      }
      return ptr;
    }
  }
  return nullptr;
}

std::string Utils::list_node_to_string(ListNode *head,
                                       const std::string &separator) {
  const ListNode *cycle_node = detect_cycle(head);

  std::ostringstream oss;

  while (head) {
    oss << head->val;
    if (head->next) {
      oss << separator;
    }
    head = head->next;
    if (head == cycle_node && head && cycle_node) {
      oss << cycle_node->val << separator << "...";
      break;
    }
  }
  return oss.str();
}

std::vector<std::string> Utils::split(const std::string &input,
                                      const std::string &delimiter) {
  std::vector<std::string> result;

  std::size_t current = 0;
  std::size_t p = input.find_first_of(delimiter, 0);

  while (p != std::string::npos) {
    result.emplace_back(input, current, p - current);
    current = p + 1;
    p = input.find_first_of(delimiter, current);
  }

  result.emplace_back(input, current);

  return result;
}

std::vector<int> Utils::inorder_traversal(TreeNode *root) {
  std::vector<int> res;
  std::stack<TreeNode *> stack;
  const TreeNode *current = root;

  while (current != nullptr || !stack.empty()) {
    while (current != nullptr) {
      stack.push(root);
      current = current->left;
    }
    current = stack.top();
    stack.pop();
    res.emplace_back(current->val);

    current = current->right;
  }
  return res;
}

std::vector<int> Utils::preorder_traversal(TreeNode *root) {
  std::vector<int> res;
  if (root == nullptr) {
    return res;
  }

  std::stack<TreeNode *> stk;
  TreeNode *node = root;
  while (!stk.empty() || node != nullptr) {
    while (node != nullptr) {
      res.emplace_back(node->val);
      stk.emplace(node);
      node = node->left;
    }
    node = stk.top();
    stk.pop();
    node = node->right;
  }
  return res;
}

bool Utils::is_same_tree(TreeNode *lhs, TreeNode *rhs) {
  if (lhs == nullptr && rhs == nullptr) {
    return true;
  } else if (lhs == nullptr || rhs == nullptr) {
    return false;
  }
  std::queue<TreeNode *> q1, q2;
  q1.push(lhs);
  q2.push(rhs);
  while (!q1.empty() && !q2.empty()) {
    const auto node1 = q1.front();
    q1.pop();
    const auto node2 = q2.front();
    q2.pop();
    if (node1->val != node2->val) {
      return false;
    }
    auto left1 = node1->left, right1 = node1->right, left2 = node2->left,
         right2 = node2->right;
    if ((left1 == nullptr) ^ (left2 == nullptr)) {
      return false;
    }
    if ((right1 == nullptr) ^ (right2 == nullptr)) {
      return false;
    }
    if (left1 != nullptr) {
      q1.push(left1);
    }
    if (right1 != nullptr) {
      q1.push(right1);
    }
    if (left2 != nullptr) {
      q2.push(left2);
    }
    if (right2 != nullptr) {
      q2.push(right2);
    }
  }

  return q1.empty() && q2.empty();
}
} // namespace leetcode
