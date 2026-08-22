#pragma once

#include <stack>
namespace leetcode {
class MinStack {
public:
  MinStack() { min.push(INT_MAX); }

  void push(int val) {
    x.push(val);
    min.push(std::min(min.top(), val));
  }

  void pop() {
    x.pop();
    min.pop();
  }

  int top() { return x.top(); }

  int getMin() { return min.top(); }

private:
  std::stack<int> min;
  std::stack<int> x;
};
} // namespace leetcode