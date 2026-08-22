class ListNode:
    """
    Definition for singly-linked list.
    """

    def __init__(self, val: int = 0, _next: ListNode | None = None) -> None:
        self.val: int = val
        self.next: ListNode | None = _next

    def __lt__(self, other):
        return True if self.val < other.val else False
