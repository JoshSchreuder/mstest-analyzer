﻿// Copyright (c) Francois Karman. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.Analyzer
{
    /// <summary>
    /// Provide a global test context in order to verify that the analyzers
    /// are working good on a 'normal' class.
    /// </summary>
    /// <remarks>
    /// This class is considered invalid and all methods should trigger a warning from
    /// the MSTest.Analyzer analyzers.
    /// </remarks>
    [TestClass]
    public class FakeInvalidTest
    {
        /// <summary>
        /// Initializes all tests within the project.
        /// </summary>
        /// <param name="context">The parameter is not used.</param>
        public static void PublicAssemblyInitialize(TestContext context)
        {
        }

        /// <summary>
        /// Clean-ups after the execution of all tests within the project.
        /// </summary>
        public static void PublicAssemblyCleanup()
        {
        }

        /// <summary>
        /// Initializes all tests within this class.
        /// </summary>
        /// <param name="context">The parameter is not used.</param>
        public static void PublicClassInitialize(TestContext context)
        {
        }

        /// <summary>
        /// Clean-ups after the execution of all tests within this class.
        /// </summary>
        public static void PublicClassCleanup()
        {
        }

        /// <summary>
        /// Called before any test within this class.
        /// </summary>
        public void PublicTestInitialize()
        {
        }

        /// <summary>
        /// Called after any test within this class.
        /// </summary>
        public void PublicTestCleanup()
        {
        }

        /// <summary>
        /// Actual test within the test class.
        /// </summary>
        public void PublicTestMethod()
        {
        }

        /// <summary>
        /// Actual test within the test class.
        /// </summary>
        [TestCategory("category")]
        public void PublicTestMethodWithCategory()
        {
        }

        /// <summary>
        /// Actual test within the test class - that use initial test data set.
        /// </summary>
        /// <param name="value">The parameter is not used.</param>
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void PublicDataTestMethod(int value)
        {
        }

        /// <summary>
        /// Wrong accessibility of the ClassInitialize.
        /// </summary>
        /// <param name="context">The parameter is not used.</param>
        [ClassInitialize]
        protected static void ProtectedClassInitialize(TestContext context)
        {
        }

        /// <summary>
        /// Wrong accessibility of the ClassCleanup.
        /// </summary>
        [ClassCleanup]
        protected static void ProtectedClassCleanup()
        {
        }

        /// <summary>
        /// Wrong accessibility of the TestInitialize.
        /// </summary>
        /// <param name="context">The parameter is not used.</param>
        [TestInitialize]
        protected void ProtectedTestInitialize(TestContext context)
        {
        }

        /// <summary>
        /// Wrong accessibility of the TestCleanup.
        /// </summary>
        [TestCleanup]
        protected void ProtectedTestCleanup()
        {
        }

        /// <summary>
        /// Wrong accessibility of the TestMethod.
        /// </summary>
        [TestMethod]
        protected void ProtectedTestMethod()
        {
        }

        /// <summary>
        /// Wrong accessibility of the DataTestMethod.
        /// </summary>
        /// <param name="value">The parameter is not used.</param>
        [DataTestMethod]
        [DataRow(1)]
        protected void ProtectedDataTestMethod(int value)
        {
        }
    }
}
