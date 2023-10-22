// DemoLootOnDeath.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Drop loot when this entity dies.
	/// </summary>
	public class DemoLootOnDeath : MonoBehaviour
	{
		public GameObject Loot;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Start()
		{
			DemoHP hp = GetComponentInChildren<DemoHP>();
			if (hp != null)
			{
				hp.OnDeath += OnDeath;
			}
		}

		/// <summary>
		/// Spawn loot.
		/// </summary>
		public void OnDeath(DemoHP hp)
		{
			if (Loot != null)
			{
				GameObject.Instantiate(Loot, transform.position, transform.rotation);
			}
		}
	}
}