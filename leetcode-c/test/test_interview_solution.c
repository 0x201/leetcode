//
// Created by trickyrat on 2025/4/14.
//

#include "pch.h"

#include "interview_solution.h"

static void test_is_flipped_string() {
    assert_true(is_flipped_string("waterbottle", "erbottlewat"));
    assert_false(is_flipped_string("aa", "aba"));
}

static void test_get_kth_magic_number() {
    assert_int_equal(get_kth_magic_number(5), 9);
}

int run_interview_solution_tests(void) {
    const struct CMUnitTest interview_solution_tests[] = {
        cmocka_unit_test(test_is_flipped_string),
        cmocka_unit_test(test_get_kth_magic_number),
    };

    return cmocka_run_group_tests(interview_solution_tests, NULL, NULL);
}

