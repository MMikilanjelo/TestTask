
using UnityEngine;
using Game.Managers;
using System.Collections;
using Game.Bullets;

namespace Game.Weapons {
	public class Gun : Weapon {
		[SerializeField, Range(1, 10)] private float shootDelay_ = 1.0f;
		[SerializeField] private float shootRange_ = 100.0f;

		public override void Shoot() {
			StartCoroutine(ShootAfterDelay());
		}

		private IEnumerator ShootAfterDelay() {
			yield return new WaitForSeconds(shootDelay_);
			var target = FindCentralEnemy();
			if (target != null) {
				ShootAtTarget(target);
			}
		}

		private GameObject FindCentralEnemy() {
			if (Physics.Raycast(ShootPoint.position, Vector3.forward, out RaycastHit hit, shootRange_)) {
				if (hit.collider.CompareTag("Enemy")) {
					return hit.collider.gameObject;
				}
			}

			return null;
		}

		private void ShootAtTarget(GameObject target) {
			var bulletPrefab = BulletManager.Instance.Get();
			if (bulletPrefab != null) {
				var bullet = Instantiate(bulletPrefab, ShootPoint.position, ShootPoint.rotation);
				bullet.GetComponent<Bullet>().AccelerateToTarget(target.transform.position);
			}
		}
	}
}
