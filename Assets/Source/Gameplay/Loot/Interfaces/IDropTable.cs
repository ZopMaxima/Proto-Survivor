// IDropTable.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 12, 2023

using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Generate flexible loot drops.
	/// </summary>
	public interface IDropTable
	{
		/// <summary>
		/// Select a variable number of loot objects to drop.
		/// </summary>
		List<GameObject> Roll(GameObject dropper, List<GameObject> lootBuffer);
	}
}