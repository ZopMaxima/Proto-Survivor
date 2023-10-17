// DemoSpawner.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Spawn entities at a fixed rate.
	/// </summary>
	public class DemoSpawner : MonoBehaviour
	{
		public GameObject Entity;
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
		/// Spawn on cooldown.
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

			// Spawn
			if (Entity != null)
			{
				GameObject instance = GameObject.Instantiate(Entity, transform.position, Quaternion.identity);
				if (!instance.activeSelf)
				{
					instance.SetActive(true);
				}
			}

			// Keep overflowed cooldown progress.
			_timer += Cooldown;
		}
	}
}