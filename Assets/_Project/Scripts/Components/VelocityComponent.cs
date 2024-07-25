
using UnityEngine;

namespace Game.Components {
	[RequireComponent(typeof(Rigidbody))]
	public class VelocityComponent : MonoBehaviour {
		[field: SerializeField] public float AccelerationCoefficientMultiplier { get; private set; } = 1f;
		[field: SerializeField] public float MaxSpeed { get; private set; } = 1.0f;
		[field: SerializeField] public float AccelerationCoefficient { get; private set; } = 2.0f;

		private Rigidbody rigidbody_;
		private Vector3 velocity_;

		private void Awake() {
			rigidbody_ = GetComponent<Rigidbody>();
		}

		private void FixedUpdate() {
			rigidbody_.velocity = velocity_;
		}

		private void AccelerateToVelocity(Vector3 targetVelocity) {
			velocity_ = Vector3.Lerp(velocity_, targetVelocity, 1f - Mathf.Exp(-AccelerationCoefficient * AccelerationCoefficientMultiplier * Time.deltaTime));
			velocity_ = Vector3.ClampMagnitude(velocity_, MaxSpeed);
		}

		private void AccelerateInDirection(Vector3 direction) {
			Vector3 targetVelocity = direction * MaxSpeed;
			AccelerateToVelocity(targetVelocity);
		}

		public void Move(Vector3 targetPosition) {
			Vector3 direction = (targetPosition - transform.position).normalized;
			AccelerateInDirection(direction);
		}

		public void SetVelocity(Vector3 newVelocity) {
			velocity_ = newVelocity;
		}
	}
}