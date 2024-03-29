using System;
using TMPro;
using UnityEngine;

namespace ResourceExample.Scripts
{
	public class ResourceStorage : MonoBehaviour
	{
		private int _resourcesCount;
		
		public event Action ResourcesCountChanged;

		public int ResourcesCount
		{
			get => _resourcesCount;
			private set
			{
				if (_resourcesCount == value)
					return;
				
				_resourcesCount = value;
				ResourcesCountChanged?.Invoke();
			}
		}
		
		public bool CanPay(int amount) =>
			_resourcesCount >= amount;

		public void IncreaseResourcesCount(int amount)
		{
			if (amount <= 0)
				throw new ArgumentOutOfRangeException(nameof(amount));

			ResourcesCount += amount;
		}

		public void DecreaseResourceCount(int amount)
		{
			if (amount <= 0)
				throw new ArgumentOutOfRangeException(nameof(amount));
			
			if (ResourcesCount <= 0)
				return;

			ResourcesCount -= amount;
		}
	}
}