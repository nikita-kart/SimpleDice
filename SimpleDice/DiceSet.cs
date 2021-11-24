using System;

namespace SimpleDice
{
	/// <summary>
	/// A simple class to handle NdM sets of dices
	/// </summary>
	public class DiceSet
	{
		private Random random;

		/// <summary>
		/// Number of dices in this dice set
		/// </summary>
		public int Count { get; private set; }
		/// <summary>
		/// Number of sides of each dice in this dice set
		/// </summary>
		public int Sides { get; private set; }

		/// <summary>
		/// Minimum possible outcome
		/// </summary>
		public int Min { get { return Count; } }
		/// <summary>
		/// Maximum possible outcome
		/// </summary>
		public int Max { get { return Count * Sides; } }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_count">Number of dices in this set. Must be 1 or greater</param>
		/// <param name="_sides">Number of sides each dice have. Must be 2 or greater</param>
		public DiceSet(int _count = 1, int _sides = 6)
		{
			ChangeSet(_count, _sides);
			random = new Random();
		}

		/// <summary>
		/// Change count of dices in this set and number of their sides
		/// </summary>
		/// <param name="_count">Number of dices in this set. Must be 1 or greater</param>
		/// <param name="_sides">Number of sides each dice have. Must be 2 or greater</param>
		public void ChangeSet(int _count, int _sides)
		{
			if (_count < 1)
				_count = 1;
			if (_sides < 2)
				_sides = 0;

			Count = _count;
			Sides = _sides;
		}

		/// <summary>
		/// Converts this dice set into its string representation for purposes like displaying in interface
		/// </summary>
		/// <param name="separator">Separator symbol or string between dice count and number of sides</param>
		/// <returns>A string representation of this dice set</returns>
		public string ToString(string separator = "d")
		{
			return $"{Count}{separator}{Sides}";
		}

		/// <summary>
		/// Returns average result of rolling this dices, rounded down (default) or up if number is not integer
		/// </summary>
		/// <param name="roundUp">Is result must be rounded up?</param>
		/// <returns>An average result of rolling this dice set</returns>
		public int Average(bool roundUp = false)
		{
			float average = ((float)(Sides + 1) / 2) * Count;
			if (roundUp)
				return (int)Math.Ceiling(average);
			return (int)Math.Floor(average);
		}

		/// <summary>
		/// Roll the dices
		/// </summary>
		/// <returns>Result of a roll</returns>
		public int Roll()
		{
			int result = 0;
			for (int i = 0; i < Count; i++)
			{
				result+= random.Next(1, Sides + 1);
			}
			return result;
		}

		/// <summary>
		/// Roll the dices and get each dice roll result
		/// </summary>
		/// <param name="rollsArray">Integer array which will contain individual roll results of each dice</param>
		/// <returns>Result of a roll</returns>
		public int Roll(out int[] rollsArray)
		{
			rollsArray = new int[Count];
			int result = 0;
			for (int i =0; i < Count; i++)
			{
				int roll = random.Next(1, Sides + 1);
				result += roll;
				rollsArray[i] = roll;
			}
			return result;
		}

		/// <summary>
		/// Static method to roll any dice set
		/// </summary>
		/// <param name="diceSet">A dice set to roll</param>
		/// <returns>Result of a dice set roll</returns>
		public static int Roll(DiceSet diceSet)
		{
			return diceSet.Roll();
		}

		/// <summary>
		/// Static method to roll any dice set and get each dice roll result
		/// </summary>
		/// <param name="diceSet">A dice set to roll</param>
		/// <param name="rollsArray">Integer array which will contain individual roll results of each dice</param>
		/// <returns>Result of a dice set roll</returns>
		public static int Roll(DiceSet diceSet, out int[] rollsArray)
		{
			return diceSet.Roll(out rollsArray);
		}
	}
}
