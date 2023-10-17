// DemoWeaponOrbiter.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using System.Collections.Generic;
using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A weapon that rotates around its entity.
	/// </summary>
	public class DemoWeaponOrbiter : MonoBehaviour
	{
		public GameObject Projectile;
		public int ProjectileCount = 1;
		public float Range = 5.0f;
		public float Velocity = 10.0f;

		private Transform _transform;
		private List<Transform> _projectiles = new List<Transform>();

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_transform = transform;
			SetCount(ProjectileCount);
		}

		/// <summary>
		/// Adjust the projectile count of this weapon.
		/// </summary>
		private void SetCount(int count)
		{
			// Destroy excess projectiles.
			for (int i = _projectiles.Count - 1; i >= count && i >= 0; i++)
			{
				Transform t = _projectiles[i];
				_projectiles.RemoveAt(i);
				GameObject.Destroy(t.gameObject);
			}

			// Instantiate missing projectiles.
			if (Projectile != null)
			{
				for (int i = _projectiles.Count; i < count; i++)
				{
					GameObject instance = GameObject.Instantiate(Projectile, transform.position, Quaternion.identity);
					if (!instance.activeSelf)
					{
						instance.SetActive(true);
					}
					_projectiles.Add(instance.transform);

					// TODO: Physics orbit.
					//DemoCharacterController controller = instance.GetComponentInChildren<DemoCharacterController>();
					//if (controller != null)
					//{
					//	_projectiles.Add(controller);
					//}
					//else
					//{
					//	Debug.LogError($"Projectile instance '{instance.name}' does not have a {typeof(DemoCharacterController).Name}.");
					//	GameObject.Destroy(instance);
					//}
				}
			}
		}

		/// <summary>
		/// Orbit each projectile.
		/// </summary>
		public void Update()
		{
			if (ProjectileCount != _projectiles.Count)
			{
				SetCount(ProjectileCount);
			}

			// Orbit
			float circumference = Mathf.PI * Range * 2;
			float duration = circumference / Velocity;
			float progress = (Time.timeSinceLevelLoad % duration) / duration;
			float fraction = 360.0f / ProjectileCount;
			for (int i = _projectiles.Count - 1; i >= 0; i--)
			{
				Transform t = _projectiles[i];
				if (t == null)
				{
					_projectiles.RemoveAt(i);
					continue;
				}

				// Apply
				float rads = Mathf.Deg2Rad * ((i * fraction) + (360.0f * progress));
				t.position = _transform.position + (Quaternion.LookRotation(Vector3.forward, new Vector3(Mathf.Cos(rads), Mathf.Sin(rads), 0.0f)) * new Vector3(Range, 0, 0));

				// TODO: Physics orbit.
				//DemoCharacterController controller = _projectiles[i];
				//if (controller == null)
				//{
				//	continue;
				//}

				//float rads = Mathf.Deg2Rad * ((i * fraction) + (360.0f * progress));
				//Vector3 position = _transform.position + (Quaternion.LookRotation(Vector3.forward, new Vector3(Mathf.Cos(rads), Mathf.Sin(rads), 0.0f)) * new Vector3(Range, 0, 0));
				//float targetDistance = Vector3.Distance(position, controller.Position);
				//float stoppingDistance = controller.Velocity.sqrMagnitude / (controller.ForceAccel * 2);
				//if (targetDistance > stoppingDistance)
				//{
				//	controller.Input = position - controller.Position;
				//}
				//else
				//{
				//	controller.Input = (position - controller.Position) * (targetDistance / stoppingDistance);
				//}
			}
		}
	}
}