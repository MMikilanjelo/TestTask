
using System;
using UnityEngine;

namespace Game.Components {
	[RequireComponent(typeof(HealthComponent))]
	public class HurtBoxComponent : MonoBehaviour {
		public event Action<HitBoxComponent> HitByHitBox = delegate { };
		private HealthComponent healthComponent_;

		private void Awake() {
			healthComponent_ = GetComponent<HealthComponent>();
		}
		public void OnTriggerEnter(Collider collider) {
			if (collider.TryGetComponent(out HitBoxComponent hitBoxComponent)) {
				HitByHitBox?.Invoke(hitBoxComponent);
				healthComponent_.TakeDamage(hitBoxComponent.Damage);
			}
		}
	}
}
