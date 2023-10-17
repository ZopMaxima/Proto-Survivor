// DemoWeaponProjectile.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A weapon that fires at a fixed rate.
	/// </summary>
	public class DemoWeaponProjectile : MonoBehaviour
	{
		private static readonly Collider2D[] hitBuffer = new Collider2D[256];

		public GameObject Projectile;
		public float Velocity = 10.0f;
		public LayerMask TargetLayer;
		public float TargetRange = 20.0f;
		public float Cooldown = 1.0f;

		private Transform _transform;
		private float _timer;

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_transform = transform;
		}

		/// <summary>
		/// Auto-fire on the nearest target.
		/// </summary>
		public void Update()
		{
			// Countdown
			if (_timer > 0)
			{
				_timer -= Time.deltaTime;
				if (_timer > 0)
				{
					return;
				}
			}

			// Search for closest target.
			Collider2D target = null;
			float closest = float.MaxValue;
			int count = Physics2D.OverlapCircleNonAlloc(_transform.position, TargetRange, hitBuffer, TargetLayer.value);
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					float distance = Vector2.Distance(_transform.position, hitBuffer[i].transform.position); // TODO: Compare while square.
					if (distance < closest)
					{
						target = hitBuffer[i];
						closest = distance;
					}
				}
			}

			// Fire
			if (target != null && Projectile != null)
			{
				Vector2 direction = target.transform.position - _transform.position;
				GameObject instance = GameObject.Instantiate(Projectile, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
				if (!instance.activeSelf)
				{
					instance.SetActive(true);
				}
				Rigidbody2D r = instance.GetComponentInChildren<Rigidbody2D>();
				if (r != null)
				{
					r.AddForce(direction * Velocity * r.mass, ForceMode2D.Impulse);
				}

				// Keep overflowed cooldown progress.
				_timer += Cooldown;
			}
			else
			{
				// Nothing to fire at.
				_timer = 0;
			}
		}
	}
}