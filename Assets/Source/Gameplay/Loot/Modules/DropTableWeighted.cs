// DropTableWeighted.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Drop a random item from this table.
	/// </summary>
	[CreateAssetMenu(fileName = "[Drop Table] Weighted", menuName = "Zop/DropTables/Weighted", order = 50)]
	public class DropTableWeighted : DropTable
	{
		/// <summary>
		/// The relative chance that this item drops.
		/// </summary>
		[Serializable]
		public class DropWeight
		{
			public GameObject Drop;
			public float Weight;
		}

		[SerializeField] private DropWeight[] _drops;

		private float _weightTotal;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void OnEnable()
		{
			_weightTotal = 0;
			for (int i = 0; i < _drops.Length; i++)
			{
				_weightTotal += _drops[i].Weight;
			}
		}

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
			float roll = UnityEngine.Random.value * _weightTotal;
			for (int i = 0; i < _drops.Length; i++)
			{
				if (roll <= _drops[i].Weight)
				{
					lootBuffer.Add(_drops[i].Drop);
					break;
				}
				else
				{
					roll -= _drops[i].Weight;
				}
			}

			// Return
			return lootBuffer;
		}
	}
}