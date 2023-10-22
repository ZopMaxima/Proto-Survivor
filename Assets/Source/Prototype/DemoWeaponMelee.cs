// DemoWeaponMelee.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 20, 2023

using System.Collections.Generic;
using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A weapon that fires at a fixed rate.
	/// </summary>
	public class DemoWeaponMelee : MonoBehaviour
	{
		public GameObject Effect;
		public LayerMask TargetLayer;
		public float TargetRange = 3.0f;
		public float Cooldown = 1.0f;

		private Transform _transform;
		private float _timer;
		private readonly List<GameObject> _instances = new List<GameObject>();

		private static readonly Collider2D[] _hitBuffer = new Collider2D[256];

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Start()
		{
			_transform = transform;
		}

		/// <summary>
		/// Auto-fire on the nearest target.
		/// </summary>
		public void FixedUpdate()
		{
			// Follow this transform with each instance.
			for (int i = _instances.Count - 1; i >= 0; i--)
			{
				if (_instances[i] == null)
				{
					_instances.RemoveAt(i);
				}
				else
				{
					_instances[i].transform.position = _transform.position;
				}
			}

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
			int count = Physics2D.OverlapCircleNonAlloc(_transform.position, TargetRange, _hitBuffer, TargetLayer.value);
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					float distance = Vector2.Distance(_transform.position, _hitBuffer[i].transform.position); // TODO: Compare while square.
					if (distance < closest)
					{
						target = _hitBuffer[i];
						closest = distance;
					}
				}
			}

			// Fire
			if (target != null && Effect != null)
			{
				Vector2 direction = target.transform.position - _transform.position;
				GameObject instance = GameObject.Instantiate(Effect, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
				if (!instance.activeSelf)
				{
					instance.SetActive(true);
				}
				_instances.Add(instance);

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