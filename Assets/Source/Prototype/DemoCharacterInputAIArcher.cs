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
		public float ApproachRange = 10.0f;

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
				float distance = Mathf.Max(0, ApproachRange);
				Vector3 position = _target.position + ((_transform.position - _target.position).normalized * distance);
				_controller.Input = position - _transform.position;
			}
		}
	}
}