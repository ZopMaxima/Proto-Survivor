// StatCascade.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 25, 2023

namespace Zop
{
	/// <summary>
	/// How a stat value is modified when its range changes.
	/// </summary>
	public enum StatCascade
	{
		None = 0,
		Difference,
		Percentage,
	}
}