// AutoAttacker.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Issue directionless attacks as soon as possible.
	/// </summary>
	public class AutoAttacker : MonoBehaviour
	{
		public GameObject Effect;
		public EntityWeapon Weapon;

		private Transform _transform;
		private CooldownTimer _timer;

		/// <summary>
		/// Initialize.
		/// </summary>
		public void Awake()
		{
			_transform = transform;
			_timer = new CooldownTimer();
		}

		/// <summary>
		/// Reset on enable.
		/// </summary>
		public void OnEnable()
		{
			_timer.StartCooldown(Weapon != null ? Weapon.AttackFrequency : 0);
		}

		/// <summary>
		/// Auto-fire on cooldown.
		/// </summary>
		public void FixedUpdate()
		{
			// Countdown
			_timer.Update(Time.deltaTime);
			if (!_timer.IsReady)
			{
				return;
			}

			// Fire
			if (Effect != null && Weapon != null)
			{
				GameObject instance = GameObjectUtil.InstantiateInactive(Effect, _transform.position, _transform.rotation);

				// Pass attack data to the instance.
				EntityAttack attack = instance.GetComponent<EntityAttack>();
				if (attack != null)
				{
					attack.InternalAttack = Weapon.Attack();
				}

				// Re-activate
				if (!instance.activeSelf)
				{
					instance.SetActive(true);
				}

				// Start a new cooldown.
				_timer.StartCooldown(Weapon.AttackFrequency);
			}
		}
	}
}