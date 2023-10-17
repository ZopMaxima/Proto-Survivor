// DemoTargetPlayer.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Identify this target.
	/// </summary>
	public class DemoTargetPlayer : MonoBehaviour
	{
		public static DemoTargetPlayer Instance { get; private set; }

		/// <summary>
		/// Select.
		/// </summary>
		public void OnEnable()
		{
			if (Instance == null)
			{
				Instance = this;
			}
		}

		/// <summary>
		/// Deselect.
		/// </summary>
		public void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}
	}
}