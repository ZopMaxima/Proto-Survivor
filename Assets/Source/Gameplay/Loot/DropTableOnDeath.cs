// DropTableOnDeath.cs
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
	/// Drop loot when this entity dies.
	/// </summary>
	public class DropTableOnDeath : MonoBehaviour
	{
		public DropTable Table;

		private static readonly List<GameObject> _results = new List<GameObject>();

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Start()
		{
			this.GetEntityComponents(out IHealth hp);
			if (hp != null)
			{
				hp.AddOnDeath(OnDeath);
			}
		}

		/// <summary>
		/// Spawn loot.
		/// </summary>
		public void OnDeath(IHealth hp, IAttack attack)
		{
			if (Table != null)
			{
				_results.Clear();
				Table.Roll(gameObject, _results); // TODO: Pass root object?
				for (int i = 0; i < _results.Count; i++)
				{
					if (_results[i] != null)
					{
						try
						{
							GameObject.Instantiate(_results[i], transform.position, transform.rotation);
						}
						catch (Exception e)
						{
							Debug.LogException(e);
						}
					}
				}
				_results.Clear();
			}
		}
	}
}