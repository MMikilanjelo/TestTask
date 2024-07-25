using Game.Bullets;
using Game.Core;
namespace Game.Managers {
	public class BulletManager : Singleton<BulletManager> {
		private Bullet selectedBulletPrefab_ = null;
		public Bullet Get() => selectedBulletPrefab_;
		public void SetSelectedBullet(Bullet bullet) => selectedBulletPrefab_ = bullet;

	}
}

