using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSC_455_As._2 {
	public class MyFunctions {
		public static string PrintMenu () {
			// want to make/print the menu with this function
			// menu of other options given

			return "1: Random number 1-10.\n" +
				"2: Today's date.\n" +
				"3: List of dinosaurs.\n" +
				"4: String class methods.\n";
		}
		public static int RandomNum (int max) {
			if (max < 0) { // this is hard coded, so should never happen.
				Console.WriteLine("Please use a positive number.\n");
				return -1;
			}
			// mostly for practice and organization purposes

			Random rand = new Random();

			return rand.Next(max) + 1;
		}
		public static void PrintDate () {
			// print today's date in MM-DD-YYYY format
			// this is my preferred method of printing the date

			Console.WriteLine($"{DateTime.Now.ToString("MM-dd-yyyy")}");
		}
		public static List<string> DinoLister () {
			Console.WriteLine("Please give me at least 10 Dinosaur names. Write <done> to finish:\n");

			// create list, temporary string, and counter for the user
			List<string> dinos = new List<string>();
			int counter = 1;
			string locum = string.Empty;

			// thoroughness for the people -_-
			while (locum != "done" && locum != "Done" && locum != "<done>" && locum != "<Done>") {
				looper:
				Console.WriteLine($"{counter}: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
				locum = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

				//make sure they give 10
				if ((locum == "done" || locum == "Done" || locum == "<done>" || locum == "<Done>") && counter < 11) {
					Console.WriteLine("Please complete the list.\n");
					goto looper;
				}
#pragma warning disable CS8604 // Possible null reference argument.
				dinos.Add(locum);
#pragma warning restore CS8604 // Possible null reference argument.
				counter++;
			}
			Console.WriteLine("\n");

			var sortedDinos = dinos.OrderBy(dino => dino).ToList();

			return dinos;
		}
		public static void ClassFun () {
			// doing stuff with strings, so lets input one
			Console.WriteLine("Please input a string:\n");
			reader:
			var given = Console.ReadLine();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
			if (given.Length < 4) {
				Console.WriteLine("Please give a bigger string:\n");
				goto reader;
			}
#pragma warning restore CS8602 // Dereference of a possibly null reference.

			int chooser = RandomNum(10); // random 1-10

			switch (chooser) {
				case 1:
					Console.WriteLine($"Substring: {given.Substring(1, given.Length - 2)}");
					break;
				case 2:
					Console.WriteLine($"Reverse: {given.Reverse()}");
					break;
				case 3:
					Console.WriteLine($"Length: {given.Length}");
					break;
				case 4:
					Console.WriteLine($"UpperCase: {given.ToUpper()}");
					break;
				case 5:
					Console.WriteLine($"StartsWith: {given[0]}");
					break;
				case 6:
					Console.WriteLine($"EndsWith: {given[given.Length - 1]}");
					break;
				case 7:
					Console.WriteLine($"Replaced s-z: {given.Replace("s", "z")}");
					break;
				case 8:
					Console.WriteLine($"Split: {given.Substring(0, (given.Length - 1) / 2)}\n" +
						$"{given.Substring((given.Length / 2) + 1, given.Length - 1)}");
					break;
				case 9:
					Console.WriteLine($"Trimmed; {given.Trim()}");
					break;
				case 10:
					Console.WriteLine($"LowerCase: {given.ToLower()}");
					break;
				default: // if somehow, we get a number outside of 1-10. Error code 2
					Console.WriteLine("Internal Error.\nCode: 2");
					break;
			}
		}
	}
	internal class Program {
		static void Main (string[] args) {
			Console.WriteLine(MyFunctions.PrintMenu()); // print 
			
			try {
				int choice = 0;
				var locum = Console.ReadLine();
				if (int.TryParse(locum, out int id)) {
					choice = int.Parse(locum); // fully handled.
				}
				else {
					Console.WriteLine("Please write one of the given numbers.\n");
				}
				if (choice != 1 && choice != 2 && choice != 3 && choice != 4) {
					Console.WriteLine("Please write one of the given numbers.\n");
				}
				switch (choice) {
					case 1: // print the random number
						Console.WriteLine($"{MyFunctions.RandomNum(10)}\n");
						Console.ReadLine();
						break;
					case 2: // today's date
						MyFunctions.PrintDate();
						Console.ReadLine();
						break;
					case 3: // dinosaur list
						List<string> sortedDinos = MyFunctions.DinoLister();
						int counter = MyFunctions.RandomNum(sortedDinos.Count) - 1;
						if (counter < 1) {
							Console.WriteLine("Error with RandomNum: negative maximum");
						}
						Console.WriteLine($"{sortedDinos[counter]}\n");
						Console.ReadLine();
						break;
					case 4: // string class
						MyFunctions.ClassFun();
						Console.ReadLine();
						break;
					default: // if the choice was not valid
						Console.WriteLine("Invalid choice.\n");
						Console.ReadLine ();
						break;
				}
			}
			catch (Exception e) {
				Console.Error.WriteLine("Error Code 1: " + e.Message + "\n");
				Console.ReadLine();
			}
		}
	}
}
