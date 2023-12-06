// KillOnTimer.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 3, 2022

using System.Collections;
using UnityEngine;

namespace Zop.Gameplay
{
	/// <summary>
	/// Kill this entity after a timer expires.
	/// </summary>
	public class KillOnTimer : MonoBehaviour
	{
		public float Time = 10.0f;

		private Coroutine _routine;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Start()
		{
			this.GetEntityComponents(out IHealth hp);
			if (hp != null)
			{
				_routine = StartCoroutine(Kill(hp, Time));
			}
		}

		/// <summary>
		/// Terminate.
		/// </summary>
		private void OnDestroy()
		{
			if (_routine != null)
			{
				StopCoroutine(_routine);
				_routine = null;
			}
		}

		/// <summary>
		/// Kill the entity.
		/// </summary>
		private IEnumerator Kill(IHealth hp, float time)
		{
			yield return WaitForSecondsCache.Get(time);
			if (hp != null)
			{
				hp.ApplyAttack(new Attack(null, hp.HP));
			}
		}
	}
}