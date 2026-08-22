#include <stdlib.h>
#include <string.h>

#include "utils.h"

int cmp_asc(const void *pa, const void *pb) {
    return *(int *) pa - *(int *) pb;
}

int cmp_desc(const void *pa, const void *pb) {
    return *(int *) pb - *(int *) pa;
}

int cmp_array(const void *pa, const void *pb) {
    const int *a = *(int **) pa;
    const int *b = *(int **) pb;
    return a[1] - b[1];
}

int cmp_array_of_array_at_first_element(const void *a, const void *b) {
    return (*(int **) a)[0] - (*(int **) b)[0];
}

int cmp_array_of_array_at_second_element(const void *pa, const void *pb) {
    return (*(int **) pa)[1] - (*(int **) pb)[1];
}

int cmp_with_order(const void *pa, const void *pb, const void *context) {
    const int order = *(int *) context;
    int result = *(int *) pa - *(int *) pb;
    if (order) {
        result *= -1;
    }
    return result;
}

void swap_int(int *a, int *b) {
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

void swap_char(char *a, char *b) {
    const char tmp = *a;
    *a = *b;
    *b = tmp;
}

int **generate_matrix(const int *nums, const int row_size, const int column_size) {
    int **matrix = malloc(row_size * sizeof(int *));

    for (int row = 0; row < row_size; row++) {
        matrix[row] = (int *) malloc(column_size * sizeof(int));
    }

    for (int row = 0; row < row_size; row++) {
        for (int column = 0; column < column_size; column++) {
            matrix[row][column] = nums[row * column_size + column];
        }
    }

    return matrix;
}

void free_matrix(int **matrix, const int row_size) {
    for (int i = 0; i < row_size; i++) {
        free(matrix[i]);
    }
    free(matrix);
}

bool compare_array(const int *array1, const int *array2, const int size) {
    for (int i = 0; i < size; i++) {
        if (array1[i] != array2[i]) {
            return false;
        }
    }
    return true;
}

bool compare_2d_array(int **array1, int **array2, const int row_size, const int column_size) {
    for (int row = 0; row < row_size; row++) {
        for (int column = 0; column < column_size; column++) {
            if (array1[row][column] != array2[row][column]) {
                return false;
            }
        }
    }
    return true;
}

int binary_search(const int *arr, const int arr_size, int x) {
    int low = 0, high = arr_size - 1;
    while (low < high) {
        const int mid = low + (high - low) / 2;
        if (arr[mid] >= x) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

void reverse(int *nums, int start, int end) {
    while (start < end) {
        swap_int(&nums[start], &nums[end]);
        start++;
        end--;
    }
}

TreeNode *generate_tree_node(const int val, TreeNode *left, TreeNode *right) {
    TreeNode *node = malloc(sizeof(TreeNode));
    node->val = val;
    node->left = left;
    node->right = right;
    return node;
}

char **split(const char *str, const char separator, size_t *return_size) {
    const size_t n = strlen(str);
    char **words = malloc(sizeof(char *) * n);
    size_t words_size = 0, pos = 0;
    while (pos < n) {
        while (pos < n && str[pos] == separator) {
            pos++;
        }
        if (pos < n) {
            const size_t curr = pos;
            while (pos < n && str[pos] != separator) {
                pos++;
            }
            const size_t alloc_size = sizeof(char) * (pos - curr + 1);
            words[words_size] = (char *) malloc(alloc_size);
            strncpy(words[words_size], str + curr, pos - curr);
            words[words_size++][pos - curr] = '\0';
        }
    }
    *return_size = words_size;
    return words;
}

ListNode *create_list_node(const int *nums, const int nums_size) {
    ListNode *head = malloc(sizeof(ListNode));
    head->val = 0;
    ListNode *dummy = head;
    for (int i = 0; i < nums_size; ++i) {
        ListNode *node = malloc(sizeof(ListNode));
        node->val = nums[i];
        if (i == nums_size - 1) {
            node->next = NULL;
        }
        dummy->next = node;
        dummy = dummy->next;
    }
    return head->next;
}

int *convert_list_node_to_array(const ListNode *head, int *returnSize) {
    ListNode *dummy1 = (ListNode *) malloc(sizeof(ListNode));
    ListNode *dummy2 = (ListNode *) malloc(sizeof(ListNode));
    memcpy(dummy1, head, sizeof(ListNode));
    memcpy(dummy2, head, sizeof(ListNode));
    int count = 0;
    while (dummy1) {
        count++;
        dummy1 = dummy1->next;
    }
    int *res = (int *) malloc(sizeof(int) * count);
    for (int i = 0; i < count; ++i) {
        res[i] = dummy2->val;
        dummy2 = dummy2->next;
    }
    *returnSize = count;
    return res;
}

bool is_same_list_node(const ListNode *lhs, const ListNode *rhs) {
    if ((lhs == NULL && rhs != NULL) || (lhs != NULL && rhs == NULL)) {
        return false;
    }
    ListNode *dummy1 = (ListNode *) malloc(sizeof(ListNode));
    ListNode *dummy2 = (ListNode *) malloc(sizeof(ListNode));
    memcpy(dummy1, lhs, sizeof(ListNode));
    memcpy(dummy2, rhs, sizeof(ListNode));

    while (dummy1 && dummy2) {
        if (dummy1->val != dummy2->val) {
            return false;
        }
        dummy2 = dummy2->next;
        dummy1 = dummy1->next;
        if ((dummy1 == NULL && dummy2 != NULL) || (dummy1 != NULL && dummy2 == NULL)) {
            return false;
        }
    }

    return true;
}

int **initialize_matrix(int *nums, int row, int column) {
    int **matrix = (int **) malloc(row * sizeof(int *));
    for (int i = 0; i < row; i++) {
        matrix[i] = (int *) malloc(column * sizeof(int));
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < column; ++j) {
            matrix[i][j] = *nums++;
        }
    }
    return matrix;
}
