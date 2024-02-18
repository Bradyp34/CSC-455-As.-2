using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSC_455_As._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_455_As._2.Tests {
	[TestClass()]
	public class MyFunctionsTests {
		[TestMethod()]
		public void PrintMenuTest () {
			var actual = MyFunctions.PrintMenu();
			Assert.IsTrue(actual == "1: Random number 1-10.\n" +
				"2: Today's date.\n" +
				"3: List of dinosaurs.\n" +
				"4: String class methods.\n");
		}
	}
}