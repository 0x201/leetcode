#include <stdlib.h>
#include <string.h>

#include "atm.h"

#define MIN(a, b) ((a) < (b) ? (a) : (b))

ATM *atm_create() {
    ATM *atm = malloc(sizeof(ATM));
    memset(atm, 0, sizeof(ATM));
    atm->value[0] = 20;
    atm->value[1] = 50;
    atm->value[2] = 100;
    atm->value[3] = 200;
    atm->value[4] = 500;
    return atm;
}

void atm_deposit(ATM *obj, const int *bank_notes_count, int bank_notes_count_size) {
    for (int i = 0; i < 5; ++i) {
        obj->count[i] += bank_notes_count[i];
    }
}

int *atm_withdraw(ATM *atm, int amount, int *return_size) {
    int *res = malloc(sizeof(int) * 5);
    *return_size = 5;
    for (int i = 4; i >= 0; --i) {
        res[i] = MIN(atm->count[i], amount / atm->value[i]);
        amount -= res[i] * atm->value[i];
    }

    if (amount) {
        res = (int *) malloc(sizeof(int));
        *return_size = 1;
        res[0] = -1;
        return res;
    }
    for (int i = 0; i < 5; ++i) {
        atm->count[i] -= res[i];
    }
    return res;
}

void atm_free(ATM *obj) {
    free(obj);
}
