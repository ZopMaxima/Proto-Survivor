// LootableHP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop
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
			looter.GetEntityComponents(out IHealth hp);
			if (hp != null)
			{
				hp.ApplyAttack(new Attack(null, -HP));
			}
		}
	}
}