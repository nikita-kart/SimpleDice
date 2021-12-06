using System;
using SimpleDice;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			DiceSet _d20 = new DiceSet(1, 20);
			DiceSet _3d6 = new DiceSet(3, 6);
			DiceSet _10d2 = new DiceSet(10, 2);

			Console.WriteLine(_d20.ToString());
			Console.WriteLine();
			for (int i = 0; i < 5; i++)
				Console.WriteLine(_d20.Roll());
			Console.WriteLine("====================\n");

			int result;
			int[] rolls;

			Console.WriteLine(_3d6.ToString());
			Console.WriteLine();
			result = _3d6.Roll(out rolls);
			Console.WriteLine($"{result} ({string.Join(", ", rolls)})");
			Console.WriteLine(_3d6.Average() + " " + _3d6.Average(true));
			Console.WriteLine("====================\n");

			Console.WriteLine(_10d2.ToString("x"));
			Console.WriteLine();
			Console.WriteLine($"{_10d2.Min} - {_10d2.Max}");
			for (int i = 0; i < 5; i++)
				Console.WriteLine(DiceSet.Roll(10, 2));
			Console.WriteLine("====================\n");

			Console.WriteLine(DiceSet.Roll(3, 7));

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
