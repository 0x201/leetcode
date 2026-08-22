#pragma once

#include <list>
#include <set>
#include <string>
#include <unordered_map>
#include <unordered_set>
namespace leetcode {
class AllOne {
  std::list<std::pair<std::unordered_set<std::string>, int>> lst;
  std::unordered_map<
      std::string,
      std::list<std::pair<std::unordered_set<std::string>, int>>::iterator>
      nodes;

public:
  AllOne() {}

  void inc(std::string key) {
    if (nodes.count(key)) {
      auto curr = nodes[key], nxt = next(curr);
      if (nxt == lst.end() || nxt->second > curr->second + 1) {
        std::unordered_set<std::string> s({key});
        nodes[key] = lst.emplace(nxt, s, curr->second + 1);
      } else {
        nxt->first.emplace(key);
        nodes[key] = nxt;
        curr->first.erase(key);
        if (curr->first.empty()) {
          lst.erase(curr);
        }
      }
    } else {
      if (lst.empty() || lst.begin()->second > 1) {
        std::unordered_set<std::string> s({key});
        lst.emplace_front(s, 1);
      } else {
        lst.begin()->first.emplace(key);
      }
      nodes[key] = lst.begin();
    }
  }

  void dec(std::string key) {
    auto curr = nodes[key];
    if (curr->second == 1) {
      nodes.erase(key);
    } else {
      auto pre = prev(curr);
      if (curr == lst.begin() || pre->second < curr->second - 1) {
        std::unordered_set<std::string> s({key});
        nodes[key] = lst.emplace(curr, s, curr->second - 1);
      } else {
        pre->first.emplace(key);
        nodes[key] = pre;
      }
    }
    curr->first.erase(key);
    if (curr->first.empty()) {
      lst.erase(curr);
    }
  }

  std::string get_max_key() {
    return lst.empty() ? "" : *lst.rbegin()->first.begin();
  }

  std::string get_min_key() {
    return lst.empty() ? "" : *lst.begin()->first.begin();
  }
};
} // namespace leetcode