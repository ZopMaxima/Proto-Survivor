// ILootable.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// An invokable loot effect.
	/// </summary>
	public interface ILootable
	{
		/// <summary>
		/// Apply this loot to the looter.
		/// </summary>
		void Loot(GameObject looter);
	}
}