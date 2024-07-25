using Game.Bullets;
using Game.Core;
namespace Game.Managers {
	public class BulletManager : Singleton<BulletManager> {
		private Bullet selectedBulletPrefab_ = null;
		protected void Start() {
			if (ResourceSystem.Instance.TryGetBulletData(BulletTypes.REGULAR, out BulletData data)) {
				selectedBulletPrefab_ = data.Prefab;
			}
			base.Awake();
		}
		public Bullet Get() => selectedBulletPrefab_;
		public void SetSelectedBullet(Bullet bullet) => selectedBulletPrefab_ = bullet;

	}
}

