#pragma once

typedef struct {
    long long count[5];
    long long value[5];
} ATM;

ATM *atm_create();
void atm_deposit(ATM *obj, const int *bank_notes_count, int bank_notes_count_size);
int *atm_withdraw(ATM *atm, int amount, int *return_size);
void atm_free(ATM *obj);
