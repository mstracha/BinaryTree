using Xunit;
using System;

namespace Demonstration
{
    public class TestClass
    {
        #region Private Variables
        // BinaryTree and payloads 1, 2 and 3 set up as in Main method of PrintingMethods class, for simplest test case
        private BinaryTree<Int32> _bTree;
        private Int32 _varOne = 1;
        private Int32 _varTwo = 2;
        private Int32 _varThree = 3;

        #endregion

        #region Private Methods
        /// <summary>
        /// InitTree method sets up _bTree with simplest test case, using elements 1, 2, 3.
        /// This method is reused to initialize the _bTree variable again for each test.
        /// </summary>
        private void InitTree()
        {
            _bTree = new BinaryTree<Int32>();
            _bTree.Build123c(_varOne, _varTwo, _varThree);
        }
        #endregion

        #region Tests
        /// <summary>
        /// Test to see if element 2 is in tree.  Expected result:  True
        /// </summary>
        [Theory]
        [InlineData(2)]
        public void PassingLookupTest(Int32 value)
        {
            InitTree();
            Assert.True(_bTree.Lookup(value));
        }

        /// <summary>
        /// Test to see if size is 3.  Expected result equal.
        /// </summary>
        [Theory]
        [InlineData(3)]
        public void PassingSizeTest(int size)
        {
            InitTree();
            Assert.Equal(size,_bTree.Size());
        }

        /// <summary>
        /// Test to see if max depth is 2.  Expected result equal.
        /// </summary>
        [Theory]
        [InlineData(2)]
        public void PassingMaxDepthTest(int depth)
        {
            InitTree();
            Assert.Equal(depth,_bTree.MaxDepth());
        }

        /// <summary>
        /// Test to see if min value is 1.  Expected result equal.
        /// </summary>
        [Theory]
        [InlineData(1)]
        public void PassingMinValueTest(int value)
        {
            InitTree();
            Assert.Equal(value,_bTree.MinValue());
        }

        /// <summary>
        /// Test to see if a BTree is equal to itself.   Expected result is always true for all BTrees, and thus is a fact, not a theory.
        /// </summary>
        [Fact]
        public void PassingSameTreeTest()
        {
            InitTree();
            Assert.True(_bTree.SameTree(_bTree));
        }

        /// <summary>
        /// Test to see if tree count for 4 is 14.  Expected result equal.
        /// </summary>
        [Theory]
        [InlineData(4)]
        public void CountTreesTheory(int TestNumber)
        {
            Assert.Equal(14,BinaryTree<Int32>.CountTrees(TestNumber));
        }
        #endregion

        // Expected Results:
        // PS C:\Users\codes\gitrepos\BinaryTree\BinaryTree> dotnet test
        // Test run for C:\Users\codes\gitrepos\BinaryTree\BinaryTree\bin\Debug\netcoreapp3.0\BinaryTree.dll(.NETCoreApp,Version=v3.0)
        // Microsoft (R) Test Execution Command Line Tool Version 16.3.0
        // Copyright (c) Microsoft Corporation.  All rights reserved.
        //
        // Starting test execution, please wait...
        //
        // A total of 1 test files matched the specified pattern.
        //
        //
        //Test Run Successful.
        //Total tests: 6
        //     Passed: 6
        // Total time: 3.5684 Seconds

    }
}