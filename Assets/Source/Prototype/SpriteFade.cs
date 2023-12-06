// SpriteFade.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 6, 2023

using System.Collections;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Fade a sprite to a new colour.
	/// </summary>
	public class SpriteFade : MonoBehaviour
	{
		public SpriteRenderer Sprite;
		public Color Colour;
		public float Duration;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Start()
		{
			if (Sprite != null)
			{
				Coroutiner.StartCoroutine(Fade(Sprite, Colour, Duration));
			}
		}

		/// <summary>
		/// Fade to the requested colour.
		/// </summary>
		private static IEnumerator Fade(SpriteRenderer sprite, Color colour, float duration)
		{
			Color startColour = sprite.color;
			float progress = 0;

			// Interpolate
			while (progress < duration)
			{
				if (sprite == null)
				{
					yield break;
				}

				sprite.color = Color.Lerp(startColour, colour, progress / duration);

				yield return null;
				progress += Time.deltaTime;
			}

			// Final value.
			if (sprite != null)
			{
				sprite.color = colour;
			}
		}
	}
}