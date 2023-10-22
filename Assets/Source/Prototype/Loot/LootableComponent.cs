// LootableComponent.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// An abstract loot component.
	/// </summary>
	public abstract class LootableComponent : MonoBehaviour, ILootable
	{
		/// <summary>
		/// Apply this loot to the looter.
		/// </summary>
		public abstract void Loot(GameObject looter);
	}
}