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
		/// Number of faces of each dice in this dice set
		/// </summary>
		public int Faces { get; private set; }

		/// <summary>
		/// Minimum possible outcome
		/// </summary>
		public int Min { get { return Count; } }
		/// <summary>
		/// Maximum possible outcome
		/// </summary>
		public int Max { get { return Count * Faces; } }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_count">Number of dices in this set. Must be 1 or greater</param>
		/// <param name="faces">Number of faces each dice have. Must be 2 or greater</param>
		public DiceSet(int _count = 1, int faces = 6)
		{
			ChangeSet(_count, faces);
			random = new Random();
		}

		/// <summary>
		/// Change count of dices in this set and number of their sides
		/// </summary>
		/// <param name="_count">Number of dices in this set. Must be 1 or greater</param>
		/// <param name="_faces">Number of faces each dice have. Must be 2 or greater</param>
		public void ChangeSet(int _count, int _faces)
		{
			if (_count < 1)
				_count = 1;
			if (_faces < 2)
				_faces = 0;

			Count = _count;
			Faces = _faces;
		}

		/// <summary>
		/// Converts this dice set into its string representation for purposes like displaying in interface
		/// </summary>
		/// <param name="separator">Separator symbol or string between dice count and number of faces</param>
		/// <returns>A string representation of this dice set</returns>
		public string ToString(string separator = "d")
		{
			return $"{Count}{separator}{Faces}";
		}

		/// <summary>
		/// Returns average result of rolling this dices, rounded down (default) or up if number is not integer
		/// </summary>
		/// <param name="roundUp">Is result must be rounded up?</param>
		/// <returns>An average result of rolling this dice set</returns>
		public int Average(bool roundUp = false)
		{
			float average = ((float)(Faces + 1) / 2) * Count;
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
				result+= random.Next(1, Faces + 1);
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
				int roll = random.Next(1, Faces + 1);
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

		/// <summary>
		/// Static method to roll a number of dices with seted number of faces
		/// </summary>
		/// <param name="_count">>Number of dices to roll. Must be 1 or greater</param>
		/// <param name="_faces">Number of faces of each dice. Must be 2 or greater</param>
		/// <returns>Result of a roll</returns>
		public static int Roll(int _count, int _faces)
		{
			DiceSet diceSet = new DiceSet(_count, _faces);
			return diceSet.Roll();
		}

		/// <summary>
		/// Static method to roll a number of dices with seted number of faces and get each dice roll result
		/// </summary>
		/// <param name="_count">Number of dices to roll. Must be 1 or greater</param>
		/// <param name="_faces">Number of faces of each dice. Must be 2 or greater</param>
		/// <param name="rollsArray">Integer array which will contain individual roll results of each dice</param>
		/// <returns>Result of a roll</returns>
		public static int Roll(int _count, int _faces, out int[] rollsArray)
		{
			DiceSet diceSet = new DiceSet(_count, _faces);
			return diceSet.Roll(out rollsArray);
		}
	}
}
