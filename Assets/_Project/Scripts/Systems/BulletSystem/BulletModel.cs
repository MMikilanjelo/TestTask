using System;
using System.Collections.Generic;
using Game.Bullets;

namespace Game {
	public class BulletModel {
		public Action<BulletData> BulledAdded = delegate { };
		public readonly List<BulletData> Bullets = new();
		public void Add(BulletData bulletData) {
			Bullets.Add(bulletData);
			BulledAdded?.Invoke(bulletData);
		}
	}
}
