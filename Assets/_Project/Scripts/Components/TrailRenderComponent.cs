
using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;

namespace Game.Components {
	[RequireComponent(typeof(TrailRenderer))]
	public class TrailRenderComponent : MonoBehaviour {
		private TrailRenderer trailRenderer_;

		[SerializeField] private float fadeDuration_ = 0.2f;
		[SerializeField] private float startWidth_ = 0.5f;
		[SerializeField] private float endWidth_ = 0f;

		// List of predefined colors
		[SerializeField]
		private List<Color> predefinedColors_ = new List<Color> {
						Color.white,   // White
            Color.blue,    // Blue
            Color.red,     // Red
            Color.green,   // Green
            Color.yellow   // Yellow
        };

		private void Awake() {
			trailRenderer_ = GetComponent<TrailRenderer>();
		}

		private void Start() {
			AnimateTrail();
		}

		private void AnimateTrail() {
			Color randomStartColor = GetRandomColor();
			Color randomEndColor = GetRandomColor();

			DOTween.To(() => trailRenderer_.startColor, x => trailRenderer_.startColor = x, randomStartColor, fadeDuration_)
					.SetEase(Ease.InOutQuad);

			DOTween.To(() => trailRenderer_.endColor, x => trailRenderer_.endColor = x, randomEndColor, fadeDuration_)
					.SetEase(Ease.InOutQuad);
		}

		private Color GetRandomColor() {
			int randomIndex = Random.Range(0, predefinedColors_.Count);
			return predefinedColors_[randomIndex];
		}
	}
}
