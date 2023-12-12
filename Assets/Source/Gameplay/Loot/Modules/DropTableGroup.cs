// DropTableGroup.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 12, 2023

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Drop a random item from each table.
	/// </summary>
	[CreateAssetMenu(fileName = "[Drop Table] Group", menuName = "Zop/DropTables/Group", order = 50)]
	public class DropTableGroup : DropTable
	{
		[SerializeField] public DropTable[] _dropTables;

		/// <summary>
		/// Select a variable number of loot objects to drop.
		/// </summary>
		public override List<GameObject> Roll(GameObject dropper, List<GameObject> lootBuffer)
		{
			// Roll
			for (int i = 0; i < _dropTables.Length; i++)
			{
				if (_dropTables[i] != null)
				{
					try
					{
						lootBuffer = _dropTables[i].Roll(dropper, lootBuffer);
					}
					catch (Exception e)
					{
						Debug.LogException(e);
					}
				}
			}

			// Return
			return lootBuffer;
		}
	}
}