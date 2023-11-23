// EntityStats.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 18, 2023

namespace Zop
{
	/// <summary>
	/// Generic stats for various game entities.
	/// </summary>
	public enum EntityStats
	{
		None = 0,

		// Scaling
		Level = 1,
		XP,
		XPMax,
		Rarity,

		// Resources
		HP = 1000,
		HPMax,
		MP,
		MPMax,

		// Attributes
		Strength = 2000,
		Dexterity,
		Intellect,
	}
}