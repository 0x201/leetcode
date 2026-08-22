

class Node:
    def __init__(self, key: str = "", count: int = 0):
        self.prev: Node = self
        self.next: Node = self
        self.keys: set[str] = set() if key == "" else {key}
        self.count: int = count

    def insert(self, node: Node) -> Node:
        node.prev = self
        node.next = self.next
        node.prev.next = node
        node.next.prev = node
        return node

    def remove(self) -> None:
        self.prev.next = self.next
        self.next.prev = self.prev


class AllOne:
    def __init__(self):
        self.root = Node()
        self.nodes: dict[str, Node] = {}

    def inc(self, key: str) -> None:
        if key not in self.nodes:
            if self.root.next is self.root or self.root.next.count > 1:
                self.nodes[key] = self.root.insert(Node(key, 1))
            else:
                self.root.next.keys.add(key)
                self.nodes[key] = self.root.next
        else:
            curr = self.nodes[key]
            nxt = curr.next
            if nxt is self.root or nxt.count > curr.count + 1:
                self.nodes[key] = curr.insert(Node(key, curr.count + 1))
            else:
                nxt.keys.add(key)
                self.nodes[key] = nxt
            curr.keys.remove(key)
            if len(curr.keys) == 0:
                curr.remove()

    def dec(self, key: str) -> None:
        curr = self.nodes[key]
        pre = curr.prev
        if curr.count == 1:
            del self.nodes[key]
        else:
            if pre is self.root or pre.count < curr.count - 1:
                self.nodes[key] = curr.prev.insert(Node(key, curr.count - 1))
            else:
                pre.keys.add(key)
                self.nodes[key] = pre
        curr.keys.remove(key)
        if len(curr.keys) == 0:
            curr.remove()

    def get_max_key(self) -> str:
        return (
            next(iter(self.root.prev.keys)) if self.root.prev is not self.root else ""
        )

    def get_min_key(self) -> str:
        return (
            next(iter(self.root.next.keys)) if self.root.next is not self.root else ""
        )
