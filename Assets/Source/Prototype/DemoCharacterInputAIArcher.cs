// DemoCharacterInputAIArcher.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo character input AI.
	/// </summary>
	public class DemoCharacterInputAIArcher : DemoCharacterInputAI
	{
		public float PercentWeaponRange = 0.5f;

		private DemoWeaponProjectile _weapon;

		/// <summary>
		/// Initialize.
		/// </summary>
		public override void Awake()
		{
			base.Awake();
			_weapon = GetComponentInChildren<DemoWeaponProjectile>();
		}

		/// <summary>
		/// Poll input.
		/// </summary>
		public override void Update()
		{
			// Search for a player.
			if (_target == null)
			{
				_target = DemoTargetPlayer.Instance?.transform;
			}

			// Advance to weapon range.
			if (_controller != null && _target != null)
			{
				float distance = Mathf.Max(0, _weapon.TargetRange * PercentWeaponRange);
				Vector3 position = _target.position + ((_transform.position - _target.position).normalized * distance);
				_controller.Input = position - _transform.position;
			}
		}
	}
}