// LoadScene.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 13, 2023 - Friday the 13th, very spooky.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zop.Unity
{
	/// <summary>
	/// Transition to the next scene.
	/// </summary>
	public class LoadScene : MonoBehaviour
	{
		public enum LoadTiming
		{
			Awake = 0,
			Start,
			EndOfFrame,
		}

		public string Scene = "Main";
		public LoadTiming Timing;
		public bool Async;

		/// <summary>
		/// Attempt to load.
		/// </summary>
		private void Awake()
		{
			if (Timing == LoadTiming.Awake)
			{
				Load();
			}
		}

		/// <summary>
		/// Attempt to load.
		/// </summary>
		private void Start()
		{
			if (Timing == LoadTiming.Start)
			{
				Load();
			}
			else if (Timing == LoadTiming.EndOfFrame)
			{
				StartCoroutine(WaitForEndOfFrame());
			}
		}

		/// <summary>
		/// Load after the full frame has run.
		/// </summary>
		private IEnumerator WaitForEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			Load();
		}

		/// <summary>
		/// Load the requested scene.
		/// </summary>
		private void Load()
		{
			if (Async)
			{
				SceneManager.LoadSceneAsync(Scene);
			}
			else
			{
				SceneManager.LoadScene(Scene);
			}
		}
	}
}