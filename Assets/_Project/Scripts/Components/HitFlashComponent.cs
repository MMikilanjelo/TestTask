
using DG.Tweening;
using UnityEngine;

namespace Game.Components {
	[RequireComponent(typeof(HurtBoxComponent))]
	[RequireComponent(typeof(Renderer))]
	public class HitFlashComponent : MonoBehaviour {
		private HurtBoxComponent hurtBoxComponent_;
		private Renderer renderer_;
		private Color originalColor_;
		private void Awake() {
			hurtBoxComponent_ = GetComponent<HurtBoxComponent>();
			renderer_ = GetComponent<Renderer>();
			originalColor_ = renderer_.material.color;
		}


		private void OnEnable() => hurtBoxComponent_.HealthComponent.Damaged += Flash;
		private void OnDisable() => hurtBoxComponent_.HealthComponent.Damaged -= Flash;

		private void Flash(float damage) {
			renderer_.material.DOColor(Color.red, 0.1f)
				.OnComplete(() => renderer_.material.DOColor(originalColor_, 0.5f))
				.SetEase(Ease.InOutQuad);
		}
	}

}
