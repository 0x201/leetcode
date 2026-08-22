#include <string>
#include <unordered_map>
#include <unordered_set>
#include <vector>
namespace leetcode {
class ThroneInheritance {
public:
  ThroneInheritance(std::string king_name) : king(std::move(king_name)) {}
  void birth(std::string parent_name, std::string child_name);
  void death(std::string name);
  std::vector<std::string> get_inheritance_order();

private:
  std::unordered_map<std::string, std::vector<std::string>> edges;
  std::unordered_set<std::string> dead;
  std::string king;
};
} // namespace leetcode