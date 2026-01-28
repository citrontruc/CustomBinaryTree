# Custom Binary Tree

A project to implement a binary search tree and implement tree search methods.

## Content

### Trees

Code for the implementation of trees is stored in the BinaryTree folder.

The project has four different types of trees:

- Binary Trees (No constraints on nodes, they can have up to two child nodes).
- Binary Search Trees (Nodes have an order relationship).
- Balanced Binary trees (Nodes don't have any value based relationships but depth difference right and left branches must be at most 1).
- Balanced Binary trees (all the previous constaints).

All operations (adding nodes, removing nodes) must protect the relationship.

Tests are stored in the BinaryTree.Test folder.

### Bonus Content

In order to try out Trees in practice, the repo also contains a set of methods to find if elements from a list are in a secondlist. One of the methods uses trees.

## Available methods

All trees have the following methods:

- GetNode(): returns tree node.
- GetMaxDepth(): return the depth of the deepest leaf node.
- GetMinDepth(): return the depth of the shallowest leaf node.
- GetSize(): returns number of nodes in tree.
- Contains(T value): checks if the value is in the tree.
- AddNode(T value): adds a node to the tree following the tree's properties and rules.
- RemoveFirstNodeWithValue(T value): removes the first node found in the tree following the tree's properties and rules.
- PreOrderTraversal(), InOrderTraversal(), PostOrderTraversal(), BreadthFirstTraversal() => Methods for tree traversal.
- IsBalanced(): checks if tree is balanced.
- IsBinarySearchTree(): checks if tree is a binary search tree.

Have a great day :smiley:!!
