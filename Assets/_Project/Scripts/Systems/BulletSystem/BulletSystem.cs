
using Game.Bullets;
using UnityEngine;


namespace Game.System.BulletSystem {
	public class BulletSystem : MonoBehaviour {
		[SerializeField] private BulletView bulletView_;
		[SerializeField] private BulletTypes[] startingBullets_;
		private BulletController bulletController_;
		private void Start() {
			bulletController_ = new BulletController.Builder()
				.WithStartingBullets(startingBullets_)
				.Build(bulletView_);
		}
	}
}
