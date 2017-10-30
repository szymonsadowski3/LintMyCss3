using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LintMyCss3.MyClasses;
using System.Collections.Generic;
using System.Linq;

namespace LintMyCss3.Tests
{
    [TestClass]
    public class ImportanceCheckerTest
    {
        ExpressionChecker importanceChecker { get; set; }

        [TestInitialize()]
        public void Initialize() {
            importanceChecker = new ExpressionChecker("!important", WarningType.DisallowImportant);
        }

        [TestMethod]
        public void TestEmptyImportance()
        {
            var actualOutput = this.importanceChecker.GetWarnings("Abc");
            Assert.IsFalse(actualOutput.Any());
        }

        [TestMethod]
        public void TestBasicImportance()
        {
            var actualOutput = this.importanceChecker.GetWarnings("!important").First();
            var expectedOutput = new Warning(WarningType.DisallowImportant, 1, 0, "_");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestMultiLineImportance()
        {
            string cssSelector = @"body{
color: white !important}";
            var actualOutput = this.importanceChecker.GetWarnings(cssSelector).First();
            var expectedOutput = new Warning(WarningType.DisallowImportant, 14, 1, "_");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestOneLineMultipleDirectives()
        {
            string cssSelector = "body{color: white !important, font-weight: 700 !important}";
            var actualOutput = this.importanceChecker.GetWarnings(cssSelector);
            var expectedOutput = new List<Warning>();
            expectedOutput.Add(new Warning(WarningType.DisallowImportant, 19, 0, "_"));
            expectedOutput.Add(new Warning(WarningType.DisallowImportant, 48, 0, "_"));
            Assert.IsTrue(actualOutput.SequenceEqual(expectedOutput));
        }

        [TestMethod]
        public void TestOneLineThreeDirectives()
        {
            string cssSelector = "body{color: white !important, font-weight: 700 !important, font-size: 100px !important}";
            var actualOutput = this.importanceChecker.GetWarnings(cssSelector);
            var expectedOutput = new List<Warning>();
            expectedOutput.Add(new Warning(WarningType.DisallowImportant, 19, 0, "_"));
            expectedOutput.Add(new Warning(WarningType.DisallowImportant, 48, 0, "_"));
            expectedOutput.Add(new Warning(WarningType.DisallowImportant, 77, 0, "_"));
            Assert.IsTrue(actualOutput.SequenceEqual(expectedOutput));
        }
    }
}
