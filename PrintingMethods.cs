using System;

namespace Demonstration
{
    public class PrintingMethods
    {
        public static void Main(string[] args)
        {
            // As part of this demonstration we'll either test all public methods either manually in the main
            // method, or using XUnit Unit tests.
            // We'll use the main method for tests of methods that rely on Console.WriteLine for their function
            // And also for methods that are most easily tested with other methods that rely on Console.WriteLine.
            // This includes PrintTree, PrintPostorder, Mirror and DoubleTree

            // Methods Lookup, Size, MaxDepth, MinValue, SameTree and CountTrees will be tested with XUnit

            // Build123c will be used to set up data for all tests, and depends on Insert
            
            Console.WriteLine("Binary Array Main Method Tests");   
            
            //Setting up three comparables - simplest possible case, 3 Int32 variables: 1,2,3.
            Int32 varOne = 1;
            Int32 varTwo = 2;
            Int32 varThree = 3;

            //Create a BinaryTree specific to Int32
            BinaryTree<Int32> BTree = new BinaryTree<Int32>();
            //Build our simplest possible test case, using Insert
            BTree.Build123c(varOne, varTwo, varThree);

            //Enumerate through Methods producing int or bool outputs
            Console.WriteLine("Lookup 2? "+BTree.Lookup(varTwo));
            Console.WriteLine("Size: "+ BTree.Size());
            Console.WriteLine("MaxDepth: "+BTree.MaxDepth());
            Console.WriteLine("MinValue: "+BTree.MinValue());
            Console.WriteLine("Same Tree? "+BTree.SameTree(BTree));
            Console.WriteLine("Count Trees(4): "+BinaryTree<Int32>.CountTrees(4));

            //Enumerate through Methods requiring Console.Writeline output
            Console.WriteLine("PrintTree:");
            BTree.PrintTree();

            Console.WriteLine("PrintPostOrder:");
            BTree.PrintPostorder();

            Console.WriteLine("Mirrored:");
            BTree.Mirror();
            BTree.PrintTree();

            Console.WriteLine("Mirrored Again:");
            BTree.Mirror();
            BTree.PrintTree();

            Console.WriteLine("Doubled:");
            BTree.DoubleTree();
            BTree.PrintTree();

            Console.WriteLine("End of Tests"); 

            // Expected Results Indicating Correct Operation:
            // Binary Array Main Method Tests
            // Lookup 2? True
            // Size: 3
            // MaxDepth: 2
            // MinValue: 1
            // Same Tree? True
            // Count Trees(4): 14
            // PrintTree:
            // 1
            // 2
            // 3
            // PrintPostOrder:
            // 1
            // 3
            // 2
            // Mirrored:
            // 3
            // 2
            // 1
            // Mirrored Again:
            // 1
            // 2
            // 3
            // Doubled:
            // 1
            // 1
            // 2
            // 2
            // 3
            // 3
            // End of Tests

            //Appearance of the above console output indicates full functionality of all present methods for simplest test case.
        }
    }
}