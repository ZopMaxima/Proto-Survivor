// DemoCharacterSelector.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   January 17, 2021

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo character selector.
	/// </summary>
	public class DemoCharacterSelector : MonoBehaviour
	{
		public bool SelectOnEnable;

		/// <summary>
		/// Select.
		/// </summary>
		public void OnEnable()
		{
			if (SelectOnEnable)
			{
				DemoCameraController.Target = transform;
			}
		}
	}
}