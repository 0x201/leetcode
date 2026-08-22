#include "throne_inheritance.h"

#include <functional>
namespace leetcode {
void ThroneInheritance::birth(std::string parent_name, std::string child_name) {
  edges[std::move(parent_name)].emplace_back(std::move(child_name));
}

void ThroneInheritance::death(std::string name) {
  dead.insert(std::move(name));
}

std::vector<std::string> ThroneInheritance::get_inheritance_order() {
  std::vector<std::string> ans;
  std::function<void(const std::string &)> preorder =
      [&](const std::string &name) {
        if (!dead.count(name)) {
          ans.emplace_back(name);
        }

        if (edges.count(name)) {
          for (const std::string &child_name : edges[name]) {
            preorder(child_name);
          }
        }
      };

  preorder(king);
  return ans;
}
} // namespace leetcode