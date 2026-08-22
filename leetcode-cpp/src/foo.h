#pragma once

#include <functional>
#include <future>
namespace leetcode {
class Foo {
  std::function<void()> task = []() {};
  std::packaged_task<void()> pt1{task}, pt2{task};

public:
  Foo(const Foo &other) {};
  Foo() = default;

  void first(const std::function<void()> &print_first) {
    print_first();
    pt1();
  }
  void second(const std::function<void()> &print_second) {
    pt1.get_future().wait();
    print_second();
    pt2();
  }
  void third(const std::function<void()> &print_third) {
    pt2.get_future().wait();
    print_third();
  }
};
} // namespace leetcode