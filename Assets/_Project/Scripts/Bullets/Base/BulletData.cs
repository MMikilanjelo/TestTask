
using UnityEngine;
namespace Game.Bullets {
	[CreateAssetMenu(fileName = "BulletData", menuName = "Bullets/NewBulletData")]
	public class BulletData : ScriptableObject {
		[SerializeField] private BulletTypes bulletType_;
		[SerializeField] private Bullet prefab_;

		public BulletTypes Type => bulletType_;
		public Bullet Prefab => prefab_;

		private void OnValidate() {
			if (prefab_ == null) {
				Debug.LogError($"Prefab is not assigned in BulletData!+ {bulletType_}");
			}
		}
	}
}
public enum BulletTypes {
	REGULAR,
	BOUNCING,
	EXPLOSIVE,
}

