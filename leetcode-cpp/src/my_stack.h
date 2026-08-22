#pragma once

#include <queue>
namespace leetcode {
class MyStack {
public:
  MyStack() {}

  void push(int x) {
    size_t n = q.size();
    q.push(x);
    for (int i = 0; i < n; i++) {
      q.push(q.front());
      q.pop();
    }
  }

  int pop() {
    int r = q.front();
    q.pop();
    return r;
  }

  int top() {
    int r = q.front();
    return r;
  }

  bool empty() { return q.empty(); }

private:
  std::queue<int> q;
};
} // namespace leetcode