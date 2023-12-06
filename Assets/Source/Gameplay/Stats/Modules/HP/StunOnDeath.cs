// StunOnDeath.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 3, 2023

using UnityEngine;
using Zop.Demo;

namespace Zop.Gameplay
{
	/// <summary>
	/// Stun an entity on death.
	/// </summary>
	public class StunOnDeath : MonoBehaviour
	{
		[DefaultFieldError]
		public DemoCharacterController Controller; // TODO: Non-demo controllers.

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
				_hp.AddOnRevive(OnRevive);
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
				_hp.RemoveOnRevive(OnRevive);
			}
		}

		/// <summary>
		/// Apply death effects.
		/// </summary>
		public void OnDeath(IHealth hp, IAttack attack)
		{
			if (Controller != null)
			{
				Controller.IsStunned = true;
			}
		}

		/// <summary>
		/// Revert death effects.
		/// </summary>
		private void OnRevive(IHealth hp, IAttack attack)
		{
			if (Controller != null)
			{
				Controller.IsStunned = false;
			}
		}
	}
}