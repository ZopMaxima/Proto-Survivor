// LootableXP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Lootable experience points.
	/// </summary>
	public class LootableXP : LootableComponent
	{
		public int XP = 1;

		/// <summary>
		/// Apply this loot to the looter.
		/// </summary>
		public override void Loot(GameObject looter)
		{
			looter.GetEntityComponents(out IExperience xp);
			if (xp != null)
			{
				xp.AddXP(XP);
			}
		}
	}
}