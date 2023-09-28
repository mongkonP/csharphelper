
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

  namespace  howto_test_priority_queues

 { 

class HeapQueue<T>
    {
        // A class to store a value.
        private class DataNode
        {
            public T Data;
            public int Priority;

            private DataNode _LeftChild;
            public DataNode LeftChild
            {
                get { return _LeftChild; }
                set
                {
                    _LeftChild = value;
                    if (_LeftChild != null) _LeftChild.Parent = this;
                }
            }

            private DataNode _RightChild;
            public DataNode RightChild
            {
                get { return _RightChild; }
                set
                {
                    _RightChild = value;
                    if (_RightChild != null) _RightChild.Parent = this;
                }
            }

            public DataNode Parent { get;set; }

            public DataNode(T data, int priority)
            {
                Data = data;
                Priority = priority;
                LeftChild = null;
                RightChild = null;
                Parent = null;
            }

            public override string ToString()
            {
                return Data.ToString() + " (" + Priority.ToString() + ")";
            }

            // Display the subtree in the Console window.
            public void PrintSubtree(int indent)
            {
                Console.WriteLine(new string(' ', indent) + ToString());
                if (LeftChild != null) LeftChild.PrintSubtree(indent + 4);
                if (RightChild != null) RightChild.PrintSubtree(indent + 4);
            }

            // Find the indicated node in this subtree.
            public DataNode FindNodeByNumber(int number)
            {
                // If this is the root node, return it.
                if (number <= 0) return this;

                // Add 1 to the number so the numbers at each level
                // in the tree has the same number of bits.
                number++;

                // Find the least significant bit.
                int msb = FindMsb(number);

                // Climb down through the tree.
                DataNode node = this;
                for (int i = msb - 1; i >= 0; i--)
                {
                    // Use this bit to decide which way to go.
                    if ((number & (1 << i)) == 0)
                        node = node.LeftChild;
                    else
                        node = node.RightChild;

                    // See if we fell off the tree.
                    if (node == null) return null;
                }

                // Return the current node.
                return node;
            }

            // Find the node that would be the parent
            // of the node with the indicated number.
            public DataNode FindNodeParentByNumber(int child_number)
            {
                Debug.Assert(child_number >= 0);

                // Find the parent node's number.
                int parent_number = (child_number - 1) / 2;

                return FindNodeByNumber(parent_number);
            }

            // Return the number's least significant bit.
            private int FindMsb(int number)
            {
                for (int i = 31; i >= 0; i--)
                    if ((number & (1 << i)) != 0) return i;
                return -1;
            }
        }

        // The items and priorities.
        private DataNode Root = null;
        private int _NumItems = 0;

        // Return the number of items in the queue.
        public int NumItems
        {
            get { return _NumItems; }
        }

        // Add an item to the queue.
        public void Enqueue(T new_value, int new_priority)
        {
            // Make the new data node.
            DataNode child = new DataNode(new_value, new_priority);

            // If the heap is empty, create it.
            if (Root == null)
            {
                Root = child;
                _NumItems = 1;

                // Display the new heap.
                //Root.PrintSubtree(0);
                //Console.WriteLine();
                return;
            }

            // Get the new node's number.
            int new_node_number = _NumItems++;

            // Find the parent of the new node.
            DataNode parent = Root.FindNodeParentByNumber(new_node_number);

            // Add the new node to the parent.
            if (parent.LeftChild == null)
                parent.LeftChild = child;
            else
                parent.RightChild = child;

            // Swap the new node up to the root fixing the heap.
            while (child.Parent != null)
            {
                // If the parent's priority is bigger,
                // the heap is fixed so we're done.
                if (child.Priority <= child.Parent.Priority) break;

                // Swap the new node and its parent.
                SwapNodes(parent, child);

                // Move up.
                child = parent;
                parent = child.Parent;

            }

            // Display the new heap.
            //Root.PrintSubtree(0);
            //Console.WriteLine();
        }

        // Remove the item with the largest priority from the queue.
        public void Dequeue(out T top_value, out int top_priority)
        {
            // Make sure the heap isn't empty.
            if (_NumItems < 1)
                throw new Exception("The queue is empty");

            // Save the return values.
            top_value = Root.Data;
            top_priority = Root.Priority;
            _NumItems--;

            // If the heap has only one node, empty it.
            if (_NumItems == 0)
            {
                Root = null;
                return;
            }

            // Find the parent of the last node.
            DataNode parent = Root.FindNodeParentByNumber(_NumItems);

            // Find the last node.
            DataNode last_node;
            if (parent.RightChild != null)
            {
                last_node = parent.RightChild;
                parent.RightChild = null;
            }
            else
            {
                last_node = parent.LeftChild;
                parent.LeftChild = null;
            }
            Debug.Assert(last_node != null);

            // Copy the last node's values to the root.
            Root.Data = last_node.Data;
            Root.Priority = last_node.Priority;

            // Push the data down through the tree.
            DataNode node = Root;
            while (node != null)
            {
                // See if node is bigger than its children.
                // Get the child priorities.
                int left_priority = int.MinValue;
                if (node.LeftChild != null)
                    left_priority = node.LeftChild.Priority;

                int right_priority = int.MinValue;
                if (node.RightChild != null)
                    right_priority = node.RightChild.Priority;

                // If the node has higher priority than its children,
                // then the tree is again a heap and we're done.
                if ((node.Priority > left_priority) &&
                    (node.Priority > right_priority)) break;

                // Swap the node with its larger child.
                if (left_priority > right_priority)
                {
                    // Swap with the left child.
                    SwapNodes(node, node.LeftChild);

                    // Move down to the left child.
                    node = node.LeftChild;
                }
                else
                {
                    // Swap with the right child.
                    SwapNodes(node, node.RightChild);

                    // Move down to the right child.
                    node = node.RightChild;
                }
            }

            // Display the new heap.
            //Root.PrintSubtree(0);
            //Console.WriteLine();
        }

        // Swap the contents of two DataNode objects.
        private void SwapNodes(DataNode node1, DataNode node2)
        {
            T temp_data = node1.Data;
            int temp_priority = node1.Priority;

            node1.Data = node2.Data;
            node1.Priority = node2.Priority;

            node2.Data = temp_data;
            node2.Priority = temp_priority;
        }
    }








    class PriorityQueue<T>
    {
        // The items and priorities.
        List<T> Values = new List<T>();
        List<int> Priorities = new List<int>();

        // Return the number of items in the queue.
        public int NumItems
        {
            get
            {
                return Values.Count;
            }
        }

        // Add an item to the queue.
        public void Enqueue(T new_value, int new_priority)
        {
            Values.Add(new_value);
            Priorities.Add(new_priority);
        }

        // Remove the item with the largest priority from the queue.
        public void Dequeue(out T top_value, out int top_priority)
        {
            // Find the hightest priority.
            int best_index = 0;
            int best_priority = Priorities[0];
            for (int i = 1; i < Priorities.Count; i++)
            {
                if (best_priority < Priorities[i])
                {
                    best_priority = Priorities[i];
                    best_index = i;
                }
            }

            // Return the corresponding item.
            top_value = Values[best_index];
            top_priority = best_priority;

            // Remove the item from the lists.
            Values.RemoveAt(best_index);
            Priorities.RemoveAt(best_index);
        }
    }

}