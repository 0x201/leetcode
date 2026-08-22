#include "solution.h"
#include "utils.h"

#include <algorithm>
#include <bitset>
#include <cmath>
#include <functional>
#include <limits>
#include <numeric>
#include <queue>
#include <regex>
#include <set>
#include <sstream>
#include <stack>
#include <unordered_map>
#include <unordered_set>

constexpr int min_int = std::numeric_limits<int>::min();
constexpr int max_int = std::numeric_limits<int>::max();

namespace leetcode {
std::vector<int> Solution::two_sum(std::vector<int> &nums, int target) {
  size_t size = nums.size();
  std::unordered_map<int, int> hash;
  for (int i = 0; i < size; i++) {
    auto iter = hash.find(target - nums[i]);
    if (iter != hash.end()) {
      return {iter->second, i};
    }
    hash[nums[i]] = i;
  }
  return {};
}

ListNode *Solution::add_two_numbers(ListNode *l1, ListNode *l2) {
  if (l1 == nullptr && l2 == nullptr)
    return nullptr;
  ListNode *head = new ListNode(0);
  ListNode *current = head;
  int carry = 0;
  while (l1 || l2) {
    int sum = (l1 ? l1->val : 0) + (l2 ? l2->val : 0) + carry;
    carry = sum / 10;
    current->next = new ListNode(sum % 10);
    if (l1)
      l1 = l1->next;
    if (l2)
      l2 = l2->next;
    current = current->next;
  }
  if (carry)
    current->next = new ListNode(carry);
  return head->next;
}

int Solution::length_of_longest_substring(std::string s) {
  std::vector<int> dic(256, -1);
  int maxlen = 0, start = -1;
  size_t len = s.length();
  for (int i = 0; i != len; i++) {
    if (dic[s[i]] > start)
      start = dic[s[i]];
    dic[s[i]] = i;
    maxlen = std::max(maxlen, i - start);
  }
  return maxlen;
}

double Solution::find_median_sorted_arrays(std::vector<int> &nums1,
                                           std::vector<int> &nums2) {
  int m = (int)nums1.size();
  int n = (int)nums2.size();
  if (m > n) {
    std::swap(nums1, nums2);
    std::swap(m, n);
  }
  int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;

  while (iMin <= iMax) {
    int i = (iMin + iMax) / 2;
    int j = halfLen - i;
    if (i < iMax && nums2[j - 1] > nums1[i])
      iMin++;
    else if (i > iMin && nums1[i - 1] > nums2[j])
      iMax--;
    else {
      int maxLeft = 0;
      if (i == 0)
        maxLeft = nums2[j - 1];
      else if (j == 0)
        maxLeft = nums1[i - 1];
      else
        maxLeft = std::max(nums1[i - 1], nums2[j - 1]);
      if ((m + n) % 2 == 1)
        return maxLeft;

      int minRight = 0;
      if (i == m)
        minRight = nums2[j];
      else if (j == n)
        minRight = nums1[i];
      else
        minRight = std::min(nums1[i], nums2[j]);
      return (maxLeft + minRight) / 2.0;
    }
  }
  return 0.0;
}

std::string Solution::longest_palindrome(std::string s) {
  std::function<std::string(std::string)> preprocess = [](std::string s) {
    auto n = s.length();
    if (n == 0)
      return std::string("^$");
    std::string ret = "^";
    for (auto i = 0; i < n; i++)
      ret += "#" + s.substr(i, 1);
    ret += "#$";
    return ret;
  };

  auto T = preprocess(s);
  auto n = T.length();
  auto *P = new int[n];
  auto C = 0, R = 0;
  for (int i = 1; i < n - 1; i++) {
    int i_mirror = 2 * C - i;

    P[i] = (R > i) ? std::min(R - i, P[i_mirror]) : 0;
    while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
      P[i]++;
    if (i + P[i] > R) {
      C = i;
      R = i + P[i];
    }
  }
  auto maxLen = 0;
  auto centerIndex = 0;
  for (auto i = 1; i < n - 1; i++) {
    if (P[i] > maxLen) {
      maxLen = P[i];
      centerIndex = i;
    }
  }
  delete[] P;

  return s.substr((centerIndex - 1 - maxLen) / 2, maxLen);
}

std::string Solution::convert(std::string s, int numRows) {
  if (numRows == 1)
    return s;
  std::string ret;
  size_t n = s.size();
  int cycleLen = 2 * numRows - 2;

  for (int i = 0; i < numRows; i++) {
    for (int j = 0; j + i < n; j += cycleLen) {
      ret += s[j + i];
      if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
        ret += s[j + cycleLen - i];
    }
  }
  return ret;
}

int Solution::reverse(int x) {
  int res = 0;
  while (x) {
    int pop = x % 10;
    x /= 10;
    if (res > max_int / 10 || (res == max_int / 10 && pop > 7))
      return 0;
    if (res < min_int / 10 || (res == min_int / 10 && pop < -8))
      return 0;
  }
  return res;
}

int Solution::atoi(std::string str) {
  if (str.empty())
    return 0;
  int sign = 1;
  int bas = 0;
  size_t i = 0;
  size_t len = str.size();
  while (str[i] == ' ')
    i++;
  if (str[i] == '-' || str[i] == '+')
    sign = str[i++] == '-' ? -1 : 1;
  while (i < len && str[i] >= '0' && str[i] <= '9') {
    if (bas > max_int / 10 || (bas == max_int / 10 && str[i] - '0' > 7)) {
      return sign == 1 ? max_int : min_int;
    }
    bas = 10 * bas + (str[i++] - '0');
  }
  return bas * sign;
}

bool Solution::is_palindrome(int x) {
  if (x < 0 || (x != 0 && x % 10 == 0))
    return false;
  int res = 0;
  while (res < x) {
    res = res * 10 + x % 10;
    x /= 10;
  }
  return (x == res || x == res / 10);
}

bool Solution::is_match(std::string s, std::string p) {
  size_t m = s.size(), n = p.size();
  std::vector<std::vector<bool>> f(m + 1, std::vector<bool>(n + 1, false));
  f[0][0] = true;
  for (size_t i = 1; i <= m; i++)
    f[i][0] = false;
  for (size_t j = 1; j <= n; j++)
    f[0][j] = j > 1 && '*' == p[j - 1] && f[0][j - 2];

  for (size_t i = 1; i <= m; i++)
    for (size_t j = 1; j <= n; j++)
      if (p[j - 1] != '*')
        f[i][j] = f[i - 1][j - 1] && (s[i - 1] == p[j - 1] || '.' == p[j - 1]);
      else
        f[i][j] = f[i][j - 2] ||
                  (s[i - 1] == p[j - 2] || '.' == p[j - 2]) && f[i - 1][j];
  return f[m][n];
}

int Solution::max_area(std::vector<int> &height) {
  int maxArea = 0;
  size_t left = 0, right = height.size() - 1;
  while (left < right) {
    maxArea = std::max(maxArea, std::min(height[left], height[right]) *
                                    (int)(right - left));
    if (height[left] < height[right])
      left++;
  }
  return maxArea;
}

std::string Solution::int_to_roman(int num) {
  std::vector<std::string> M = {"", "M", "MM", "MMM"};
  std::vector<std::string> C = {"",  "C",  "CC",  "CCC",  "CD",
                                "D", "DC", "DCC", "DCCC", "CM"};
  std::vector<std::string> X = {"",  "X",  "XX",  "XXX",  "XL",
                                "L", "LX", "LXX", "LXXX", "XC"};
  std::vector<std::string> I = {"",  "I",  "II",  "III",  "IV",
                                "V", "VI", "VII", "VIII", "IX"};
  return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] +
         I[num % 10];
}

int Solution::roman_to_integer(std::string s) {
  std::unordered_map<char, int> dic = {{'I', 1},   {'V', 5},   {'X', 10},
                                       {'L', 50},  {'C', 100}, {'D', 500},
                                       {'M', 1000}};
  int value = 0;
  char prev = s[0];
  for (auto &curr : s) {
    value += dic[curr];
    if (dic[prev] < dic[curr])
      value -= dic[prev] * 2;
    prev = curr;
  }
  return value;
}

std::string Solution::longest_common_prefix(std::vector<std::string> &strs) {
  // TODO
  return "";
}

std::vector<std::vector<int>> Solution::three_sum(std::vector<int> &nums) {
  std::vector<std::vector<int>> res;
  int count = (int)nums.size();
  std::sort(nums.begin(), nums.end());
  for (int i = 0; i < count; i++) {
    int target = -nums[i];
    int left = i + 1;
    int right = count - 1;
    if (target < 0)
      break;
    while (left < right) {
      int sum = nums[left] + nums[right];
      if (sum < target)
        left++;
      else if (sum > target)
        right--;
      else {
        std::vector<int> tmp{nums[i], nums[left], nums[right]};
        res.emplace_back(tmp);
        while (left < right && nums[left] == tmp[1])
          left++;
        while (left < right && nums[right] == tmp[2])
          right--;
      }
    }
    while (i + 1 < count && nums[i + 1] == nums[i])
      i++;
  }
  return res;
}

int Solution::three_sum_closest(std::vector<int> &nums, int target) {
  if (nums.size() < 3)
    return 0;
  int closest = nums[0] + nums[1] + nums[2];
  sort(nums.begin(), nums.end());
  for (int first = 0; first < nums.size() - 2; first++) {
    if (first > 0 && nums[first] == nums[first - 1])
      continue;
    int second = first + 1;
    int third = (int)nums.size() - 1;
    while (second < third) {
      int currentSum = nums[first] + nums[second] + nums[third];
      if (currentSum == target)
        return currentSum;
      if (abs(target - currentSum) < abs(target - closest)) {
        closest = currentSum;
      }
      if (currentSum > target) {
        third--;
      } else {
        second++;
      }
    }
  }
  return closest;
}

std::vector<std::string> Solution::letter_combinations(std::string digits) {
  std::vector<std::string> result;
  if (digits.empty())
    return result;
  static const std::vector<std::string> maps = {
      "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
  result.emplace_back("");
  for (const auto &digit : digits) {
    const int num = digit - '0';
    if (num < 0 || num > 9)
      break;
    const std::string &candidate = maps[num];
    if (candidate.empty())
      continue;
    std::vector<std::string> tmp;
    for (const auto &c : candidate)
      for (const auto &r : result)
        tmp.emplace_back(r + c);
    result.swap(tmp);
  }
  return result;
}

std::vector<std::vector<int>> Solution::four_sum(std::vector<int> &nums,
                                                 int target) {
  std::vector<std::vector<int>> res;
  size_t n = nums.size();
  if (n < 4)
    return res;
  std::sort(nums.begin(), nums.end());
  for (size_t i = 0; i < n - 3; i++) {
    if (i > 0 && nums[i] == nums[i - 1])
      continue;
    if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
      break;
    if (nums[i] + nums[n - 3] + nums[n - 2] + nums[n - 1] < target)
      continue;
    for (size_t j = i + 1; j < n - 2; j++) {
      if (j > i + 1 && nums[j] == nums[j - 1])
        continue;
      if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
        break;
      if (nums[i] + nums[j] + nums[n - 2] + nums[n - 1] < target)
        continue;
      size_t left = j + 1, right = n - 1;
      while (left < right) {
        int sum = nums[left] + nums[right] + nums[i] + nums[j];
        if (sum < target)
          left++;
        else if (sum > target)
          right--;
        else {
          res.emplace_back(
              std::vector<int>{nums[i], nums[j], nums[left], nums[right]});
          do {
            left++;
          } while (nums[left] == nums[left - 1] && left < right);
          do {
            right--;
          } while (nums[right] == nums[right + 1] && left < right);
        }
      }
    }
  }
  return res;
}

ListNode *Solution::remove_nth_from_end(ListNode *head, int n) {
  if (n <= 0)
    return head;

  ListNode dummy(0);
  dummy.next = head;
  ListNode *first = &dummy;
  ListNode *second = &dummy;
  for (int i = 0; i < n + 1; ++i) {
    if (!first)
      return head;
    first = first->next;
  }
    
  while (first) {
    first = first->next;
    second = second->next;
  }

  if (second->next) {
    ListNode *to_delete = second->next;
    second->next = second->next->next;
    delete to_delete;
  }
  return dummy.next;
}

bool Solution::is_valid(std::string s) {
  std::stack<char> stack;
  for (char item : s) {
    if (item == '(' || item == '{' || item == '[')
      stack.push(item);
    else {
      if (stack.empty())
        return false;
      if (item == ')' && stack.top() != '(')
        return false;
      if (item == '}' && stack.top() != '{')
        return false;
      if (item == ']' && stack.top() != '[')
        return false;
      stack.pop();
    }
  }
  return stack.empty();
}

ListNode *Solution::merge_two_lists(ListNode *l1, ListNode *l2) {
  // Recursive
  if (l1 == nullptr)
    return l2;
  if (l2 == nullptr)
    return l1;
  ListNode *ans = nullptr;
  if (l1->val < l2->val) {
    ans = l1;
    ans->next = merge_two_lists(l1->next, l2);
  } else {
    ans = l2;
    ans->next = merge_two_lists(l1, l2->next);
  }
  return ans;
  // Iteratively
  // ListNode head(0);
  // ListNode* point = &head;
  // while (l1 != nullptr && l2 != nullptr) {
  //    if (l1->val <= l2->val) {
  //        point->next = l1;
  //        l1 = l1->next;
  //    } else {
  //        point->next = l2;
  //        l2 = l2->next;
  //    }
  //    point = point->next;
  //}
  // if (l1 == nullptr)
  //    point->next = l2;
  // if(l2 == nullptr)
  //    point->next = l1;
  // return head.next;
}

std::vector<std::string> Solution::generate_parenthesis(int n) {
  std::vector<std::string> ans;
  if (n == 0)
    ans.emplace_back("");
  else {
    for (int c = 0; c < n; c++)
      for (const auto &left : generate_parenthesis(c))
        for (const auto &right : generate_parenthesis(n - 1 - c))
          ans.emplace_back("(" + left + ")" += right);
  }
  return ans;
}

struct comp {
  bool operator()(ListNode *lhs, ListNode *rhs) { return lhs->val > rhs->val; }
};

ListNode *Solution::merge_k_lists(std::vector<ListNode *> &lists) {
  // int len = lists.size();
  // int interval = 1;
  // while (interval < len) {
  //   for (int i = 0; i < len - interval; i += interval * 2)
  //     lists[i] = mergeTwoLists(lists[i], lists[i + interval]);
  //   interval *= 2;
  // }
  // return len > 0 ? lists[0] : nullptr;

  std::priority_queue<ListNode *, std::vector<ListNode *>, comp> pq;
  for (auto head : lists) {
    if (head) {
      pq.push(head);
    }
  }
  ListNode *head = new ListNode(), *tail = head;
  while (!pq.empty()) {
    auto curr = pq.top();
    pq.pop();
    tail->next = curr;
    tail = tail->next;
    if (curr->next) {
      pq.push(curr->next);
    }
  }
  return head->next;
}

ListNode *Solution::swap_pairs(ListNode *head) {
  ListNode **pp = &head, *a, *b;
  while ((a = *pp) && (b = a->next)) {
    a->next = b->next;
    b->next = a;
    *pp = b;
    pp = &(a->next);
  }
  return head;
}

ListNode *Solution::reverse_k_group(ListNode *head, int k) {
  if (k <= 1 || !head)
    return head;

  int n = 0;
  for (ListNode *i = head; i; n++, i = i->next);

  ListNode dummy(-1);
  dummy.next = head;
  ListNode *prev = &dummy;
  ListNode *tail = head;

  while (n >= k) {
    for (int i = 1; i < k && tail && tail->next; i++) {
      ListNode *next = tail->next;
      if (!next)
        break;

      tail->next= next->next;
      next->next = prev->next;
      prev->next = next;
    }
    prev = tail;
    tail = tail ? tail->next : nullptr;
    n -= k;
  }
  return dummy.next;
}

int Solution::remove_duplicates(std::vector<int> &nums) {
  int i = nums.empty() ? 1 : 0;
  for (const auto &n : nums)
    if (n > nums[i - 1])
      nums[i++] = n;
  return i;
}

int Solution::remove_element(std::vector<int> &nums, int val) {
  int len = nums.size();
  int found = 0;
  for (int i = 0; i < len; i++) {
    if (found > 0)
      nums[i - found] = nums[i];
    if (nums[i] == val)
      found++;
  }
  return len - found;
}

int Solution::str_str(std::string haystack, std::string needle) {
  int m = haystack.length(), n = needle.length();
  // empty string return 0
  if (!n)
    return 0;

  std::function<std::vector<int>(std::string &)> kmp_process =
      [](std::string &needle) {
        int n = needle.length();
        std::vector<int> lps(n, 0);
        for (int i = 1, len = 0; i < n;) {
          if (needle[i] == needle[len])
            lps[i++] = ++len;
          else if (len)
            len = lps[len - 1];
          else
            lps[i++] = 0;
        }
        return lps;
      };

  std::vector<int> lps = kmp_process(needle);
  for (int i = 0, j = 0; i < m;) {
    if (haystack[i] == needle[j]) {
      i++;
      j++;
    }
    if (j == n)
      return i - j;
    if (i < m && haystack[i] != needle[j]) {
      if (j)
        j = lps[j - 1];
      else
        i++;
    }
  }
  return -1;
}

int Solution::divide(int dividend, int divisor) {
  // divisor = 0 dividend = INT_MIN  divisor = -1
  if (divisor == 0 || (dividend == min_int && divisor == -1))
    return max_int;
  int sign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
  long dvd = labs(dividend);
  long dvs = labs(divisor);
  long res = 0;
  while (dvd >= dvs) {
    long tmp = dvs;
    int multiple = 1;
    while (dvd >= (tmp << 1)) {
      tmp <<= 1;
      multiple <<= 1;
    }
    dvd -= tmp;
    res += multiple;
  }
  return sign * res;
}

std::vector<int> Solution::find_substring(std::string s,
                                          std::vector<std::string> &words) {
  if (s.empty() || words.empty())
    return {};
  int n = s.size();
  int size = words.size();
  int len = words[0].size();
  std::unordered_map<std::string, int> map;
  for (auto &word : words)
    map[word]++;
  std::vector<int> ret;
  for (int i = 0; i < len; i++) {
    int left = i, count = 0;
    std::unordered_map<std::string, int> window;
    for (int j = i; j + len - 1 < n; j += len) {
      std::string str = s.substr(j, len);
      if (map.contains(str) == 0) {
        window.clear();
        count = 0;
        left = j + len;
      } else {
        window[str]++;
        count++;
        while (left + len - 1 < n && window[str] > map[str]) {
          window[s.substr(left, len)]--;
          count--;
          left += len;
        }
        if (count == size) {
          ret.emplace_back(left);
          window[s.substr(left, len)]--;
          count--;
          left += len;
        }
      }
    }
  }
  return ret;
}

void Solution::next_permutation(std::vector<int> &nums) {
  int len = nums.size() - 1;
  int i = len - 1;
  while (i >= 0 && nums[i + 1] <= nums[i])
    i--;
  if (i >= 0) {
    int j = len;
    while (j >= 0 && nums[j] <= nums[i])
      j--;
    std::swap(nums[i], nums[j]);
  }
  std::reverse(nums.begin() + i + 1, nums.end());
}

int Solution::longest_valid_parentheses(std::string &s) {
  int left = 0, right = 0, maxLen = 0;
  int len = s.size() - 1;
  for (int i = 0; i < len; i++) {
    if (s[i] == '(') {
      left++;
    } else {
      right++;
    }
    if (left == right) {
      maxLen = std::max(maxLen, 2 * right);
    } else if (right > left) {
      left = right = 0;
    }
  }
  left = right = 0;
  for (int i = len; i >= 0; i--) {
    if (s[i] == '(') {
      left++;
    } else {
      right++;
    }
    if (left == right) {
      maxLen = std::max(maxLen, 2 * left);
    } else if (left > right) {
      left = right = 0;
    }
  }
  return maxLen;
}

int Solution::search_in_sorted_array(std::vector<int> &nums, int target) {
  int n = (int)nums.size();
  if (n == 0) {
    return -1;
  }
  if (n == 1) {
    return nums[0] == target ? 0 : -1;
  }
  int l = 0, r = n - 1;
  while (l <= r) {
    int mid = (l + r) / 2;
    if (nums[mid] == target) {
      return mid;
    }
    if (nums[0] <= nums[mid]) {
      if (nums[0] <= target && target < nums[mid]) {
        r = mid - 1;
      } else {
        l = mid + 1;
      }
    } else {
      if (nums[mid] < target && target <= nums[n - 1]) {
        l = mid + 1;
      } else {
        r = mid - 1;
      }
    }
  }
  return -1;
}

std::vector<int> Solution::search_range(std::vector<int> &nums, int target) {
  // binary-search
  if (nums.empty())
    return {-1, -1};
  int lo = 0, hi = nums.size() - 1;
  while (lo < hi) {
    int mid = lo + (hi - lo) / 2;
    if (nums[mid] >= target)
      hi = mid;
    else
      lo = mid + 1;
  }
  int first = (nums[lo] == target ? lo : -1);
  if (first == -1)
    return {-1, -1};
  lo = first, hi = nums.size() - 1;
  while (lo < hi) {
    int mid = lo + (hi - lo + 1) / 2;
    if (nums[mid] <= target)
      lo = mid;
    else
      hi = mid - 1;
  }
  return {first, lo};
}

int Solution::search_insert(std::vector<int> &nums, int target) {
  int lo = 0, hi = nums.size() - 1;
  while (lo < hi) {
    int mid = lo + (hi - lo) / 2;
    if (nums[mid] < target)
      lo = mid + 1;
    else
      hi = mid;
  }
  return nums[lo] < target ? lo + 1 : lo;
}

bool Solution::is_valid_sudoku(std::vector<std::vector<char>> &board) {
  int rows[9][9] = {0};
  int cols[9][9] = {0};
  int blocks[3][3][9] = {0};
  for (int r = 0; r < 9; r++)
    for (int c = 0; c < 9; c++)
      if (board[r][c] != '.') {
        int number = board[r][c] - '1';
        if (rows[r][number]++ || cols[c][number]++ ||
            blocks[r / 3][c / 3][number]++)
          return false;
      }
  return true;
}

void Solution::solve_sudoku(std::vector<std::vector<char>> &board) {

  std::function<bool(std::vector<std::vector<char>> &, int, int, int)>
      is_valid_sudoku = [](std::vector<std::vector<char>> &board, int row,
                           int col, char num) {
        int blkrow = (row / 3) * 3, blkcol = (col / 3) * 3;
        for (int i = 0; i < 9; i++)
          if (board[i][col] == num || board[row][i] == num ||
              board[blkrow + i / 3][blkcol + i % 3] == num)
            return false;
        return true;
      };

  std::function<bool(std::vector<std::vector<char>> &, int, int)> do_solve =
      [&is_valid_sudoku, &do_solve](std::vector<std::vector<char>> &board,
                                    int row, int col) {
        for (int i = row; i < 9; i++, col = 0) {
          for (int j = col; j < 9; j++) {
            if (board[i][j] != '.')
              continue;
            for (char num = '1'; num <= '9'; num++) {
              if (is_valid_sudoku(board, i, j, num)) {
                board[i][j] = num;
                if (do_solve(board, i, j + 1))
                  return true;
                board[i][j] = '.';
              }
            }
            return false;
          }
        }
        return true;
      };

  do_solve(board, 0, 0);
}

std::string Solution::count_and_say(int n) {
  if (n == 0)
    return "";
  std::string res = "1";
  while (--n) {
    std::string tmp = "";
    for (int i = 0; i < res.size(); i++) {
      int count = 1;
      while (i + 1 < res.size() && res[i] == res[i + 1]) {
        count++;
        i++;
      }
      tmp += std::to_string(count) + res[i];
    }
    res = tmp;
  }
  return res;
}

std::vector<std::vector<int>>
Solution::combination_sum(std::vector<int> &candidates, int target) {
  std::vector<std::vector<int>> ans;
  std::vector<int> combine;

  std::function<void(std::vector<int> &, int, std::vector<std::vector<int>> &,
                     std::vector<int> &, int)>
      dfs = [&dfs](std::vector<int> &candidates, int target,
                   std::vector<std::vector<int>> &ans,
                   std::vector<int> &combine, int idx) {
        if (idx == candidates.size()) {
          return;
        }
        if (target == 0) {
          ans.emplace_back(combine);
          return;
        }
        dfs(candidates, target, ans, combine, idx + 1);
        if (target - candidates[idx] >= 0) {
          combine.emplace_back(candidates[idx]);
          dfs(candidates, target - candidates[idx], ans, combine, idx);
          combine.pop_back();
        }
      };

  dfs(candidates, target, ans, combine, 0);
  return ans;
}

std::vector<std::vector<int>>
Solution::combination_sum2(std::vector<int> &candidates, int target) {
  return {};
}

int Solution::first_missing_positive(std::vector<int> &nums) {
  size_t n = nums.size();
  for (size_t i = 0; i < n; i++) {
    while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
      std::swap(nums[i], nums[nums[i] - 1]);
  }
  for (size_t i = 0; i < n; i++) {
    if (nums[i] != i + 1)
      return i + 1;
  }
  return n + 1;
}

std::string Solution::multiply(std::string num1, std::string num2) {
  int m = num1.size(), n = num2.size();
  std::string sum(m + n, '0');
  for (int i = m - 1; i >= 0; i--) {
    for (int j = n - 1; j >= 0; j--) {
      int mul = (sum[i + j + 1] - '0') + (num1[i] - '0') * (num2[j] - '0');
      sum[i + j + 1] = mul % 10 + '0';
      sum[i + j] += mul / 10;
    }
  }
  for (int i = 0; i < m + n; i++) {
    if (sum[i] != '0')
      return sum.substr(i);
  }
  return "0";
}

double Solution::my_power(double x, int n) {
  double res = 1.0;
  for (int i = n; i != 0; i /= 2) {
    if (i % 2 != 0)
      res *= x;
    x *= x;
  }
  return n < 0 ? 1 / res : res;
}

std::vector<std::vector<std::string>> Solution::solve_n_queens(int n) {
  std::vector<std::vector<std::string>> res;
  std::vector<std::string> n_queens(n, std::string(n, '.'));
  std::vector<int> flag(5 * n - 2, 1);

  std::function<void(std::vector<std::vector<std::string>> &,
                     std::vector<std::string>, std::vector<int> &, int, int &)>
      do_solve = [&do_solve](std::vector<std::vector<std::string>> &res,
                             std::vector<std::string> n_queens,
                             std::vector<int> &flag, int row, int &n) {
        if (row == n) {
          res.emplace_back(n_queens);
          return;
        }
        for (int col = 0; col != n; ++col) {
          if (flag[col] && flag[n + row + col] && flag[4 * n - 2 + col - row]) {
            flag[col] = flag[n + row + col] = flag[4 * n - 2 + col - row] = 0;
            n_queens[row][col] = 'Q';
            do_solve(res, n_queens, flag, row + 1, n);
            n_queens[row][col] = '.';
            flag[col] = flag[n + row + col] = flag[4 * n - 2 + col - row] = 1;
          }
        }
      };

  do_solve(res, n_queens, flag, 0, n);
  return res;
}

std::vector<int> Solution::spiral_order(std::vector<std::vector<int>> &matrix) {
  if (matrix.empty())
    return {};
  int start_row = 0, start_column = 0;
  size_t height = matrix.size(), width = matrix[0].size();
  std::vector<int> result;
  while (true) {
    if (height == 0 || width == 0)
      break;
    for (int col = start_column; col < start_column + width; col++)
      result.emplace_back(matrix[start_row][col]);
    start_row++;
    height--;
    if (height == 0 || width == 0)
      break;
    for (int row = start_row; row < start_row + height; row++)
      result.emplace_back(matrix[row][start_column + width - 1]);
    width--;
    if (height == 0 || width == 0)
      break;
    for (int col = start_column + width - 1; col >= start_column; col--)
      result.emplace_back(matrix[start_row + height - 1][col]);
    height--;
    if (height == 0 || width == 0)
      break;
    for (int row = start_row + height - 1; row >= start_row; row--)
      result.emplace_back(matrix[row][start_column]);
    start_column++;
    width--;
  }
  return result;
}

bool Solution::can_jump(std::vector<int> &nums) {
  int n = nums.size();
  if (n <= 1)
    return false;
  int i = 0;
  for (int reach = 0; i < n && i <= reach; i++) {
    reach = std::max(i + nums[i], reach);
  }
  return i == n;
}

int Solution::length_of_last_word(std::string s) {
  int len = 0, tail = s.length() - 1;
  while (tail >= 0 && s[tail] == ' ')
    tail--;
  while (tail >= 0 && s[tail] != ' ') {
    len++;
    tail--;
  }
  return len;
}

std::vector<std::vector<int>> Solution::generate_matrix(int n) {
  std::vector<std::vector<int>> matrix(n, std::vector<int>(n));
  if (n == 0)
    return matrix;
  int startRow = 0, startColumn = 0;
  int index = 1, height = n, width = n;
  while (true) {
    if (height == 0 || width == 0)
      break;
    for (int col = startColumn; col < startColumn + width; col++)
      matrix[startRow][col] = index++;
    startRow++;
    height--;
    if (height == 0 || width == 0)
      break;
    for (int row = startRow; row < startRow + height; row++)
      matrix[row][startColumn + width - 1] = index++;
    width--;
    if (height == 0 || width == 0)
      break;
    for (int col = startColumn + width - 1; col >= startColumn; col--)
      matrix[startRow + height - 1][col] = index++;
    height--;
    if (height == 0 || width == 0)
      break;
    for (int row = startRow + height - 1; row >= startRow; row--)
      matrix[row][startColumn] = index++;
    startColumn++;
    width--;
  }
  return matrix;
}

ListNode *Solution::rotate_right(ListNode *head, int k) {
  if (head == nullptr)
    return nullptr;
  if (head->next == nullptr)
    return head;
  ListNode *old_tail = head;
  int n;
  for (n = 1; old_tail->next; n++)
    old_tail = old_tail->next;
  old_tail->next = head;
  ListNode *new_tail = head;
  for (int i = 0; i < n - k % n - 1; i++)
    new_tail = new_tail->next;
  ListNode *new_head = new_tail->next;
  new_tail->next = nullptr;
  return new_head;
}

int Solution::unique_paths(int m, int n) {
  std::vector<int> dp(n, 1);
  for (int i = 1; i < m; i++)
    for (int j = 1; j < n; j++)
      dp[j] += dp[j - 1];
  return dp[n - 1];
}

int Solution::unique_paths_with_obstacles(
    std::vector<std::vector<int>> &obstacleGrid) {
  // int height = obstacleGrid.size();
  // int width = obstacleGrid[0].size();
  // std::vector<long> dp(height, 0);
  // for(int i = 0; i < height; i++) {
  //   if(!obstacleGrid[i][0])
  //     dp[i] = 1;
  //   else break;
  // }
  // for(int j = 1; j < width; j++) {
  //   bool flag = false;
  //   if(obstacleGrid[0][j])
  //     dp[0] = 0;
  //   else flag = true;
  //   for(int i = 1;i < height; i++) {
  //     if(!obstacleGrid[i][j]) {
  //       dp[i] += dp[i - 1];
  //       if(dp[i])
  //         flag = true;
  //     } else dp[i] = 0;
  //   }
  //   if(!flag) return 0;
  // }
  // return dp[height - 1];
  return 0;
}

std::vector<int> Solution::plus_one(std::vector<int> &digits) {
  for (size_t i = digits.size(); i--; digits[i] = 0)
    if (digits[i]++ < 9)
      return digits;
  digits[0]++;
  digits.emplace_back(0);
  return digits;
}

std::string Solution::add_binary(std::string a, std::string b) {
  std::string s = "";
  int c = 0, i = a.size() - 1, j = b.size() - 1;
  while (c == 1 || i >= 0 || j >= 0) {
    c += i >= 0 ? a[i--] - '0' : 0;
    c += j >= 0 ? b[j--] - '0' : 0;
    s = char(c % 2 + '0') + s;
    c /= 2;
  }
  return s;
}

std::vector<std::string> Solution::full_justify(std::vector<std::string> &words,
                                                int max_width) {
  std::vector<std::string> ans;
  int right = 0, n = words.size();

  std::function<std::string(int)> blank = [](int n) { return std::string(); };
  std::function<std::string(std::vector<std::string> &, int, int, std::string)>
      join = [](std::vector<std::string> &words, int left, int right,
                std::string sep) { return std::string(); };
  while (true) {
    int left = right;
    int sum_len = 0;
    while (right < n &&
           sum_len + words[right].length() + right - left <= max_width) {
      sum_len += words[right++].length();
    }

    if (right == n) {
      std::string s = join(words, left, n, " ");
      ans.emplace_back(s + blank(max_width - s.length()));
      return ans;
    }
    int num_words = right - left;
    int num_spaces = max_width - sum_len;
    if (num_words == 1) {
      ans.emplace_back(words[left] + blank(num_spaces));
      continue;
    }
    int avg_spaces = num_spaces / (num_words - 1);
    int extra_spaces = num_spaces % (num_words - 1);
    std::string s1 =
        join(words, left, left + extra_spaces + 1, blank(avg_spaces + 1));
    std::string s2 =
        join(words, left + extra_spaces + 1, right, blank(avg_spaces));
    ans.emplace_back(s1 + blank(avg_spaces) += s2);
  }
}

int Solution::my_sqrt(int x) {
  if (x <= 1)
    return x;
  int left = 0, right = x;
  int mid = 1;
  while (right >= left) {
    mid = left + (right - left) / 2;
    if (mid == x / mid)
      return mid;
    if (mid < x / mid)
      left = mid + 1;
    else
      right = mid - 1;
  }
  return right;
}

int Solution::climb_stairs(int n) {
  int a = 1, b = 1;
  while (n--)
    a = (b += a) - a;
  return a;
}

bool Solution::search_matrix(std::vector<std::vector<int>> &matrix,
                             int target) {
  int row = matrix.size();
  if (row == 0)
    return false;
  int col = matrix[0].size();
  int low = 0, high = row * col - 1;
  while (low <= high) {
    int mid = low + (high - low) / 2;
    int r = mid / col;
    int c = mid % col;
    if (matrix[r][c] > target)
      high = mid - 1;
    else if (matrix[r][c] < target)
      low = mid + 1;
    else
      return true;
  }
  return false;
}

std::vector<std::vector<int>> Solution::combine(int n, int k) {
  std::vector<std::vector<int>> res;
  int i = 0;
  std::vector<int> p(k, 0);
  while (i >= 0) {
    p[i]++;
    if (p[i] > n)
      --i;
    else if (i == k - 1)
      res.emplace_back(p);
    else {
      ++i;
      p[i] = p[i - 1];
    }
  }
  return res;
}

ListNode *Solution::reverse_between(ListNode *head, int left, int right) {
  auto dummyHead = new ListNode(-1);
  dummyHead->next = head;
  ListNode *prev = dummyHead;
  for (int i = 0; i < left - 1; i++) {
    prev = prev->next;
  }
  ListNode *curr = prev->next;
  ListNode *next = nullptr;
  for (int i = 0; i < right - left; i++) {
    next = curr->next;
    curr->next = next->next;
    next->next = prev->next;
    prev->next = next;
  }
  return dummyHead->next;
}

std::vector<int> Solution::inorder_traversal(TreeNode *root) {
  std::vector<int> res;
  std::stack<TreeNode *> stack;
  TreeNode *curr = root;
  while (curr != nullptr || !stack.empty()) {
    while (curr != nullptr) {
      stack.push(curr);
      curr = curr->left;
    }
    curr = stack.top();
    stack.pop();
    res.emplace_back(curr->val);
    curr = curr->right;
  }
  return res;
}

bool Solution::is_same_tree(TreeNode *p, TreeNode *q) {
  if (p == nullptr || q == nullptr)
    return p == q;
  return p->val == q->val && is_same_tree(p->left, q->left) &&
         is_same_tree(p->right, q->right);
}

bool Solution::is_symmetric(TreeNode *root) {
  // 4ms by recursion

  std::function<bool(TreeNode *, TreeNode *)> is_mirror =
      [&is_mirror](TreeNode *l1, TreeNode *l2) {
        if (l1 == nullptr && l2 == nullptr)
          return true;
        if (l1 == nullptr || l2 == nullptr)
          return false;
        return (l1->val == l2->val) && is_mirror(l1->left, l2->right) &&
               is_mirror(l1->right, l2->left);
      };

  return is_mirror(root, root);

  // 4ms by literation

  /*std::queue<TreeNode *> q;
  q.push(root);
  q.push(root);
  while (!q.empty()) {
    TreeNode *l1 = q.front();
    q.pop();
    TreeNode *l2 = q.front();
    q.pop();
    if (l1 == nullptr && l2 == nullptr)
      continue;
    if (l1 == nullptr || l2 == nullptr)
      return false;
    if (l1->val != l2->val)
      return false;
    q.push(l1->left);
    q.push(l2->right);
    q.push(l1->right);
    q.push(l2->left);
  }
  return true;*/
}

int Solution::max_depth(TreeNode *root) {
  // 8 ms
  // return root == nullptr ? 0 : 1 + max(maxDepth(root->left),
  // maxDepth(root->right));
  /*if (!root) return 0;
  int left = maxDepth(root->left), right = maxDepth(root->right);
  return std::max(left, right) + 1;*/
  // 4ms
  if (!root)
    return 0;
  int res = 0;
  std::queue<TreeNode *> q;
  q.push(root);
  while (!q.empty()) {
    res++;
    for (int i = 0, n = q.size(); i < n; i++) {
      TreeNode *p = q.front();
      q.pop();
      if (p->left != nullptr)
        q.push(p->left);
      if (p->right != nullptr)
        q.push(p->right);
    }
  }
  return res;
}

std::vector<std::vector<int>> Solution::level_order_bottom(TreeNode *root) {
  std::vector<std::vector<int>> ret;
  if (!root)
    return ret;
  std::queue<TreeNode *> que;
  que.push(root);
  while (true) {
    auto nodeCount = que.size();
    if (nodeCount == 0)
      break;
    std::vector<int> tmp;

    while (nodeCount > 0) {
      TreeNode *dataNode = que.front();
      que.pop();
      tmp.emplace_back(dataNode->val);
      if (dataNode->left) {
        que.push(dataNode->left);
      }
      if (dataNode->right) {
        que.push(dataNode->right);
      }
      nodeCount--;
    }
    ret.insert(ret.begin(), tmp);
  }
  return ret;
}

int Solution::min_depth(TreeNode *root) {
  if (!root)
    return 0;
  int left = min_depth(root->left), right = min_depth(root->right);
  return 1 + (std::min(left, right) ? std::min(left, right)
                                    : std::max(left, right));
}

bool Solution::has_path_sum(TreeNode *root, int sum) {
  if (root == nullptr)
    return false;
  if (root->val == sum && root->left == nullptr && root->right == nullptr)
    return true;
  return has_path_sum(root->left, sum - root->val) ||
         has_path_sum(root->right, sum - root->val);
}

std::vector<std::vector<int>> Solution::generate(int numRows) {
  std::vector<std::vector<int>> res;
  for (auto i = 0; i < numRows; ++i) {
    res.emplace_back(i + 1, 1);
    for (auto j = 1; j < i; ++j)
      res[i][j] = res[i - 1][j - 1] + res[i - 1][j];
  }
  return res;
}

bool Solution::is_palindrome(std::string s) {
  for (int i = 0, j = s.size() - 1; i < j;) {
    if (!std::isalnum(s[i]))
      i++;
    else if (!std::isalnum(s[j]))
      j--;
    else if (std::tolower(s[i++]) != std::tolower(s[j--]))
      return false;
  }
  return true;
}

int Solution::single_number(std::vector<int> &nums) {
  int res = 0;
  for (auto &i : nums)
    res ^= i;
  return res;
}

bool Solution::has_cycle(ListNode *head) {
  if (head == nullptr || head->next == nullptr)
    return false;
  ListNode *slow = head;
  ListNode *fast = head->next;
  while (slow != fast) {
    if (fast == nullptr || fast->next == nullptr)
      return false;
    slow = slow->next;
    fast = fast->next->next;
  }
  return true;
}

std::vector<int> Solution::preorder_traversal(TreeNode *root) {
  std::vector<int> res;
  std::stack<TreeNode *> stack;
  while (root != nullptr) {
    res.emplace_back(root->val);
    if (root->right != nullptr)
      stack.push(root->right);
    root = root->left;
    if (root == nullptr && !stack.empty()) {
      root = stack.top();
      stack.pop();
    }
  }
  return res;
}

std::vector<int> Solution::postorder_traversal(TreeNode *root) {
  std::vector<int> res;
  std::stack<TreeNode *> stack;
  TreeNode *last = nullptr;
  while (root || !stack.empty()) {
    if (root) {
      stack.push(root);
      root = root->left;
    } else {
      TreeNode *curr = stack.top();
      if (curr->right && last != curr->right) {
        root = curr->right;
      } else {
        res.emplace_back(curr->val);
        last = curr;
        stack.pop();
      }
    }
  }
  return res;
}

ListNode *Solution::sort_list(ListNode *head) {
  if (!head || !(head->next))
    return head;

  std::function<ListNode *(ListNode *, int)> split = [](ListNode *head, int n) {
    for (int i = 1; head && i < n; i++)
      head = head->next;
    if (!head)
      return static_cast<ListNode *>(nullptr);
    ListNode *second = head->next;
    head->next = nullptr;
    return second;
  };

  std::function<ListNode *(ListNode *, ListNode *, ListNode *)> merge =
      [](ListNode *l1, ListNode *l2, ListNode *head) {
        ListNode *current = head;
        while (l1 && l2) {
          if (l1->val > l2->val) {
            current->next = l2;
            current = l2;
            l2 = l2->next;
          } else {
            current->next = l1;
            current = l1;
            l1 = l1->next;
          }
        }
        current->next = l1 ? l1 : l2;
        while (current->next)
          current = current->next;
        return current;
      };

  // length of the list
  ListNode *current = head;
  int len = 0;
  while (current) {
    len++;
    current = current->next;
  }
  ListNode dummy(0);
  dummy.next = head;
  ListNode *left, *right, *last;
  for (int i = 1; i < len; i <<= 1) {
    current = dummy.next;
    last = &dummy;
    while (current) {
      left = current;
      right = split(left, i);
      current = split(right, i);
      last = merge(left, right, last);
    }
  }
  return dummy.next;
}

std::vector<int> Solution::two_sum_ii(std::vector<int> &numbers, int target) {
  int left = 0, right = numbers.size();
  while (left < right) {
    int sum = numbers[left] + numbers[right];
    if (sum == target) {
      return {left + 1, right + 1};
    } else if (sum > target) {
      right--;
    } else {
      left++;
    }
  }
  return {-1, -1};
}

int Solution::majority_element(std::vector<int> &nums) {
  int count = 0, candidate = 0;
  for (auto &num : nums) {
    if (count == 0)
      candidate = num;
    count += num == candidate ? 1 : -1;
  }
  return candidate;
}

int Solution::trailing_zeroes(int n) {
  int ans = 0;
  while (n) {
    n /= 5;
    ans += n;
  }
  return ans;
}

void Solution::rotate(std::vector<int> &nums, int k) {
  int len = nums.size();
  k %= len;

  std::function<void(std::vector<int> &, int, int)> reverse =
      [](std::vector<int> &nums, int start, int end) {
        while (start < end) {
          std::swap(nums[start], nums[end]);
          ++start;
          --end;
        }
      };

  reverse(nums, 0, len - 1);
  reverse(nums, 0, k - 1);
  reverse(nums, k, len - 1);
}

uint32_t Solution::reverse_bits(uint32_t n) {
  n = (n >> 16) | (n << 16);
  n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
  n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
  n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
  n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
  return n;
  // if (n == 0) return 0;
  // uint res = 0;
  // for (int i = 0; i < 32; i++)
  //{
  //    res <<= 1;
  //    if ((n & 1) == 1) res++;
  //    n >>= 1;
  //}
  // return res;
}

int Solution::hamming_weight(uint32_t n) {
  int res = 0;
  while (n) {
    n &= n - 1;
    res++;
  }
  return res;
}

int Solution::rob(std::vector<int> &nums) {
  auto notrob = 0;
  auto rob = 0;
  for (auto &item : nums) {
    auto current = notrob + item;
    notrob = std::max(notrob, rob);
    rob = current;
  }
  return std::max(rob, notrob);
}

ListNode *Solution::reverse_list(ListNode *head) {
  /*if (head == nullptr || head->next == nullptr) {
    return head;
  }
  ListNode *last = reverseList(head->next);
  head->next->next = head;
  head->next = nullptr;
  return last; */

  ListNode *prev = nullptr;
  ListNode *curr = head;
  while (curr) {
    ListNode *next = curr->next;
    curr->next = prev;
    prev = curr;
    curr = next;
  }
  return prev;
}

bool Solution::is_power_of_two(int n) { return n > 0 && (n & (n - 1)) == 0; }

bool Solution::is_anagram(std::string s, std::string t) {
  if (s.length() != t.length())
    return false;
  int tables[26] = {0};
  for (int i = 0; i < s.length(); i++) {
    tables[s[i] - 'a']++;
    tables[t[i] - 'a']--;
  }
  for (int table : tables) {
    if (table)
      return false;
  }
  return true;
}

int Solution::missing_number(std::vector<int> &nums) {
  int n = nums.size();
  int sum = n * (n + 1) / 2;
  int actual = 0;
  for (int &num : nums) {
    actual += num;
  }
  return sum - actual;
}

void Solution::move_zeroes(std::vector<int> &nums) {
  auto pos = 0;
  for (auto &num : nums) {
    if (num) {
      std::swap(nums[pos++], num);
    }
  }
}

int Solution::find_duplicate(std::vector<int> &nums) {
  int slow = nums[0];
  int fast = nums[0];
  do {
    slow = nums[slow];
    fast = nums[nums[fast]];
  } while (slow != fast);
  int ptr1 = nums[0];
  int ptr2 = slow;
  while (ptr1 != ptr2) {
    ptr1 = nums[ptr1];
    ptr2 = nums[ptr2];
  }
  return ptr1;
}

bool Solution::is_valid_serialization(std::string preorder) {
  int n = preorder.length();
  int i = 0;
  int slots = 1;
  while (i < n) {
    if (slots == 0) {
      return false;
    }
    if (preorder[i] == ',') {
      i++;
    } else if (preorder[i] == '#') {
      slots--;
      i++;
    } else {
      while (i < n && preorder[i] != ',') {
        i++;
      }
      slots++;
    }
  }

  return slots == 0;
}

void Solution::reverse_string(std::vector<char> &s) {
  // two pointers
  int l = 0, r = s.size() - 1;
  while (l < r) {
    std::swap(s[l++], s[r--]);
  }
}

int Solution::count_numbers_with_unique_digits(int n) {
  if (n == 0) {
    return 1;
  }
  if (n == 1) {
    return 10;
  }
  int res = 10, cur = 9;
  for (int i = 0; i < n - 1; i++) {
    cur *= 9 - i;
    res += cur;
  }
  return res;
}

std::vector<int> Solution::lexical_order(int n) {
  std::vector<int> ret(n);
  int num = 1;
  for (int i = 0; i < n; ++i) {
    ret[i] = num;
    if (num * 10 <= n) {
      num *= 10;
    } else {
      while (num % 10 == 9 || num + 1 > n) {
        num /= 10;
      }
      num++;
    }
  }
  return ret;
}

int Solution::max_rotate_function(std::vector<int> &nums) {
  int f = 0, n = nums.size();
  int numsSum = std::accumulate(nums.begin(), nums.end(), 0);
  for (size_t i = 0; i < n; ++i) {
    f += i * nums[i];
  }
  int res = 0;
  for (size_t i = n - 1; i > 0; --i) {
    f += numsSum - n * nums[i];
    res = std::max(res, f);
  }
  return res;
}

std::vector<std::string> Solution::read_binary_watch(int num) {
  std::vector<std::string> rs;
  for (int h = 0; h < 12; h++)
    for (int m = 0; m < 60; m++)
      if (std::bitset<10>(h << 6 | m).count() == num)
        rs.emplace_back(std::to_string(h) + (m < 10 ? ":0" : ":") +
                        std::to_string(m));
  return rs;
}

std::string Solution::add_strings(std::string &num1, std::string &num2) {
  int i = num1.size() - 1, j = num2.size() - 1, carry = 0;
  std::string ans = "";
  while (i >= 0 || j >= 0 || carry != 0) {
    int x = i >= 0 ? num1[i] - '0' : 0;
    int y = j >= 0 ? num2[j] - '0' : 0;
    int result = x + y + carry;
    ans += ('0' + result % 10);
    carry = result / 10;
    i--;
    j--;
  }
  std::reverse(ans.begin(), ans.end());
  return ans;
}

std::vector<std::vector<int>> Solution::level_order(Node *root) {
  if (root == nullptr)
    return {};
  std::vector<std::vector<int>> res;
  std::queue<Node *> q;
  q.push(root);
  while (!q.empty()) {
    size_t size = q.size();
    std::vector<int> tmp;
    for (size_t i = 0; i < size; ++i) {
      Node *cur = q.front();
      tmp.emplace_back(cur->val);
      for (auto child : cur->children)
        q.push(child);
      q.pop();
    }
    res.emplace_back(tmp);
  }
  return res;
}

int Solution::min_moves(std::vector<int> &nums) {
  int minNum = *std::min_element(nums.begin(), nums.end());
  int res = 0;
  for (int num : nums) {
    res += num - minNum;
  }
  return res;
}

int Solution::total_hamming_distance(std::vector<int> &nums) {
  int size = nums.size();
  int res = 0;
  for (int i = 0; i < 30; i++) {
    int tmp = 0;
    for (int num : nums) {
      tmp += (num >> i) & 1;
    }
    res += tmp * (size - tmp);
  }
  return res;
}

std::vector<int>
Solution::find_diagonal_order(std::vector<std::vector<int>> &mat) {
  if (mat.size() == 0) {
    return {};
  }
  int N = mat.size(), M = mat[0].size();
  int row = 0, col = 0;
  int direction = 1;
  std::vector<int> res(N * M);
  int r = 0;
  while (row < N && col < M) {
    res[r++] = mat[row][col];
    int new_row = row + (direction == 1 ? -1 : 1);
    int new_col = col + (direction == 1 ? 1 : -1);
    if (new_row < 0 || new_row == N || new_col < 0 || new_col == M) {
      if (direction) {
        row += (col == M - 1 ? 1 : 0);
        col += (col < M - 1 ? 1 : 0);
      } else {
        col += (row == N - 1 ? 1 : 0);
        row += (row < N - 1 ? 1 : 0);
      }
      direction = 1 - direction;
    } else {
      row = new_row;
      col = new_col;
    }
  }
  return res;
}

std::string Solution::convert_to_base7(int num) {
  if (num == 0) {
    return "0";
  }
  bool negative = num < 0;
  num = std::abs(num);
  std::string digits;
  while (num > 0) {
    digits += (num % 7 + '0');
    num /= 7;
  }
  if (negative) {
    digits+= '-';
  }
  std::reverse(digits.begin(), digits.end());
  return digits;
}

int Solution::fib(int N) {
  if (N < 2)
    return N;
  int f0 = 0;
  int f1 = 1;
  int res = 0;
  for (int i = 1; i < N; i++) {
    res = f0 + f1;
    f0 = f1;
    f1 = res;
  }
  return res;
}

int Solution::change(int amount, std::vector<int> &coins) {
  std::vector<int> dp(amount + 1);
  dp[0] = 1;
  for (int &coin : coins) {
    for (int i = coin; i <= amount; i++) {
      dp[i] += dp[i - coin];
    }
  }
  return dp[amount];
}

std::string Solution::complex_number_multiply(std::string num1,
                                              std::string num2) {
  std::regex re("\\+|i");
  std::vector<std::string> complex1(
      std::sregex_token_iterator(num1.begin(), num1.end(), re, -1),
      std::sregex_token_iterator());
  std::vector<std::string> complex2(
      std::sregex_token_iterator(num2.begin(), num2.end(), re, -1),
      std::sregex_token_iterator());
  int real1 = std::stoi(complex1[0]);
  int imag1 = std::stoi(complex1[1]);
  int real2 = std::stoi(complex2[0]);
  int imag2 = std::stoi(complex2[1]);
  return std::to_string(real1 * real2 - imag1 * imag2) + "+" +
         std::to_string(real1 * imag2 + imag1 * real2) + "i";
}

std::string Solution::reverse_words(std::string s) {
  int len = s.length();
  int i = 0;
  while (i < len) {
    int start = i;
    while (i < len && s[i] != ' ') {
      i++;
    }
    int left = start, right = i - 1;
    while (left < right) {
      std::swap(s[left], s[right]);
      left++;
      right--;
    }
    while (i < len && s[i] == ' ') {
      i++;
    }
  }
  return s;
}

TreeNode *Solution::merge_trees(TreeNode *t1, TreeNode *t2) {
  if (t1 == nullptr)
    return t2;
  if (t2 == nullptr)
    return t1;
  t1->val += t2->val;
  t1->left = merge_trees(t1->left, t2->left);
  t1->right = merge_trees(t1->right, t2->right);
  return t1;
}

std::vector<int> Solution::exclusive_time(int n,
                                          std::vector<std::string> &logs) {
  std::stack<std::pair<int, int>> st;
  std::vector<int> res(n, 0);
  for (auto &log : logs) {
    auto values = Utils::split(log, ":");
    int index = std::stoi(values[0]);
    int timestamp = std::stoi(values[2]);
    if (values[1] == "start") {
      if (!st.empty()) {
        res[st.top().first] += timestamp - st.top().second;
        st.top().second = timestamp;
      }
      st.emplace(index, timestamp);
    } else {
      auto t = st.top();
      st.pop();
      res[t.first] += timestamp - t.second + 1;
      if (!st.empty()) {
        st.top().second = timestamp + 1;
      }
    }
  }
  return res;
}

int Solution::find_longest_chain(std::vector<std::vector<int>> &pairs) {
  int curr = min_int, res = 0;
  std::sort(pairs.begin(), pairs.end(),
            [](const std::vector<int> &a, const std::vector<int> &b) {
              return a[1] < b[1];
            });
  for (auto &pair : pairs) {
    if (curr < pair[0]) {
      curr = pair[1];
      res++;
    }
  }
  return res;
}

// std::vector<TreeNode *> Solution::find_duplicate_subtrees(TreeNode *root) {
//   find_duplicate_subtrees_dfs(root);
//   return {Solution::repeat.begin(), Solution::repeat.end()};
// }

std::vector<TreeNode *> Solution::find_duplicate_subtrees(TreeNode *root) {
  int index = 0;

  static constexpr auto triple =
      [fn = std::hash<int>()](const std::tuple<int, int, int> &o) -> size_t {
    auto &&[x, y, z] = o;
    return (fn(x) << 24) ^ (fn(y) << 8) ^ fn(z);
  };

  std::unordered_map<std::tuple<int, int, int>, std::pair<TreeNode *, int>,
                     decltype(triple)>
      seen{0, triple};
  std::unordered_set<TreeNode *> repeat;

  std::function<int(TreeNode *)> dfs = [&index, &seen, &repeat,
                                        &dfs](TreeNode *node) {
    if (!node) {
      return 0;
    }
    auto triple = std::tuple{node->val, dfs(node->left), dfs(node->right)};
    if (auto it = seen.find(triple); it != seen.end()) {
      repeat.insert(it->second.first);
      return it->second.second;
    } else {
      seen[triple] = {node, ++index};
      return index;
    }
  };

  dfs(root);
  return {repeat.begin(), repeat.end()};
}

std::vector<int> Solution::find_closest_elements(std::vector<int> &arr, int k,
                                                 int x) {
  int right = std::lower_bound(arr.begin(), arr.end(), x) - arr.begin();
  int left = right - 1;
  int n = arr.size();
  while (k--) {
    if (left < 0) {
      right++;
    } else if (right >= n || x - arr[left] <= arr[right] - x) {
      left--;
    } else {
      right++;
    }
  }
  return std::vector<int>(arr.begin() + (left + 1), arr.begin() + right);
}

int Solution::width_of_binary_tree(TreeNode *root) {
  using ULL = unsigned long long;
  std::unordered_map<int, ULL> level_min;
  std::function<ULL(TreeNode *, int, ULL)> dfs = [&](TreeNode *node, int depth,
                                                     ULL index) -> ULL {
    if (node == nullptr) {
      return 0LL;
    }
    if (!level_min.count(depth)) {
      level_min[depth] = index;
    }
    return std::max({index - level_min[depth] + 1LL,
                     dfs(node->left, depth + 1, index * 2),
                     dfs(node->right, depth + 1, index * 2 + 1)});
  };
  return dfs(root, 1, 1LL);
}

std::vector<int> Solution::construct_array(int n, int k) {
  std::vector<int> res;
  for (size_t i = 1; i < n - k; i++) {
    res.emplace_back(i);
  }
  for (size_t i = n - k, j = n; i <= j; i++, j--) {
    res.emplace_back(i);
    if (i != j) {
      res.emplace_back(j);
    }
  }
  return res;
}

TreeNode *Solution::trim_bst(TreeNode *root, int L, int R) {
  // Recursively
  if (root == nullptr)
    return root;
  if (root->val > R)
    return trim_bst(root->left, L, R);
  if (root->val < L)
    return trim_bst(root->right, L, R);
  root->left = trim_bst(root->left, L, R);
  root->right = trim_bst(root->right, L, R);
  return root;
}

int Solution::maximum_swap(int num) {
  std::string chars = std::to_string(num);
  int n = chars.size();
  int maxIndex = n - 1;
  int index1 = -1, index2 = -1;
  for (int i = n - 1; i >= 0; --i) {
    if (chars[i] > chars[maxIndex]) {
      maxIndex = i;
    } else if (chars[i] < chars[maxIndex]) {
      index1 = i;
      index2 = maxIndex;
    }
  }
  if (index1 >= 0) {
    std::swap(chars[index1], chars[index2]);
    return std::stoi(chars);
  }
  return num;
}

int Solution::flip_lights(int n, int presses) {
  std::unordered_set<int> seen;
  for (int i = 0; i < 1 << 4; i++) {
    std::vector<int> pressArray(4);
    for (int j = 0; j < 4; j++) {
      pressArray[j] = (i >> j) & 1;
    }
    int sum = std::accumulate(pressArray.begin(), pressArray.end(), 0);
    if (sum % 2 == presses % 2 && sum <= presses) {
      int status = pressArray[0] ^ pressArray[1] ^ pressArray[3];
      if (n >= 2) {
        status |= (pressArray[0] ^ pressArray[1]) << 1;
      }
      if (n >= 3) {
        status |= (pressArray[0] ^ pressArray[2]) << 2;
      }
      if (n >= 4) {
        status |= status << 3;
      }
      seen.emplace(status);
    }
  }
  return seen.size();
}

int Solution::longest_univalue_path(TreeNode *root) {
  int max_univalue_path = 0;
  std::function<int(TreeNode *)> dfs = [&max_univalue_path,
                                        &dfs](TreeNode *root) {
    if (root == nullptr) {
      return 0;
    }
    int left = dfs(root->left), right = dfs(root->right);
    int left1 = 0, right1 = 0;
    if (root->left && root->left->val == root->val) {
      left1 = left + 1;
    }
    if (root->right && root->right->val == root->val) {
      right1 = right + 1;
    }
    max_univalue_path = std::max(max_univalue_path, left1 + right1);
    return std::max(left1, right1);
  };

  dfs(root);
  return max_univalue_path;
}

TreeNode *Solution::search_bst(TreeNode *root, int val) {
  while (root && root->val != val)
    root = val < root->val ? root->left : root->right;
  return root;
}

TreeNode *Solution::insertInto_bst(TreeNode *root, int val) {
  // recursive
  // if(root == nullptr
  //     return new TreeNode(val);
  // if(val > root->val)
  //     root->right = InsertIntoBST(root->right, val);
  // else
  //     root->left = InsertIntoBST(root->left, val);
  // return root;
  // iterative
  if (root == nullptr)
    return new TreeNode(val);
  TreeNode *currentNode = root;
  TreeNode *newNode = new TreeNode(val);
  while (currentNode) {
    if (currentNode->val > val) {
      if (currentNode->left)
        currentNode = currentNode->left;
      else {
        currentNode->left = newNode;
        break;
      }
    } else {
      if (currentNode->right)
        currentNode = currentNode->right;
      else {
        currentNode->right = newNode;
        break;
      }
    }
  }
  return root;
}

int Solution::binary_search(std::vector<int> &nums, int target) {
  int left = 0, right = nums.size() - 1;
  while (left <= right) {
    int mid = left + (right - left) / 2;
    if (nums[mid] == target) {
      return mid;
    } else if (nums[mid] > target) {
      right = mid - 1;
    } else {
      left = mid + 1;
    }
  }
  return -1;
}

std::string Solution::to_lowerCase(std::string str) {
  for (auto &c : str) {
    if ('A' <= c && c <= 'Z')
      c = c - 'A' + 'a';
  }
  return str;
}

int Solution::pivot_index(std::vector<int> &nums) {
  int total = std::accumulate(nums.begin(), nums.end(), 0);
  int sum = 0;
  for (int i = 0; i < nums.size(); i++) {
    if (2 * sum + nums[i] == total) {
      return i;
    }
    sum += nums[i];
  }
  return -1;
}

std::vector<int> Solution::self_dividing_numbers(int left, int right) {
  std::vector<int> ans;

  std::function<bool(int)> is_self_dividing = [](int num) {
    int tmp = num;
    while (tmp > 0) {
      int digit = tmp % 10;
      if (digit == 0 || num % digit != 0) {
        return false;
      }
      tmp /= 10;
    }
    return true;
  };

  for (int i = left; i <= right; i++) {
    if (is_self_dividing(i)) {
      ans.emplace_back(i);
    }
  }
  return ans;
}

std::vector<int> Solution::daily_temperatures(std::vector<int> &T) {
  std::stack<int> s;
  int len = T.size();
  std::vector<int> ans(len, 0);
  for (int i = 0; i < len; i++) {
    while (!s.empty() != 0 && T[i] > T[s.top()]) {
      int t = s.top();
      s.pop();
      ans[t] = i - t;
    }
    s.push(i);
  }
  return ans;
}

int Solution::preimage_size_fzf(int k) {
  std::function<long long(int)> nx = [](int k) {
    std::function<int(long)> zeta = [](long x) {
      int res = 0;
      while (x) {
        res += x / 5;
        x /= 5;
      }
      return res;
    };
    long long left = 0, right = 5LL * k;
    while (left <= right) {
      long long mid = (left + right) / 2;
      if (zeta(mid) < k) {
        left = mid + 1;
      } else {
        right = mid - 1;
      }
    }
    return right + 1;
  };
  return nx(k + 1) - nx(k);
}

int Solution::unique_morse_representations(std::vector<std::string> &words) {
  const std::string MORSE[] = {
      ".-",   "-...", "-.-.", "-..",  ".",   "..-.", "--.",  "....", "..",
      ".---", "-.-",  ".-..", "--",   "-.",  "---",  ".--.", "--.-", ".-.",
      "...",  "-",    "..-",  "...-", ".--", "-..-", "-.--", "--.."};
  std::unordered_set<std::string> seen;
  for (auto &word : words) {
    std::string code;
    for (auto &c : word) {
      code.append(MORSE[c - 'a']);
    }
    seen.emplace(code);
  }
  return seen.size();
}

std::vector<int> Solution::number_of_lines(std::vector<int> &widths,
                                           std::string &s) {
  int lines = 1;
  int width = 0;
  const int MAX_WIDTH = 100;
  for (auto &c : s) {
    int need = widths[c - 'a'];
    width += need;
    if (width > MAX_WIDTH) {
      lines++;
      width = need;
    }
  }
  return {lines, width};
}

std::vector<int> Solution::shortest_to_char(std::string S, char C) {
  int n = S.size();
  std::vector<int> ans(n, 0);
  int prev = INT32_MIN / 2;
  for (int i = 0; i < n; i++) {
    if (S[i] == C)
      prev = i;
    ans[i] = i - prev;
  }
  prev = INT32_MAX / 2;
  for (int i = n - 1; i >= 0; i--) {
    if (S[i] == C)
      prev = i;
    ans[i] = std::min(ans[i], prev - i);
  }
  return ans;
}

int Solution::unique_letter_string(std::string &s) {
  std::unordered_map<char, std::vector<int>> index;
  for (size_t i = 0; i < s.size(); i++) {
    index[s[i]].emplace_back(i);
  }
  int res = 0;
  for (auto &&[_, arr] : index) {
    arr.insert(arr.begin(), -1);
    arr.emplace_back(s.size());
    for (size_t i = 1; i < arr.size() - 1; i++) {
      res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
    }
  }
  return res;
  return 0;
}

int Solution::peak_index_in_mountain_array(std::vector<int> &A) {
  size_t left = 0, right = A.size();
  while (left < right) {
    size_t mid = (left + right) / 2;
    if (A[mid] < A[mid + 1])
      left = mid + 1;
    else
      right = mid;
  }
  return left;
}

double Solution::min_cost_to_hire_workers(std::vector<int> &quality,
                                          std::vector<int> &wage, int k) {
  int n = quality.size();
  std::vector<int> hire(n, 0);
  std::iota(hire.begin(), hire.end(), 0);
  std::sort(hire.begin(), hire.end(), [&](int &a, int &b) {
    return quality[a] * wage[b] > quality[b] * wage[a];
  });
  double res = 1e9;
  double totalQuality = 0.0;
  std::priority_queue<int, std::vector<int>, std::less<int>> pq;
  for (int i = 0; i < k - 1; i++) {
    totalQuality += quality[hire[i]];
    pq.push(quality[hire[i]]);
  }
  for (int i = k - 1; i < n; i++) {
    int index = hire[i];
    totalQuality += quality[index];
    pq.push(quality[index]);
    double totalCost = ((double)wage[index] / quality[index]) * totalQuality;
    res = std::min(res, totalCost);
    totalQuality -= pq.top();
    pq.pop();
  }
  return res;
}

ListNode *Solution::middle_node(ListNode *head) {
  ListNode *slow = head;
  ListNode *fast = head;
  while (fast != nullptr && fast->next != nullptr) {
    slow = slow->next;
    fast = fast->next->next;
  }
  return slow;
}

int Solution::projection_area(std::vector<std::vector<int>> &grid) {
  size_t N = grid.size();
  int ans = 0;
  for (size_t i = 0; i < N; i++) {
    int row = 0;
    int column = 0;
    for (size_t j = 0; j < N; j++) {
      if (grid[i][j] > 0)
        ans++;
      row = std::max(row, grid[i][j]);
      column = std::max(column, grid[j][i]);
    }
    ans += row + column;
  }
  return ans;
}

std::vector<std::string> Solution::uncommon_from_sentences(std::string A,
                                                           std::string B) {
  std::unordered_map<std::string, int> count;
  std::istringstream iss(B + " " + A);
  while (iss >> A)
    count[A]++;
  std::vector<std::string> res;
  for (auto w : count)
    if (w.second == 1)
      res.emplace_back(w.first);
  return res;
}

int Solution::surface_area(std::vector<std::vector<int>> &grid) {
  int res = 0;
  int n = grid.size();
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
      if (grid[i][j])
        res += grid[i][j] * 4 + 2;
      if (i)
        res -= std::min(grid[i][j], grid[i - 1][j]) * 2;
      if (j)
        res -= std::min(grid[i][j], grid[i][j - 1]) * 2;
    }
  }
  return res;
}

std::vector<TreeNode *> Solution::all_possible_fbt(int n) {
  std::vector<TreeNode *> full_binary_trees;
  if (n % 2 == 0) {
    return full_binary_trees;
  }
  if (n == 1) {
    full_binary_trees = {new TreeNode(0)};
    return full_binary_trees;
  }
  for (int i = 1; i < n; i++) {
    std::vector<TreeNode *> left_subtrees = all_possible_fbt(i);
    std::vector<TreeNode *> right_subtrees = all_possible_fbt(n - 1 - i);
    for (auto left_subtree : left_subtrees) {
      for (auto right_subtree : right_subtrees) {
        TreeNode *root = new TreeNode(0, left_subtree, right_subtree);
        full_binary_trees.emplace_back(root);
      }
    }
  }

  return full_binary_trees;
}

std::vector<int> Solution::sort_array_by_parity(std::vector<int> &A) {
  size_t i = 0, j = A.size() - 1;
  while (i < j) {
    if (A[i] % 2 > A[j] % 2) {
      int tmp = A[i];
      A[i] = A[j];
      A[j] = tmp;
    }
    if (A[i] % 2 == 0)
      i++;
    if (A[j] % 2 == 1)
      j--;
  }
  return A;
}

int Solution::range_sum_bst(TreeNode *root, int L, int R) {
  int sum = 0;
  if (root == nullptr)
    return sum;
  if (root->val > L)
    sum += range_sum_bst(root->left, L, R);
  if (root->val < R)
    sum += range_sum_bst(root->right, L, R);
  if (root->val >= L && root->val <= R)
    sum += root->val;
  return sum;
}

int Solution::min_deletion_size(std::vector<std::string> &strs) {
  int row = strs.size();
  int col = strs[0].size();
  int ans = 0;
  for (int j = 0; j < col; j++) {
    for (int i = 1; i < row; i++) {
      if (strs[i - 1][j] > strs[i][j]) {
        ans++;
        break;
      }
    }
  }
  return ans;
}

bool Solution::validate_stack_sequences(std::vector<int> &pushed,
                                        std::vector<int> &popped) {
  std::stack<int> stk;
  int n = pushed.size();
  for (size_t i = 0, j = 0; i < n; i++) {
    stk.emplace(pushed[i]);
    while (!stk.empty() && stk.top() == popped[j]) {
      stk.pop();
      j++;
    }
  }
  return stk.empty();
}

int Solution::repeated_n_times(std::vector<int> &nums) {
  std::unordered_set<int> found;
  for (auto &num : nums) {
    if (found.count(num)) {
      return num;
    }
    found.insert(num);
  }
  return -1;
}

bool Solution::is_unival_tree(TreeNode *root) {
  if (!root) {
    return false;
  }
  if (root->left) {
    if (root->val != root->left->val || !is_unival_tree(root->left)) {
      return false;
    }
  }
  if (root->right) {
    if (root->val != root->right->val || !is_unival_tree(root->right)) {
      return false;
    }
  }

  return true;
}

std::vector<int> Solution::sorted_squares(std::vector<int> &nums) {
  int n = nums.size();
  std::vector<int> ans(n);
  for (int i = 0, j = n - 1, pos = n - 1; i <= j;) {
    if (nums[i] * nums[i] > nums[j] * nums[j]) {
      ans[pos] = nums[i] * nums[i];
      ++i;
    } else {
      ans[pos] = nums[j] * nums[j];
      --j;
    }
    --pos;
  }
  return ans;
}

TreeNode *Solution::insert_into_max_tree(TreeNode *root, int val) {
  TreeNode *parent = nullptr;
  TreeNode *curr = root;
  while (curr) {
    if (val > curr->val) {
      if (!parent) {
        return new TreeNode(val, root, nullptr);
      }
      parent->right = new TreeNode(val, curr, nullptr);
      return root;
    } else {
      parent = curr;
      curr = curr->right;
    }
  }
  if (parent) {
    parent->right = new TreeNode(val);
  } else {
    return new TreeNode(val);
  }

  return root;
}

std::vector<std::vector<int>>
Solution::shift_grid(std::vector<std::vector<int>> &grid, int k) {
  int n = grid.size(), m = grid[0].size();
  std::vector<std::vector<int>> res = grid;
  k %= m * n;
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < m; j++) {
      int index = (i * m + j + k) % (m * n);
      int x = index / m, y = index % m;
      res[x][y] = grid[i][j];
    }
  }
  return res;
}

int Solution::min_push_box(std::vector<std::vector<char>> &grid) {
  int m = grid.size(), n = grid[0].size();
  int sx, sy, bx, by;
  for (int x = 0; x < m; x++) {
    for (int y = 0; y < n; y++) {
      if (grid[x][y] == 'S') {
        sx = x;
        sy = y;
      } else if (grid[x][y] == 'B') {
        bx = x;
        by = y;
      }
    }
  }

  auto is_valid_position = [&](int x, int y) -> bool {
    return x >= 0 && x < m && y >= 0 && y < n && grid[x][y] != '#';
  };

  std::vector<int> directions = {0, -1, 1, 0};
  std::vector<std::vector<int>> dp(m * n, std::vector<int>(m * n, max_int));
  std::queue<std::pair<int, int>> position_queue;

  dp[sx * n + sy][bx * n + by] = 0;

  position_queue.push({sx * n + sy, bx * n + by});

  while (!position_queue.empty()) {
    std::queue<std::pair<int, int>> temp_queue;
    while (!position_queue.empty()) {
      auto [s1, b1] = position_queue.front();
      position_queue.pop();
      int sx1 = s1 / n, sy1 = s1 % n, bx1 = b1 / n, by1 = b1 % n;
      if (grid[bx1][by1] == 'T') {
        return dp[s1][b1];
      }
      for (int i = 0; i < 4; i++) {
        int sx2 = sx1 + directions[i], sy2 = sy1 + directions[i + 1],
            s2 = sx2 * n + sy2;
        if (!is_valid_position(sx2, sy2)) {
          continue;
        }
        if (bx1 == sx2 && by1 == sy2) {
          int bx2 = bx1 + directions[i], by2 = by1 + directions[i + 1],
              b2 = bx2 * n + by2;
          if (!is_valid_position(bx2, by2) || dp[s2][b2] <= dp[s1][b1] + 1) {
            continue;
          }
          dp[s2][b2] = dp[s1][b1] + 1;
          temp_queue.push({s2, b2});
        } else {
          if (dp[s2][b1] <= dp[s1][b1]) {
            continue;
          }
          dp[s2][b1] = dp[s1][b1];
          position_queue.push({s2, b1});
        }
      }
    }
    position_queue.swap(temp_queue);
  }

  return -1;
}

std::vector<int>
Solution::lucky_numbers(std::vector<std::vector<int>> &matrix) {
  int m = matrix.size(), n = matrix.size();
  std::vector<int> minRow(m, max_int), maxCol(n);
  for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
      minRow[i] = std::min(minRow[i], matrix[i][j]);
      maxCol[j] = std::max(maxCol[i], matrix[i][j]);
    }
  }
  std::vector<int> res;
  for (int i = 0; i < m; i++) {
    for (int j = 0; j < n; j++) {
      if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j]) {
        res.emplace_back(matrix[i][j]);
      }
    }
  }
  return res;
}

std::vector<int> Solution::min_subsequence(std::vector<int> &nums) {
  int total = std::accumulate(nums.begin(), nums.end(), 0);
  std::sort(nums.begin(), nums.end());
  std::vector<int> ans;
  int curr = 0;
  for (int i = nums.size() - 1; i >= 0; --i) {
    curr += nums[i];
    ans.emplace_back(nums[i]);
    if (total - curr < curr) {
      break;
    }
  }
  return ans;
}

int Solution::busy_student(std::vector<int> &startTime,
                           std::vector<int> &endTime, int queryTime) {
  int res = 0;
  for (int i = 0; i < startTime.size(); ++i) {
    if (startTime[i] <= queryTime && queryTime <= endTime[i]) {
      res++;
    }
  }
  return res;
}

int Solution::is_prefix_of_word(std::string sentence, std::string searchWord) {
  int n = sentence.size(), index = 1, start = 0, end = 0;

  std::function<bool(const std::string &, int, int, const std::string &)>
      is_prefix = [](const std::string &sentence, int start, int end,
                     const std::string &searchWord) {
        for (int i = 0; i < searchWord.size(); i++) {
          if (start + i >= end || sentence[start + i] != searchWord[i]) {
            return false;
          }
        }
        return true;
      };

  while (start < n) {
    while (end < n && sentence[end] != ' ') {
      end++;
    }
    if (is_prefix(sentence, start, end, searchWord)) {
      return index;
    }
    index++;
    end++;
    start = end;
  }
  return -1;
}

int Solution::max_product(std::vector<int> &nums) {
  int a = nums[0], b = nums[1];
  if (a < b) {
    std::swap(a, b);
  }
  for (int i = 2; i < nums.size(); ++i) {
    if (nums[i] > a) {
      b = a;
      a = nums[i];
    } else if (nums[i] > b) {
      b = nums[i];
    }
  }
  return (a - 1) * (b - 1);
}

std::vector<int> Solution::shuffle(std::vector<int> &nums, int n) {
  std::vector<int> res(n * 2);
  for (size_t i = 0; i < n; i++) {
    res[2 * i] = nums[i];
    res[2 * i + 1] = nums[i + n];
  }
  return res;
}

std::vector<int> Solution::final_prices(std::vector<int> &prices) {
  int n = prices.size();
  std::vector<int> res(n);
  std::stack<int> stk;
  for (int i = n - 1; i >= 0; --i) {
    while (!stk.empty() && stk.top() > prices[i]) {
      stk.pop();
    }
    res[i] = stk.empty() ? prices[i] : prices[i] - stk.top();
    stk.emplace(prices[i]);
  }
  return res;
}

int Solution::xor_operation(int n, int start) {
  int s = start >> 1;
  int e = n & start & 1;

  std::function<int(int)> sum_xor = [](int x) {
    if (x % 4 == 0) {
      return x;
    }
    if (x % 4 == 1) {
      return 1;
    }
    if (x % 4 == 2) {
      return x + 1;
    }
    return 0;
  };
  int res = sum_xor(s - 1) ^ sum_xor(s + n - 1);
  return res << 1 | e;
}

int Solution::num_special(std::vector<std::vector<int>> &mat) {
  int m = mat.size(), n = mat[0].size();
  for (size_t i = 0; i < m; ++i) {
    int count = 0;
    for (size_t j = 0; j < n; ++j) {
      if (mat[i][j] == 1) {
        count++;
      }
    }
    if (i == 0) {
      count--;
    }
    if (count > 0) {
      for (size_t j = 0; j < n; ++j) {
        if (mat[i][j] == 1) {
          mat[0][j] += count;
        }
      }
    }
  }
  int sum = 0;
  for (auto &num : mat[0]) {
    if (num == 1) {
      sum++;
    }
  }
  return sum;
}

std::string Solution::reorder_spaces(std::string text) {
  size_t n = text.size();
  std::vector<std::string> words = Utils::split(text, " ");
  size_t spaceCount = n;
  size_t wordCount = 0;
  for (auto &word : words) {
    if (word.size() > 0) {
      spaceCount -= word.size();
      wordCount++;
    }
  }
  std::string res;
  if (words.size() == 1) {
    res.append(words[0]);
    for (size_t i = 0; i < spaceCount; i++) {
      res += ' ';
    }
    return res;
  }
  size_t perSpace = spaceCount / (wordCount - 1);
  size_t restSpace = spaceCount % (wordCount - 1);
  for (size_t i = 0; i < words.size(); i++) {
    if (words[i].size() == 0) {
      continue;
    }
    if (res.size() > 0) {
      for (size_t j = 0; j < perSpace; j++) {
        res += ' ';
      }
    }
    res.append(words[i]);
  }
  for (size_t i = 0; i < restSpace; i++) {
    res += ' ';
  }
  return res;
}

int Solution::min_operations(std::vector<std::string> &logs) {
  int depth = 0;
  for (auto &log : logs) {
    if (log == "./") {
      continue;
    } else if (log == "../") {
      if (depth > 0) {
        depth--;
      }
    } else {
      depth++;
    }
  }
  return depth;
}

int Solution::special_array(std::vector<int> &nums) {
  std::sort(nums.begin(), nums.end(), std::greater<int>());
  int n = nums.size();
  for (int i = 1; i <= n; i++) {
    if (nums[i - 1] >= i && (i == n || nums[i] < i)) {
      return i;
    }
  }
  return -1;
}

double Solution::trim_mean(std::vector<int> &arr) {
  int n = arr.size();
  std::sort(arr.begin(), arr.end());
  int sum =
      std::accumulate(arr.begin() + n / 20, arr.begin() + (19 * n / 20), 0);
  return sum / (n * 0.9);
}

int Solution::max_length_between_equal_characters(std::string &s) {
  std::vector<int> dic(26, -1);
  int res = -1;
  for (int i = 0; i < s.size(); i++) {
    int c = s[i] - 'a';
    if (dic[c] < 0) {
      dic[c] = i;
    } else {
      res = std::max(res, i - dic[c] - 1);
    }
  }
  return res;
}

std::vector<int> Solution::frequency_sort(std::vector<int> &nums) {
  std::unordered_map<int, int> count;
  for (auto &num : nums) {
    count[num]++;
  }
  std::sort(nums.begin(), nums.end(), [&](const int a, const int b) {
    if (count[a] != count[b]) {
      return count[a] < count[b];
    }
    return a > b;
  });
  return nums;
}

int Solution::min_operations(std::vector<int> &nums, int x) {
  int n = nums.size();
  int sum = std::accumulate(nums.begin(), nums.end(), 0);

  if (sum < x) {
    return -1;
  }

  int right = 0;
  int leftSum = 0, rrightSum = sum;
  int res = n + 1;

  for (int left = -1; left < n; ++left) {
    if (left != -1) {
      leftSum += nums[left];
    }
    while (right < n && leftSum + rrightSum > x) {
      rrightSum -= nums[right];
      ++right;
    }
    if (leftSum + rrightSum == x) {
      res = std::min(res, (left + 1) + (n - right));
    }
  }

  return res > n ? -1 : res;
}

int Solution::maximum_wealth(std::vector<std::vector<int>> &accounts) {
  int maxWealth = 0;
  /*for (auto &account : accounts) {
    maxWealth =
        std::max(maxWealth, std::accumulate(account.begin(), account.end(), 0));
  }*/
  std::for_each(accounts.begin(), accounts.end(), [&maxWealth](auto &&x) {
    maxWealth = std::max(maxWealth, std::accumulate(x.begin(), x.end(), 0));
  });
  return maxWealth;
}

std::string Solution::reformat_number(std::string number) {
  std::string digits;
  for (char ch : number) {
    if (std::isdigit(ch)) {
      digits += ch;
    }
  }
  int n = digits.size();
  int pt = 0;
  std::string res;
  while (n) {
    if (n > 4) {
      res += digits.substr(pt, 3) + "-";
      pt += 3;
      n -= 3;
    } else {
      if (n == 4) {
        res += digits.substr(pt, 2) + "-" + digits.substr(pt + 2, 2);
      } else {
        res += digits.substr(pt, n);
      }
      break;
    }
  }
  return res;
}

int Solution::minimum_length(std::string s) {
  int n = s.size();
  int left = 0, right = n - 1;
  while (left < right && s[left] == s[right]) {
    char c = s[left];
    while (left <= right && s[left] == c) {
      left++;
    }
    while (left <= right && s[right] == c) {
      right--;
    }
  }
  return right - left + 1;
}

bool Solution::check_ones_segment(std::string s) { return !s.contains("01"); }

int Solution::find_middle_index(std::vector<int> &nums) {
  int total = std::accumulate(nums.begin(), nums.end(), 0);
  int sum = 0;
  for (int i = 0; i < nums.size(); i++) {
    if (2 * sum + nums[i] == total) {
      return i;
    }
    sum += nums[i];
  }
  return -1;
}

int Solution::minimum_moves(std::string s) {
  int res = 0, count = -1;
  for (int i = 0; i < s.size(); i++) {
    if (s[i] == 'X' && i > count) {
      res++;
      count = i + 2;
    }
  }
  return res;
}

std::vector<int> Solution::two_out_of_three(std::vector<int> &nums1,
                                            std::vector<int> &nums2,
                                            std::vector<int> &nums3) {
  std::unordered_map<int, int> map;
  for (auto &num : nums1) {
    map[num] = 1;
  }
  for (auto &num : nums2) {
    map[num] |= 2;
  }
  for (auto &num : nums3) {
    map[num] |= 4;
  }
  std::vector<int> res;
  for (auto &[k, v] : map) {
    if ((v & (v - 1)) != 0) {
      res.emplace_back(k);
    }
  }
  return res;
}

int Solution::min_moves_to_seat(std::vector<int> &seats,
                                std::vector<int> &students) {
  std::sort(seats.begin(), seats.end());
  std::sort(students.begin(), students.end());
  int res = 0;
  for (int i = 0; i < seats.size(); i++) {
    res += std::abs(seats[i] - students[i]);
  }
  return res;
}

bool Solution::are_number_ascending(std::string s) {
  int pre = 0, pos = 0;
  while (pos < s.size()) {
    if (std::isdigit(s[pos])) {
      int curr = 0;
      while (pos < s.size() && std::isdigit(s[pos])) {
        curr = curr * 10 + s[pos] - '0';
        pos++;
      }
      if (curr <= pre) {
        return false;
      }
      pre = curr;
    } else {
      pos++;
    }
  }
  return true;
}

std::vector<int>
Solution::plates_between_candles(std::string s,
                                 std::vector<std::vector<int>> &queries) {
  int n = s.length();
  std::vector<int> preSum(n);
  int sum = 0;
  for (int i = 0; i < n; i++) {
    if (s[i] == '*') {
      sum++;
    }
    preSum[i] = sum;
  }
  std::vector<int> left(n);
  for (int i = 0, l = -1; i < n; i++) {
    if (s[i] == '|') {
      l = i;
    }
    left[i] = l;
  }
  std::vector<int> right(n);
  for (int i = n - 1, r = -1; i >= 0; i--) {
    if (s[i] == '|') {
      r = i;
    }
    right[i] = r;
  }
  std::vector<int> ans;
  for (auto &query : queries) {
    int x = right[query[0]], y = left[query[1]];
    ans.emplace_back(x == -1 || y == -1 || x >= y ? 0 : preSum[y] - preSum[x]);
  }

  return ans;
}

int Solution::count_even(int num) {
  int y = num / 10, x = num % 10;
  int res = y * 5, ySum = 0;
  while (y) {
    ySum += y % 10;
    y /= 10;
  }
  if (ySum % 2 == 0) {
    res += x / 2 + 1;
  } else {
    res += (x + 1) / 2;
  }
  return res - 1;
}

int Solution::prefix_count(std::vector<std::string> &words, std::string pref) {
  return std::count_if(words.begin(), words.end(),
                       [&pref](auto &word) { return word.find(pref) == 0; });
}

char Solution::repeated_character(std::string s) {
  int seen = 0;
  for (int i = 0; i < s.size(); i++) {
    int index = s[i] - 'a';
    if (seen & (1 << index)) {
      return s[i];
    }
    seen |= (1 << index);
  }
  return ' ';
}

int Solution::garbage_collection(std::vector<std::string> &garbage,
                                 std::vector<int> &travel) {
  std::unordered_map<char, int> distances;
  int res = 0, current_distance = 0;
  for (int i = 0; i < garbage.size(); i++) {
    res += garbage[i].size();
    if (i > 0) {
      current_distance += travel[i - 1];
    }

    for (auto c : garbage[i]) {
      distances[c] = current_distance;
    }
  }
  for (auto &[k, v] : distances) {
    res += v;
  }
  return res;
}

int Solution::minimum_sum(std::vector<int> nums) {
  int n = nums.size();
  int mini = 1000, res = 1000;
  std::vector<int> left;
  int right = nums[n - 1];
  for (int i = 1; i < n; i++) {
    left[i] = std::min(left[i - 1], mini);
  }

  for (int i = n - 2; i > 0; i--) {
    if (left[i] < nums[i] && nums[i] > right) {
      res = std::min(res, left[i] + nums[i] + right);
    }
    right = std::min(right, nums[i]);
  }
  return res < 1000 ? res : -1;
}

int Solution::minimum_added_coins(std::vector<int> coins, int target) {
  std::sort(coins.begin(), coins.end());
  int res = 0, x = 1, n = coins.size(), index = 0;
  while (x <= target) {
    if (index < n && coins[index] <= x) {
      x += coins[index];
      index++;
    } else {
      x <<= 1;
      res++;
    }
  }
  return res;
}

std::vector<int> Solution::get_sneaky_numbers(std::vector<int> nums) {
  int n = nums.size() - 2;
  int a = -n * (n - 1) / 2;
  int b = -n * (n - 1) * (n * 2 - 1) / 6;
  for (auto &x : nums) {
    a += x;
    b += x * x;
  }
  int x = (a - std::sqrt(b * 2 - a * a)) / 2;
  return {x, a - x};
}

int Solution::rearrange_characters(std::string s, std::string target) {
  std::unordered_map<char, int> sMap;
  std::unordered_map<char, int> targetMap;
  for (auto ch : s) {
    sMap[ch]++;
  }
  for (auto ch : target) {
    targetMap[ch]++;
  }
  int ans = max_int;
  for (auto ch : target) {
    ans = std::min(ans, sMap[ch] / targetMap[ch]);
  }
  return ans;
}
} // namespace leetcode