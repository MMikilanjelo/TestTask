using System.Data.Common;
using Game.Bullets;
using Game.Managers;
using UnityEngine;

namespace Game.System.BulletSystem {
	public class BulletController {
		private readonly BulletModel model_;
		private readonly BulletView view_;

		private BulletController(BulletView bulletView, BulletModel bulletModel) {
			model_ = bulletModel;
			view_ = bulletView;
			ConnectView();

		}
		private void ConnectView() {
			for (int i = 0; i < view_.Buttons.Length; i++) {
				view_.Buttons[i].RegisterListener(OnAbilityButtonPressed);
			}
			view_.UpdateButtonsText(model_.Bullets);
		}
		private void OnAbilityButtonPressed(int index) {
			BulletManager.Instance.SetSelectedBullet(model_.Bullets[index].Prefab);
		}
		public class Builder {
			readonly BulletModel model_ = new BulletModel();
			public Builder WithStartingBullets(BulletTypes[] bulletTypes) {
				foreach (var bulletType in bulletTypes) {
					if (ResourceSystem.Instance.TryGetBulletData(bulletType, out BulletData data)) {
						model_.Add(data);
					}
				}
				return this;
			}
			public BulletController Build(BulletView bulletView) {
				if (bulletView == null) {
					Debug.LogError("Assign Bullet View before creating bullet controller");
					return null;
				}
				return new BulletController(bulletView, model_);
			}
		}
	}
}
