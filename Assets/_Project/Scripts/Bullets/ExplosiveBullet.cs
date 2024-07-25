using DG.Tweening;
using Game.Components;
using UnityEngine;

namespace Game.Bullets {
	[RequireComponent(typeof(Rigidbody))]
	public class ExplosionBullet : Bullet {
		[SerializeField] private GameObject[] explosionPrimitives_;
		[SerializeField] private float explosionDuration_ = 0.5f;
		[SerializeField] private float explosionRadius_ = 5f;

		protected override void OnHit(HurtBoxComponent hurtBoxComponent) {
			CreateExplosion();
			base.OnHit(hurtBoxComponent);
		}

		private void CreateExplosion() {
			foreach (var primitivePrefab in explosionPrimitives_) {
				GameObject primitive = Instantiate(primitivePrefab, transform.position, Quaternion.identity);

				primitive.transform.localScale = Vector3.zero;

				Vector3 targetPosition = transform.position + Random.onUnitSphere * explosionRadius_;
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
	}
}
