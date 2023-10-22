// DemoXPWidget.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Zop.Demo
{
	/// <summary>
	/// Display experience and level.
	/// </summary>
	public class DemoXPWidget : MonoBehaviour
	{
		public Slider BarXP;
		public TMP_Text LabelXP;
		public TMP_Text LabelXPMax;
		public TMP_Text LabelLevel;

		private DemoXP _xp;
		private int _xpCache = int.MinValue;
		private int _xpMaxCache = int.MinValue;
		private int _levelCache = int.MinValue;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Start()
		{
			_xp = DemoTargetPlayer.Instance.GetComponentInChildren<DemoXP>();
		}

		/// <summary>
		/// Poll for changes.
		/// </summary>
		public void LateUpdate()
		{
			if (_xp == null)
			{
				return;
			}

			// XP
			if (_xp.XP != _xpCache || _xp.XPMax != _xpMaxCache)
			{
				_xpCache = _xp.XP;
				_xpMaxCache = _xp.XPMax;
				if (LabelXP != null)
				{
					LabelXP.text = _xp.XP.ToString();
				}
				if (LabelXPMax != null)
				{
					LabelXPMax.text = _xp.XPMax.ToString();
				}
				if (BarXP != null)
				{
					BarXP.value = (float)_xp.XP / _xp.XPMax;
				}
			}

			// Level
			if (_xp.Level != _levelCache)
			{
				_levelCache = _xp.Level;
				if (LabelLevel != null)
				{
					LabelLevel.text = _xp.Level.ToString();
				}
			}
		}
	}
}