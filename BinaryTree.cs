using System;

namespace Demonstration
{
    /// <summary>
    /// Binary Tree
    /// This solution is a conversion of a java based Binary Tree reference implementation into a C# implementation.
    /// This reference implementation was chosen for its flexibility and completeness
    /// The solution has been modified to use a generic payload.
    /// The solution has also been set up with a unit testing framework to verify it is fully operational
    /// Allman style indenting is used as a default preference with tab based indents
    /// Comments are verbose, for maximum readability, though could be attenuated at will for other situations, if the customer prefers 'quiet' code.
    ///
    /// Style can be modified, based on customer requirements
    ///
    /// This code is presented as an example of what would be provided to a customer, that asked for a Binary Tree, without further specification
    /// The first step towards generating this solution would be to research online, to find a good, legally useable reference implementation
    /// The second would be to implement the solution in the required language, in this case C#
    /// Third, the solution would be set up with automated testing, to prove quality
    /// Finally, the solution would be provided to the client via their preferred channel, in this case github, with appropriately modified licensing.
    ///
    /// All public methods will be tested either directly or indirectly as part of this demonstration
    /// Since this class is generic, a separate class PrintingMethods.cs will be provided to test 
    /// methods that rely primarily on printing.
    ///
    /// Methods with return values shall be tested with XUnit.
    /// </summary>  
    public class BinaryTree<T> where T : IComparable<T> 
    { 
        #region Properties
  
        /// <summary>
        /// Root node. Will be null for an empty tree.     
        /// </summary>
        public Node<T> root { get; set; }
  
        #endregion

        /// <summary>
        /// Node class 
        /// The binary tree is built using this nested node class. 
        /// Each node stores one data element, and has left and right 
        /// sub-tree pointer which may be null. 
        /// The node is a "dumb" nested class -- we just use it for 
        /// storage; it does not have any methods. 
        /// </summary>
        public class Node<U> where U : IComparable<U> 
        {    
            #region Properties

            /// <summary>
            /// Left and Right nodes, and generic payload - standard structure for a binary tree.
            /// </summary>
    	    public Node<U> left { get; set; } 
            public Node<U> right { get; set; } 
            public U data { get; set; } 

            #endregion

            #region Constructor
            /// <summary>
            /// Default constructor for node.
            /// </summary>
            public Node(U newData) 
            { 
                left = null; 
                right = null; 
                data = newData; 
            } 
            #endregion
        } 
    

        #region Constructor
        /// <summary>
        /// Constructor creates an empty binary tree -- a null root pointer. 
        /// </summary>
  	    public BinaryTree() 
    	{
            root = null; 
  	    } 
        #endregion
 

        #region Methods
        // Note - I am mixing public and private methods in the same region to group them together by function

        /// <summary>
        /// Lookup returns true if the given target is in the binary tree. 
   		/// Uses a recursive helper. 
        /// </summary>
  	    public bool Lookup(T data) 
	    { 
   		    return(Lookup(root, data)); 
  	    } 


        /// <summary>
   		/// Recursive Lookup  -- given a node, recur 
   		/// down searching for the given data. 
        /// </summary>
  	    private bool Lookup(Node<T> node, T data) 
	    { 
    	    if (node==null) 
		    { 
    		    return(false); 
    	    }
 
            // If data == node.data, with IComparable
        	if (data.CompareTo(node.data)==0) 
	    	{ 
    	    	return(true); 
    	    } 
            // if data < node.data
        	else if (data.CompareTo(node.data)<0) 
		    { 
      			return(Lookup(node.left, data)); 
    		} 
    		else 
            // data > node.data
		    { 
      			return(Lookup(node.right, data)); 
    		} 
  	    } 
  

        /// <summary>
   		/// Inserts the given data into the binary tree. 
   		/// Uses a recursive helper. 
        /// </summary>
  	    public void Insert(T data) 
	    { 
    	    root = Insert(root, data); 
  	    } 
  

        /// <summary>
   		/// Recursive insert -- given a node pointer, recur down and 
   		/// insert the given data into the tree. Returns the new 
   		/// node pointer (the standard way to communicate 
   		/// a changed pointer back to the caller). 
        /// </summary>
  	    private Node<T> Insert(Node<T> node, T data) 
	    { 
    	    if (node==null) 
		    { 
    		    node = new Node<T>(data); 
    	    } 
    	    else 
		    { 
                // data <= node.data
    		    if (data.CompareTo(node.data) < 1) 
			    { 
       			    node.left = Insert(node.left, data); 
    		    } 
        	    else 
                // data > node.data
			    { 
        		    node.right = Insert(node.right, data); 
    		    } 
		    } 
            return(node); // in any case, return the new pointer to the caller 
  	    } 


        /// <summary>
 		/// Build 123 by calling insert() three times. 
 		/// Note that the 'Two' must be inserted first. 
        /// Parameters must be ordered by Comparable from smallest to largest
        /// </summary>
	    public void Build123c(T One, T Two, T Three) 
	    { 
  		    root = null; 
  		    root = Insert(root, Two); 
  		    root = Insert(root, One); 
  		    root = Insert(root, Three); 
	    } 
  
  
        /// <summary>
		/// Size
 		/// Returns the number of nodes in the tree. 
 		/// Uses a recursive helper that recurs 
 		/// down the tree and counts the nodes. 
        /// </summary>
	    public int Size() 
	    { 
  		    return(Size(root)); 
	    }

	    private int Size(Node<T> node) 
	    { 
  		    if (node == null)
		    {
		 	    return(0);
		    } 
  		    else 
		    { 
   	 		    return(Size(node.left) + 1 + Size(node.right)); 
  		    } 
	    } 
  

        /// <summary>
		/// MaxDepth Returns the max root-to-leaf depth of the tree. 
 		/// Uses a recursive helper that recurs down to find 
 		/// the max depth. 
        /// </summary>
	    public int MaxDepth() 
	    { 
  		    return(MaxDepth(root)); 
	    }

	    private int MaxDepth(Node<T> node) 
	    { 
  		    if (node==null) 
		    { 
    		    return(0); 
  		    } 
  		    else 
		    { 
    		    int lDepth = MaxDepth(node.left); 
    		    int rDepth = MaxDepth(node.right); 
    			
			    // use the larger + 1 
    		    return(Math.Max(lDepth, rDepth) + 1); 
  		    } 
	    } 
  

        /// <summary>
		/// MinValue Returns the min value in a non-empty binary search tree. 
 		/// Uses a helper method that iterates to the left to find 
 		/// the min value. 
        /// </summary>
	    public T MinValue() 
	    { 
 		    return( MinValue(root) ); 
	    } 


        /// <summary>
		/// MinValue Finds the min value in a non-empty binary search tree. 
        /// </summary>
	    private T MinValue(Node<T> node) 
	    { 
  		    Node<T> current = node; 
  		    while (current.left != null) 
		    { 
    		    current = current.left; 
  		    } 
  		    return(current.data); 
	    } 


        /// <summary>
		/// PrintTree Prints the node values in the "inorder" order. 
 		/// Uses a recursive helper to do the traversal. 
        /// </summary>
	    public void PrintTree() 
	    { 
 		    PrintTree(root); 
	    }

	    private void PrintTree(Node<T> node) 
	    { 
 		    if (node == null) 
			    return; 
 
		    // left, node itself, right 
 		    PrintTree(node.left); 
 		    Console.WriteLine(node.data + "  "); 
 		    PrintTree(node.right); 
	    } 
  

        /// <summary>
		/// PrintPostorder Prints the node values in the "postorder" order. 
 		/// Uses a recursive helper to do the traversal. 
        /// </summary>
	    public void PrintPostorder() 
	    { 
 		    PrintPostorder(root); 
	    }

	    public void PrintPostorder(Node<T> node) 
	    { 
  		    if (node == null) 
			    return; 
  
		    // first recur on both subtrees 
  		    PrintPostorder(node.left); 
  		    PrintPostorder(node.right); 
  
		    // then deal with the node 
 		    Console.WriteLine(node.data + "  "); 
	    } 
  

        /// <summary>
 		/// Mirror - Changes the tree into its mirror image. 
 		/// So the tree... 
		///        4 
		///       / \ 
		///      2   5 
		///     / \ 
		///    1   3 
 		/// is changed to... 
		///        4 
		///       / \ 
		///      5   2 
		///         / \ 
		///        3   1 
 		/// Uses a recursive helper that recurs over the tree, 
 		/// swapping the left/right pointers. 
        /// </summary>
	    public void Mirror() 
	    { 
  		    Mirror(root); 
	    }

	    private void Mirror(Node<T> node) 
	    { 
  		    if (node != null) 
		    { 
    			// do the sub-trees 
    			Mirror(node.left); 
    			Mirror(node.right); 
    
			    // swap the left/right pointers 
    			Node<T> temp = node.left; 
    			node.left = node.right; 
    			node.right = temp; 
  		    } 
	    } 
  


        /// <summary>
		/// DoubleTree
 		/// Changes the tree by inserting a duplicate node 
 		/// on each nodes's .left.
		/// So the tree... 
		///    2 
		///   / \ 
		///  1   3 
		/// Is changed to... 
		///        2 
		///       / \ 
		///      2   3 
		///     /   / 
		///    1   3 
		///   / 
		///  1 
 		/// Uses a recursive helper to recur over the tree 
 		/// and insert the duplicates. 
        /// </summary>
	    public void DoubleTree() 
	    { 
 		    DoubleTree(root); 
	    }

	    private void DoubleTree(Node<T> node) 
	    { 
  		    Node<T> oldLeft; 
  		    if (node == null) 
			    return; 
  
		    // do the subtrees 
  		    DoubleTree(node.left); 
  		    DoubleTree(node.right); 
  
		    // duplicate this node to its left 
  		    oldLeft = node.left; 
  	    	node.left = new Node<T>(node.data); 
  		    node.left.left = oldLeft; 
	    } 
 

        /// <summary>
		/// SameTree Compares the receiver to another tree to 
 		/// see if they are structurally identical. 
        /// </summary>
	    public bool SameTree(BinaryTree<T> other) 
	    { 
 		    return( SameTree(root, other.root) ); 
	    } 


        /// <summary>
 		/// Recursive SameTree helper -- recurs down two trees in parallel, 
 		/// checking to see if they are identical. 	
        /// </summary>
	    bool SameTree(Node<T> a, Node<T> b) 
	    { 
  		    // 1. both empty -> true 
  		    if (a==null && b==null) 
			    return(true); 
  
		    // 2. both non-empty -> compare them 
  		    else if (a!=null && b!=null) 
		    { 
    		    return
			    ( 
                    // a.data == b.data 
      			    (a.data.CompareTo(b.data)==0) && 
      			    SameTree(a.left, b.left) && 
      			    SameTree(a.right, b.right) 
    		    ); 
  		    } 
  		
		    // 3. one empty, one not -> false 
  		    else return(false); 
	    } 
  

        /// <summary>
		/// CountTrees - For the key values 1...numKeys, how many structurally unique 
 		/// binary search trees are possible that store those keys? 
 		/// Strategy: consider that each value could be the root. 
 		/// Recursively find the size of the left and right subtrees. 	
        /// </summary>
	    public static int CountTrees(int numKeys) 
	    { 
  		    if (numKeys <=1) 
		    { 
    		    return(1); 
  		    } 
  		    else 
		    { 
    		    // there will be one value at the root, with whatever remains 
    		    // on the left and right each forming their own subtrees. 
    		    // Iterate through all the values that could be the root... 
    		    int sum = 0; 
    		    int left, right, root; 
    		    for (root=1; root<=numKeys; root++) 
		        { 
      			    left = CountTrees(root-1); 
      			    right = CountTrees(numKeys - root); 
      				
				    // number of possible trees with this root == left*right 
      			    sum += left*right; 
    		    } 
    		    return(sum); 
  		    } 
	    } 

        #endregion

    }
}
