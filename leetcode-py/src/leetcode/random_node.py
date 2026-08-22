from random import randrange

from src.data_structures.list_node import ListNode


class RandomNode:
    def __init__(self, head: ListNode | None):
        self.head = head

    def get_random(self) -> int:
        curr, i, ans = self.head, 1, 0
        while curr:
            if randrange(i) == 0:
                ans = curr.val
            i += 1
            curr = curr.next
        return ans
