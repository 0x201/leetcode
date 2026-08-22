#pragma once

#include <queue>
#include <set>
#include <utility>
#include <vector>
namespace leetcode {
struct Comp {
  bool operator()(const std::pair<int, int> &p1,
                  const std::pair<int, int> &p2) {
    int d1 = p1.second - p1.first, d2 = p2.second - p2.first;
    return d1 / 2 < d2 / 2 || (d1 / 2 == d2 / 2 && p1.first > p2.first);
  }
};

class ExamRoom {
private:
  int n;
  std::set<int> seats;
  std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>,
                      Comp>
      pq;

public:
  ExamRoom(int n) : n(n) {}

  int seat();

  void leave(int p);
};
} // namespace leetcode