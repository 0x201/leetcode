#include "pch.h"

#include "../src/Foo.h"

using namespace std;

namespace leetcode {

std::future<void> asyncExecute(Foo &foo, std::function<void()> method) {
  return std::async(std::launch::async, method);
}

void waitAndCheckFuture(std::future<void> &fut) {
  fut.wait();
  EXPECT_NO_THROW(fut.get());
}

class PrintOrderFixture {
public:
  vector<int> task_sequences;
  string expected;

  PrintOrderFixture(vector<int> _task_sequences, string _expected)
      : task_sequences(_task_sequences), expected(_expected){};
};

class OrderPrintTest : public testing::TestWithParam<PrintOrderFixture> {};

INSTANTIATE_TEST_SUITE_P(
    PrintOrderTestCases, OrderPrintTest,
    testing::Values(PrintOrderFixture({1, 2, 3}, "firstsecondthird"),
                    PrintOrderFixture({1, 3, 2}, "firstsecondthird"),
                    PrintOrderFixture({2, 1, 3}, "firstsecondthird"),
                    PrintOrderFixture({2, 3, 1}, "firstsecondthird"),
                    PrintOrderFixture({3, 2, 1}, "firstsecondthird"),
                    PrintOrderFixture({3, 1, 2}, "firstsecondthird")));

TEST_P(OrderPrintTest, Test) {
  string actual = "";
  Foo foo;
  PrintOrderFixture fixture = GetParam();
  std::vector<std::future<void>> futures;
  auto printFirst = [&actual]() { actual.append("first"); };
  auto printSecond = [&actual]() { actual.append("second"); };
  auto printThird = [&actual]() { actual.append("third"); };

  for (auto task : fixture.task_sequences) {
    if (task == 1) {
      futures.emplace_back(
          asyncExecute(foo, std::bind(&Foo::first, &foo, printFirst)));
    } else if (task == 2) {
      futures.emplace_back(
          asyncExecute(foo, std::bind(&Foo::second, &foo, printSecond)));
    } else {
      futures.emplace_back(
          asyncExecute(foo, std::bind(&Foo::third, &foo, printThird)));
    }
  }
  for (auto &fut : futures) {
    waitAndCheckFuture(fut);
  }

  EXPECT_EQ(actual, fixture.expected);
}
} // namespace leetcode