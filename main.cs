using System;
using ElementType = System.Int32;
using System.Text;

namespace MazeGenerator{

	class MainApp{

		public static void Main(){
			MazeGenerator mg = new MazeGenerator();
			int input = 0;

			while(input != 4){
				switch (input = PrintMenu())
				{
					case 1:
						mg.GenerateMaze();
						break;
					case 2:
						mg.PrintMaze();
						Console.WriteLine("\nPress any key...");
						Console.ReadLine();
						break;
					case 3:
						SettingMaze(mg);
						break;
					case 4:
						Console.WriteLine("Exit.");
						break;
					default:
						Console.WriteLine("Error: Wrong Input!");
						break;
				}
			}

		}

		static int PrintMenu(){
			Console.WriteLine("\n--- Maze Generator ---");
			Console.WriteLine("1. Generate Maze");
			Console.WriteLine("2. Print Maze");
			Console.WriteLine("3. Setting");
			Console.WriteLine("4. Exit");
			Console.Write("\nInput: ");

			string input = Console.ReadLine();
			return Convert.ToInt32(input);
		}

		static void SettingMaze(MazeGenerator mg){
			Console.WriteLine("--- Setting ---");
			Console.WriteLine("The number of row");
			Console.Write("Input: ");
			string input = Console.ReadLine();
			int row = Convert.ToInt32(input);

			Console.WriteLine("\nThe number of column");
			Console.Write("Input: ");
			input = Console.ReadLine();
			int col = Convert.ToInt32(input);

			mg.Init(row, col);
		}
	}
}
