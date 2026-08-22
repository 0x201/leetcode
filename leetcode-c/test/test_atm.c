//
// Created by trickyrat on 2025/4/14.
//

#include "pch.h"
#include "atm.h"
#include "utils.h"

static void test_atm_functionality() {
    ATM *atm = atm_create();
    atm_deposit(atm, ARRAY(int, 0, 0, 1, 2, 1), 5);
    int return_size = 0;
    const int *actual1 = atm_withdraw(atm, 600, &return_size);
    assert_memory_equal(ARRAY(int, 0, 0, 1, 0, 1), actual1, 5);
    atm_deposit(atm, ARRAY(int, 0, 1, 0, 1, 1), 5);
    const int *actual2 = atm_withdraw(atm, 600, &return_size);
    assert_memory_equal(ARRAY(int, -1), actual2, 1);
    const int *actual3 = atm_withdraw(atm, 550, &return_size);
    assert_memory_equal(ARRAY(int, 0, 1, 0, 0, 1), actual3, 5);

    atm_free(atm);
}


int run_atm_tests(void) {
    const struct CMUnitTest atm_tests[] = {
        cmocka_unit_test(test_atm_functionality),
    };

    return cmocka_run_group_tests(atm_tests, NULL, NULL);
}