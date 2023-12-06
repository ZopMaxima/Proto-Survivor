// DestroyOnDeath.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 3, 2023

using UnityEngine;

namespace Zop.Gameplay
{
	/// <summary>
	/// Destroy an entity on death.
	/// </summary>
	public class DestroyOnDeath : MonoBehaviour
	{
		public GameObject Effect;
		public bool IgnoreRotation;

		private IHealth _hp;

		/// <summary>
		/// Initialzie.
		/// </summary>
		public void Awake()
		{
			this.GetEntityComponents(out IHealth _hp);
			if (_hp != null)
			{
				_hp.AddOnDeath(OnDeath);
			}
		}

		/// <summary>
		/// Terminate.
		/// </summary>
		public void OnDestroy()
		{
			if (_hp != null)
			{
				_hp.RemoveOnDeath(OnDeath);
			}
		}

		/// <summary>
		/// Apply death effects.
		/// </summary>
		public void OnDeath(IHealth hp, IAttack attack)
		{
			if (Effect != null)
			{
				GameObject.Instantiate(Effect, transform.position, IgnoreRotation ? Quaternion.identity : transform.rotation);
			}
			GameObject.Destroy(gameObject);
		}
	}
}