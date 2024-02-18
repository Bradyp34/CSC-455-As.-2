using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSC_455_As._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
		[TestMethod()]
		public void RandomNumTest () {
			int max = 10;
			for (int k = 0; k < 1000 * max; k++) {
				int actual = MyFunctions.RandomNum(max);
				Assert.IsTrue((actual >= 1 && actual <= max));
			}
		}
		[TestMethod()]
		public void RandomNumTestNegative () {
			int max = -1;
			int actual = MyFunctions.RandomNum(max);
			Assert.IsTrue(!(actual >= 1 && actual <= max));
		}
		[TestMethod()]
		public void PrintDateTest () {
			var actual = MyFunctions.PrintDate();
			Assert.AreEqual(actual, DateTime.Now.ToString("MM-dd-yyyy"));
		}

		[DataTestMethod]
		[DataRow("joseph")]
		[DataRow("")]
		[DataRow("&.\\||&&.")] // 3 tests. regular, empty, special chars
		public void ClassFunTest (string given) {
			var actual = MyFunctions.ClassFun(given);
			Assert.IsInstanceOfType(actual, typeof(string));
		}
		}
		[TestMethod()]
		public void DinoListerTest () {
			var input = "Dino1\nDino2\nDino3\nDino4\nDino5\nDino6\nDino7\nDino8\nDino9\nDino10\ndone";
			Console.SetIn(new StringReader(input));

			var actual = MyFunctions.DinoLister();

			Assert.IsInstanceOfType(actual, typeof(List<string>));
		}
		[TestMethod()]
		public void DinoListerFailTest() {
			var input = "\n\ndone\nDino1\nDino2\nDino3\nDino4\nDino5\nDino6\nDino7\nDino8\nDino9\nDino10\ndone\n";
			string expectedOutput = "1: Please input a name:\n1: Please input a name:\n1: Please complete the list.\n1: ";
				//i don't care about the rest of the string
			
			Console.SetIn(new StringReader(input));

			var output = new StringWriter();
			Console.SetOut(output);

			MyFunctions.DinoLister();

			var actual = MyFunctions.DinoLister();
			var consoleOutput = output.ToString();

			Assert.IsTrue(consoleOutput.StartsWith(expectedOutput));
		}
	}
}