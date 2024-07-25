
using System.Collections.Generic;
using Game.Components;
using UnityEngine;

namespace Game.Bullets {
	public class BouncingBullet : Bullet {
		[SerializeField] private int maxBounces_ = 3;
		[SerializeField] private float bounceRadius_ = 10f;
		[SerializeField] private float bouncingSpeedMultiplier_ = 3f;
		[SerializeField] private string tag_ = "Enemy";
		private int currentBounces_ = 0;
		private VelocityComponent velocityComponent_;

		protected override void Awake() {
			base.Awake();
			velocityComponent_ = GetComponent<VelocityComponent>();
		}

		protected override void OnHit(HurtBoxComponent hurtBoxComponent) {
			HandleBounce(hurtBoxComponent);
		}

		private void HandleBounce(HurtBoxComponent hurtBoxComponent) {
			if (currentBounces_ >= maxBounces_) {
				Destroy(this.gameObject);
				return;
			}

			Collider[] hitColliders = Physics.OverlapSphere(transform.position, bounceRadius_);
			var potentialTargets = new List<Collider>();

			foreach (var hitCollider in hitColliders) {
				if (hitCollider.CompareTag(tag_) && hitCollider.gameObject != hurtBoxComponent.gameObject) {
					potentialTargets.Add(hitCollider);
				}
			}

			if (potentialTargets.Count == 0) {
				Destroy(this.gameObject);
				return;
			}

			var randomIndex = Random.Range(0, potentialTargets.Count);
			var randomTarget = potentialTargets[randomIndex];

			Vector3 directionToTarget = (randomTarget.transform.position - transform.position).normalized;
			velocityComponent_.SetVelocity(directionToTarget * bouncingSpeedMultiplier_);  // Use MaxSpeed from VelocityComponent

			currentBounces_++;
		}
	}
}
