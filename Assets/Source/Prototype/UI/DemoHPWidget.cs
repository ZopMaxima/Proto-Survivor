// DemoHPWidget.cs
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
	/// Display character HP.
	/// </summary>
	public class DemoHPWidget : MonoBehaviour
	{
		public Slider BarHP;
		public TMP_Text LabelHP;

		private DemoHP _hp;
		private int _hpCache = int.MinValue;
		private int _hpMaxCache = int.MinValue;

		/// <summary>
		/// Initialize.
		/// </summary>
		public void Start()
		{
			_hp = DemoTargetPlayer.Instance.GetComponentInChildren<DemoHP>();
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
			if (_hp.HP != _hpCache || _hp.MaxHP != _hpMaxCache)
			{
				_hpCache = _hp.HP;
				_hpMaxCache = _hp.MaxHP;
				if (LabelHP != null)
				{
					LabelHP.text = _hp.HP.ToString();
				}
				if (BarHP != null)
				{
					BarHP.value = (float)_hp.HP / _hp.MaxHP;
				}
			}
		}
	}
}