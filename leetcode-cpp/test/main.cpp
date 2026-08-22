#include "pch.h"

#include <print>
#include <format>

struct Point {
public:
  float x, y;

  Point(float x, float y) : x(x), y(y) {}
};

template<> struct std::formatter<Point> : std::formatter<std::string> {
  auto format(const Point& p, format_context& context) const {
    return std::formatter<std::string>::format(std::format("({}, {})", p.x, p.y), context);
  }
};

int main(int argc, char **argv) {
  auto original = Point(0.0f, 0.0f);
  auto p1 = Point(1.0f, 1.0f);

  std::println("Original: {}", original);
  std::println("P1: {}", p1);


  testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}