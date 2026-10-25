package org.zerox201;

import org.zerox201.DataStructures.TreeNode;

public class QueueNode {
    TreeNode node;
    int depth;

     public QueueNode(TreeNode node, int depth) {
         this.node = node;
         this.depth = depth;
     }
}
