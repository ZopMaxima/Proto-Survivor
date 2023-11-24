// TargetFinder.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 21, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// An entity component used to search for local targets.
	/// </summary>
	public class TargetFinder : MonoBehaviour
	{
		private const int BUFFER_LIMIT = 256;

		private Transform _transform;

		private static readonly Collider2D[] _hitBuffer = new Collider2D[BUFFER_LIMIT];
		private static readonly float[] _distanceBuffer = new float[BUFFER_LIMIT];

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_transform = transform;
		}

		/// <summary>
		/// Returns a target.
		/// </summary>
		public Transform GetNearest(float radius, LayerMask mask)
		{
			return GetNearest(_transform.position, radius, mask);
		}

		/// <summary>
		/// Returns a target.
		/// </summary>
		public static Transform GetNearest(Vector3 position, float radius, LayerMask mask)
		{
			Collider2D target = null;

			// Search
			float closest = float.MaxValue;
			int count = Physics2D.OverlapCircleNonAlloc(position, radius, _hitBuffer, mask.value);
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					float distance = position.DistanceSqr(_hitBuffer[i].transform.position);
					if (distance < closest)
					{
						target = _hitBuffer[i];
						closest = distance;
					}
				}
			}

			// Return
			return target != null ? target.transform : null;
		}

		/// <summary>
		/// Returns the detected target count, filling the buffer with targets.
		/// </summary>
		public int GetNearest(float radius, LayerMask mask, Transform[] buffer)
		{
			return GetNearest(_transform.position, radius, mask, buffer);
		}

		/// <summary>
		/// Returns the detected target count, filling the buffer with targets.
		/// </summary>
		public static int GetNearest(Vector3 position, float radius, LayerMask mask, Transform[] buffer)
		{
			// No space.
			if (buffer == null || buffer.Length == 0)
			{
				return 0;
			}

			// Erase the result range.
			int length = Mathf.Min(buffer.Length, _distanceBuffer.Length);
			for (int i = 0; i < length; i++)
			{
				_distanceBuffer[i] = float.MaxValue;
			}

			// Search
			int count = Physics2D.OverlapCircleNonAlloc(position, radius, _hitBuffer, mask.value);
			for (int i = 0; i < count; i++)
			{
				float distance = position.DistanceSqr(_hitBuffer[i].transform.position);
				for (int j = length - 1; j > 0; j--) // NOTE: Excludes index 0.
				{
					if (distance < _distanceBuffer[j - 1])
					{
						buffer[j] = buffer[j - 1];
						_distanceBuffer[j] = _distanceBuffer[j - 1];
					}
					else
					{
						if (distance < _distanceBuffer[j])
						{
							buffer[j] = _hitBuffer[i].transform;
							_distanceBuffer[j] = distance;
						}
						break;
					}
				}

				// Finally test index 0.
				if (distance < _distanceBuffer[0])
				{
					buffer[0] = _hitBuffer[i].transform;
					_distanceBuffer[0] = distance;
				}
			}

			// Return
			Array.Clear(_hitBuffer, 0, count);
			return count;
		}
	}
}