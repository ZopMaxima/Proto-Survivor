// DemoCameraSettings.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   March 18, 2021

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Apply settings to the camera.
	/// </summary>
	public class DemoCameraSettings : MonoBehaviour
	{
		/// <summary>
		/// Poll for changes.
		/// </summary>
		public void Update()
		{
			Application.targetFrameRate = Screen.currentResolution.refreshRate;
		}
	}
}