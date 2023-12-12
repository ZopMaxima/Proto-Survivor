// LootCollector.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Collect nearby loot.
	/// </summary>
	public class LootCollector : MonoBehaviour
	{
		public LayerMask TargetLayer;
		public float TargetRange = 5.0f;

		private Transform _transform;
		private readonly List<Transform> _activeLoot = new List<Transform>();

		private static readonly Collider2D[] _hitBuffer = new Collider2D[256];

		/// <summary>
		/// Initialize.
		/// </summary>
		public void Awake()
		{
			_transform = transform;
		}

		/// <summary>
		/// Search for loot.
		/// </summary>
		private void FixedUpdate()
		{
			int count = Physics2D.OverlapCircleNonAlloc(_transform.position, TargetRange, _hitBuffer, TargetLayer.value);
			for (int i = 0; i < count; i++)
			{
				Collider2D hit = _hitBuffer[i];
				_activeLoot.Add(hit.attachedRigidbody != null ? hit.attachedRigidbody.transform : hit.transform);

				// Disable from future detection.
				hit.enabled = false;
			}
		}

		/// <summary>
		/// Collect loot.
		/// </summary>
		private void Update()
		{
			for (int i = _activeLoot.Count - 1; i >= 0; i--)
			{
				Transform t = _activeLoot[i];
				float distance = Vector3.Distance(_transform.position, t.position);
				if (distance < 1)
				{
					// Loot
					ILootable[] lootables = t.gameObject.GetComponentsInChildren<ILootable>();
					for (int j = 0; j < lootables.Length; j++)
					{
						try
						{
							lootables[j].Loot(gameObject);
						}
						catch (Exception e)
						{
							Debug.LogException(e);
						}
					}

					// Destroy
					GameObject.Destroy(t.gameObject);
					_activeLoot.RemoveAt(i);
				}
				else
				{
					t.position += (_transform.position - t.position) * 0.2f; // TODO: Cache loot progress, make an accelerating lerp.
				}
			}
		}
	}
}