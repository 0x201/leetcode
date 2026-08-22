#include "atm.h"

void atm::deposit(std::vector<int> banknotesCount) {
  for (int i = 0; i < 5; ++i) {
    count[i] += banknotesCount[i];
  }
}

std::vector<int> atm::withdraw(int amount) {
  std::vector<int> res(5);

  for (int i = 4; i >= 0; --i) {
    res[i] = std::min(count[i], amount / value[i]);
    amount -= res[i] * value[i];
  }

  if (amount) {
    return {-1};
  } else {
    for (int i = 0; i < 5; ++i) {
      count[i] -= res[i];
    }

    return res;
  }
}
