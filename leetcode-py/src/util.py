from __future__ import annotations

from collections import deque

from src.data_structures.list_node import ListNode
from src.data_structures.node import Node
from src.data_structures.tree_node import TreeNode


class Util:
    @staticmethod
    def generate_list_node(nodes: list[int]) -> ListNode | None:
        """
        Generate a linked-list with a list

        Args:

        nodes List[int]: The list of nodes

        Returns:

        Optional[ListNode]: The head of the linked-list

        """
        dummy = ListNode(0)
        curr = dummy
        for node in nodes:
            curr.next = ListNode(node)
            curr = curr.next
        return dummy.next

    @staticmethod
    def list_node_to_string(head: ListNode | None, sep: str = "->") -> str:
        """

        Convert a linked-list to string

        Args:

        head Optional[ListNode]: The head of the linked-list

        sep str: The separator between each node, default is "->"

        Returns:

        str: The string representation of the linked-list

        """
        if head is None:
            return ""

        seen: set[ListNode] = set()
        cycle_node: ListNode | None = None
        curr: ListNode = head
        while curr is not None:
            if curr in seen:
                cycle_node: ListNode = curr
                break
            seen.add(curr)
            curr: ListNode | None = curr.next

        parts: list[str] = []
        curr: ListNode = head
        visited: set[ListNode] = set()
        while curr is not None:
            if curr in visited:
                break
            visited.add(curr)
            parts.append(str(curr.val))
            if curr.next is not None:
                parts.append(sep)
            curr: ListNode | None = curr.next
            if curr is not None and curr == cycle_node:
                parts.append(f"{cycle_node.val}{sep}...")
                break

        return "".join(parts)

    @staticmethod
    def list_node_to_list(head: ListNode | None) -> list[int]:
        """
        Convert a linked-list to a list

        Args:
            head (Optional[ListNode]): The head of the linked-list

        Returns:
            List[int]: The list of node values
        """
        res: list[int] = []
        curr: ListNode | None = head
        while curr is not None:
            res.append(curr.val)
            curr: ListNode | None = curr.next
        return res

    @staticmethod
    def generate_tree_node(nums: list[int | None]) -> TreeNode | None:
        """

        Generate a binary tree node

        Args:

        nums: (List[int | None]): List of values

        Returns:

        Optional[TreeNode]: The root node of binary tree

        """
        if not nums or nums[0] is None:
            return None

        root = TreeNode(nums[0])
        queue: deque[TreeNode] = deque([root])
        i = 1
        n: int = len(nums)

        while queue and i < n:
            parent: TreeNode = queue.popleft()

            if i < n:
                val: int | None = nums[i]
                if val is not None:
                    parent.left = TreeNode(val)
                    queue.append(parent.left)
                i += 1
            if i < n:
                val: int | None = nums[i]
                if val is not None:
                    parent.right = TreeNode(val)
                    queue.append(parent.right)
                i += 1
        return root

    @staticmethod
    def generate_n_tree_node(nums: list[int | None]) -> Node | None:
        """

        Generate an n-ary tree node with a list

        Args:

        nums: (List[Optional[int]]): List of values

        Returns:

        Optional[Node]: The root node of n-ary tree
        """
        if not nums or nums[0] is None:
            return None

        root = Node(nums[0], [])
        i = 1
        n: int = len(nums)
        if i < n and nums[i] is None:
            i += 1

        queue: deque[Node] = deque()
        while i < n and nums[i] is not None:
            child = Node(nums[i], [])
            root.children.append(child)
            queue.append(child)
            i += 1
        if i < n and nums[i] is None:
            i += 1

        while queue and i < n:
            parent = queue.popleft()
            while i < n and nums[i] is not None:
                child = Node(nums[i], [])
                parent.children.append(child)
                queue.append(child)
                i += 1
            if i < n and nums[i] is None:
                i += 1

        return root

    @staticmethod
    def level_traverse(root: TreeNode | None) -> list[int]:
        if root is None:
            return []
        queue: deque[TreeNode] = deque([root])
        res: list[int] = []
        while queue:
            node: TreeNode = queue.popleft()
            res.append(node.val)
            if node.left is not None:
                queue.append(node.left)
            if node.right is not None:
                queue.append(node.right)
        return res
