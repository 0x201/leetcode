#pragma once

#include <list>
#include <stack>
#include <string>

#include "data_structure.h"

namespace leetcode {
class Codec {
public:
  static std::string serialize(const TreeNode *root) {
    std::string res;
    std::stack<const TreeNode *> stack;
    const TreeNode *current = root;

    while (current != nullptr || !stack.empty()) {
      while (current != nullptr) {
        res += std::to_string(current->val) + ",";
        stack.push(current);
        current = current->left;
      }
      res += "null,";

      if (!stack.empty()) {
        current = stack.top();
        stack.pop();
        current = current->right;
      }
    }

    return res;
  }

  static TreeNode *deserialize(std::string &data) {
    if (data.empty()) {
      return nullptr;
    }

    std::list<std::string> nodes;
    std::string token;
    for (const auto &ch : data) {
      if (ch == ',') {
        nodes.emplace_back(token);
        token.clear();
      } else {
        token += ch;
      }
    }

    if (!token.empty()) {
      nodes.emplace_back(token);
    }

    auto *root = new TreeNode(std::stoi(nodes.front()));
    nodes.pop_front();

    std::stack<TreeNode *> stack;
    TreeNode *current = root;
    bool is_left = true;

    while (!nodes.empty()) {
      std::string val = nodes.front();
      nodes.pop_front();

      if (val != "null") {
        auto *node = new TreeNode(std::stoi(val));
        if (is_left) {
          current->left = node;
          stack.push(current);
          current = node;
        } else {
          current->right = node;
          current = node;
          is_left = true;
        }
      } else {
        if (is_left) {
          current->left = nullptr;
          is_left = false;
        } else {
          current->right = nullptr;
          if (!stack.empty()) {
            current = stack.top();
            stack.pop();
            is_left = false;
          }
        }
      }
    }

    return root;
  }
};
} // namespace leetcode
