// HPWidget.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 24, 2023

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zop.Demo;

namespace Zop
{
	/// <summary>
	/// Display character HP.
	/// </summary>
	public class HPWidget : MonoBehaviour
	{
		public Slider BarHP;
		public TMP_Text LabelHP;

		private IHealth _hp;
		private float _hpCache = float.NegativeInfinity;
		private float _hpMaxCache = float.NegativeInfinity;

		/// <summary>
		/// Initialize.
		/// </summary>
		public void Start()
		{
			DemoTargetPlayer.Instance.GetEntityComponents(out _hp);
		}

		/// <summary>
		/// Poll for changes.
		/// </summary>
		public void LateUpdate()
		{
			if (_hp == null)
			{
				return;
			}

			// HP
			if (_hp.HP != _hpCache || _hp.HPMax != _hpMaxCache)
			{
				_hpCache = _hp.HP;
				_hpMaxCache = _hp.HPMax;
				if (LabelHP != null)
				{
					LabelHP.text = _hp.HP.ToString();
				}
				if (BarHP != null)
				{
					BarHP.value = (float)_hp.HP / _hp.HPMax;
				}
			}
		}
	}
}