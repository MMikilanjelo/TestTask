using DG.Tweening;
using Game.Components;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace Game.Bullets {
	[RequireComponent(typeof(Rigidbody))]
	public class ExplosionBullet : Bullet {
		[SerializeField] private GameObject[] explosionPrimitives_;
		[SerializeField] private float explosionDuration_ = 0.5f;
		[SerializeField] private float explosionRadius_ = 100f;
		[SerializeField] private float damageAmount_ = 10f;
		[SerializeField] private string tag_ = "Enemy";

		protected override void OnHit(HurtBoxComponent hurtBoxComponent) {
			CreateExplosion();
			DealDamageToEnemies();
			base.OnHit(hurtBoxComponent);
		}

		private void CreateExplosion() {
			foreach (var primitivePrefab in explosionPrimitives_) {
				GameObject primitive = Instantiate(primitivePrefab, transform.position, Quaternion.identity);

				primitive.transform.localScale = Vector3.zero;

				Vector3 targetPosition = transform.position + Random.onUnitSphere * explosionRadius_ / 2;
				primitive.transform.DOMove(targetPosition, explosionDuration_)
								.SetEase(Ease.OutQuad);

				DOTween.To(() => primitive.transform.localScale,
														x => primitive.transform.localScale = x,
														new Vector3(1.5f, 1.5f, 1.5f),
														explosionDuration_)
								.SetEase(Ease.OutQuad)
								.OnComplete(() => Destroy(primitive));
			}
		}

		private void DealDamageToEnemies() {
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius_);
			foreach (var hitCollider in hitColliders) {
				if (hitCollider.CompareTag(tag_)) {
					var hurtBox = hitCollider.GetComponent<HurtBoxComponent>();
					if (hurtBox != null) {
						hurtBox.TakeDamage(HitBoxComponent.Damage);
					}
				}
			}
		}
	}
}