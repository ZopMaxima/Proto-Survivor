// StatCalculation.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 26, 2023

namespace Zop
{
	/// <summary>
	/// A selectable stage of stat calculation.
	/// </summary>
	public enum StatCalculation
	{
		None = 0,
		AdditiveValue,
		AdditiveMultiplier,
		CompoundMultiplier,
	}
}