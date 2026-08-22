#pragma once

#include <stdbool.h>

#include "data_structures.h"

#define ARRAY(T, ...) \
    (T[]) { __VA_ARGS__ }

#define MATRIX(T, VAR, ROW, COLUMN, ...) \
    (T VAR[ROW][COLUMN]) { __VA_ARGS__ }

#define MATRIX_POINTER(T, VARIABLE) (T **) VARIABLE

int cmp_asc(const void *pa, const void *pb);
int cmp_desc(const void *pa, const void *pb);
int cmp_array(const void *pa, const void *pb);
int cmp_array_of_array_at_first_element(const void *a, const void *b);
int cmp_array_of_array_at_second_element(const void *pa, const void *pb);
int cmp_with_order(const void *pa, const void *pb, const void *context);
void swap_int(int *a, int *b);
void swap_char(char *a, char *b);
int **generate_matrix(const int *nums, const int row_size, const int column_size);
void free_matrix(int **matrix, int row_size);
bool compare_array(const int *array1, const int *array2, const int size);
bool compare_2d_array(int **array1, int **array2, int row_size, int column_size);
int binary_search(const int *arr, int arr_size, int x);
void reverse(int *nums, int start, int end);
TreeNode *generate_tree_node(int val, TreeNode *left, TreeNode *right);
char **split(const char *str, const char separator, size_t *return_size);
ListNode *create_list_node(const int *nums, const int nums_size);
int *convert_list_node_to_array(const ListNode *head, int *return_size);
bool is_same_list_node(const ListNode *lhs, const ListNode *rhs);
int **initialize_matrix(int *nums, int row, int column);
