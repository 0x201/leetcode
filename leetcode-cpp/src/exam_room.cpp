#include "exam_room.h"
namespace leetcode {
int ExamRoom::seat() {
  if (seats.empty()) {
    seats.insert(0);
    return 0;
  }
  int left = *seats.begin(), right = n - 1 - *seats.rbegin();
  while (seats.size() >= 2) {
    auto p = pq.top();
    if (seats.count(p.first) > 0 && seats.count(p.second) > 0 &&
        *std::next(seats.find(p.first)) == p.second) {
      int d = p.second - p.first;
      if (d / 2 < right || d / 2 <= left) {
        break;
      }
      pq.pop();
      pq.push({p.first, p.first + d / 2});
      pq.push({p.first + d / 2, p.second});
      seats.insert(p.first + d / 2);
      return p.first + d / 2;
    }
    pq.pop();
  }
  if (right > left) {
    pq.push({*seats.rbegin(), n - 1});
    seats.insert(n - 1);
    return n - 1;
  } else {
    pq.push({0, *seats.begin()});
    seats.insert(0);
    return 0;
  }
}

void ExamRoom::leave(int p) {
  if (p != *seats.begin() && p != *seats.rbegin()) {
    auto iter = seats.find(p);
    pq.push({*std::prev(iter), *std::next(iter)});
  }
  seats.erase(p);
}
} // namespace leetcode