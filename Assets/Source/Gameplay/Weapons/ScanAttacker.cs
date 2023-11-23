// ScanAttacker.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using UnityEngine;
using Zop.Demo;

namespace Zop
{
	/// <summary>
	/// Issue attacks at the nearest target.
	/// </summary>
	public class ScanAttacker : MonoBehaviour
	{
		public GameObject Effect;
		public EntityWeapon Weapon;
		public TargetFinder Finder;
		public LayerMask TargetLayer;
		public float TargetRange = 3.0f;

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
		/// Auto-fire on the nearest target.
		/// </summary>
		public void FixedUpdate()
		{
			// Countdown
			_timer.Update(Time.deltaTime);
			if (!_timer.IsReady)
			{
				return;
			}

			// Search for closest target.
			Transform target = Finder.GetNearest(TargetRange, TargetLayer);

			// Fire
			if (target != null && Effect != null)
			{
				Vector2 direction = target.position - _transform.position;
				GameObject instance = GameObjectUtil.InstantiateInactive(Effect, _transform.position, Quaternion.LookRotation(Vector3.forward, direction));

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