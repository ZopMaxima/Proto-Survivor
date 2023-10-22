// LootableHP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Lootable health points.
	/// </summary>
	public class LootableHP : LootableComponent
	{
		public int HP = 1;

		/// <summary>
		/// Apply this loot to the looter.
		/// </summary>
		public override void Loot(GameObject looter)
		{
			DemoHP hp = looter.GetComponentInChildren<DemoHP>();
			if (hp != null)
			{
				hp.HP += HP;
			}
		}
	}
}