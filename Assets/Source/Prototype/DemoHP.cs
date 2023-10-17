// DemoHP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using System;
using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Hit points for an entity.
	/// </summary>
	public class DemoHP : MonoBehaviour
	{
		public int MaxHP = 100;

		public int HP { get { return _hp; } set { SetHP(value); } }

		public Action<DemoHP> OnDeath;

		private int _hp;

		/// <summary>
		/// Initialzie.
		/// </summary>
		public void Awake()
		{
			_hp = MaxHP;
		}

		/// <summary>
		/// Adjust entity HP.
		/// </summary>
		public void SetHP(int value)
		{
			if (value <= 0)
			{
				if (_hp > 0)
				{
					_hp = 0;
					OnDeath?.Invoke(this);
				}
			}
			else if (_hp > 0)
			{
				_hp = Mathf.Min(value, MaxHP);
			}
		}
	}
}