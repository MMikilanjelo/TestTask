
using System;
using UnityEngine;

namespace Game.Components {
	[RequireComponent(typeof(HealthComponent))]
	public class HurtBoxComponent : MonoBehaviour {
		public event Action<HitBoxComponent> HitByHitBox = delegate { };
		public HealthComponent HealthComponent { get; private set; }

		private void Awake() {
			HealthComponent = GetComponent<HealthComponent>();
		}
		public void OnTriggerEnter(Collider collider) {
			if (collider.TryGetComponent(out HitBoxComponent hitBoxComponent)) {
				HitByHitBox?.Invoke(hitBoxComponent);
				TakeDamage(hitBoxComponent.Damage);
			}
		}
		public void TakeDamage(float damage) => HealthComponent.TakeDamage(damage);
	}
}
