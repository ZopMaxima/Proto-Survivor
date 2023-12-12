// DropTableBasic.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Drop a random item from this table.
	/// </summary>
	[CreateAssetMenu(fileName = "[Drop Table] Basic", menuName = "Zop/DropTables/Basic", order = 50)]
	public class DropTableBasic : DropTable
	{
		[SerializeField] private GameObject[] _drops;

		/// <summary>
		/// Select a variable number of loot objects to drop.
		/// </summary>
		public override List<GameObject> Roll(GameObject dropper, List<GameObject> lootBuffer)
		{
			// Nothing to drop.
			if (_drops == null || _drops.Length == 0)
			{
				return null;
			}

			// Roll
			if (lootBuffer == null)
			{
				lootBuffer = new List<GameObject>();
			}
			int index = Random.Range(0, _drops.Length);
			lootBuffer.Add(_drops[index]);

			// Return
			return lootBuffer;
		}
	}
}