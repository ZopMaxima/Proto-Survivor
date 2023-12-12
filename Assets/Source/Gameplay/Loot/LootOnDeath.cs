// LootOnDeath.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Drop loot when this entity dies.
	/// </summary>
	public class LootOnDeath : MonoBehaviour
	{
		public GameObject Loot;

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
			if (Loot != null)
			{
				GameObject.Instantiate(Loot, transform.position, transform.rotation);
			}
		}
	}
}