class Node:
    def __init__(self, val: int = 0, children: list[Node] | None = None):
        self.val: int = val
        self.children: list[Node] = children if children is not None else []
