#include "testcases.h"

int main() {
    int result = 0;
    result += run_atm_tests();
    result += run_interview_solution_tests();
    result += run_solution_tests();
    return result;
}
