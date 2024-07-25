using System;
using UnityEngine;

namespace Game.Components {
	public class HitBoxComponent : MonoBehaviour {
		[field: SerializeField] public float Damage { get; private set; } = 1.0f;
		public event Action<HurtBoxComponent> HitHurtBox = delegate { };
		public void OnTriggerEnter(Collider collider) {
			if (collider.TryGetComponent(out HurtBoxComponent hurtBox)) {
				HitHurtBox?.Invoke(hurtBox);
			}
		}
	}
}
