#include <stdlib.h>
#include <stdio.h>
#include <string.h>

#include "interview_solution.h"

#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

bool is_flipped_string(const char *s1, const char *s2) {
    const size_t m = strlen(s1), n = strlen(s2);
    if (m != n) {
        return false;
    }
    const size_t size = sizeof(char) * (m + n + 1);
    char *str = malloc(size);
    sprintf(str, "%s%s", s2, s2);
    const bool result = strstr(str, s1) != NULL;
    free(str);
    return result;
}

int get_kth_magic_number(int k) {
    int *dp = malloc(sizeof(int) * (k + 1));
    dp[1] = 1;
    int p3 = 1, p5 = 1, p7 = 1;
    for (int i = 2; i <= k; ++i) {
        const int num3 = dp[p3] * 3, num5 = dp[p5] * 5, num7 = dp[p7] * 7;
        dp[i] = MIN(MIN(num3, num5), num7);
        if (dp[i] == num3) {
            p3++;
        }
        if (dp[i] == num5) {
            p5++;
        }
        if (dp[i] == num7) {
            p7++;
        }
    }
    const int result = dp[k];
    free(dp);
    return result;
}