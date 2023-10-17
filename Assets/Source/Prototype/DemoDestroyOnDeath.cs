// DemoDestroyOnDeath.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Destroy an entity on death.
	/// </summary>
	public class DemoDestroyOnDeath : MonoBehaviour
	{
		public GameObject Effect;

		/// <summary>
		/// Initialzie.
		/// </summary>
		public void Awake()
		{
			DemoHP hp = GetComponent<DemoHP>();
			if (hp != null)
			{
				hp.OnDeath += OnDeath;
			}
		}

		/// <summary>
		/// Apply death effects.
		/// </summary>
		public void OnDeath(DemoHP hp)
		{
			if (Effect != null)
			{
				GameObject.Instantiate(Effect, transform.position, transform.rotation);
			}
			GameObject.Destroy(gameObject);
		}
	}
}