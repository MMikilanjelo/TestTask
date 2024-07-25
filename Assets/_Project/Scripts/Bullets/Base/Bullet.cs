
using UnityEngine;
using Game.Components;

namespace Game.Bullets {
	/// <summary>
	/// Base Class for all bullets in Game
	/// </summary>
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(HitBoxComponent))]
	[RequireComponent(typeof(VelocityComponent))]
	public abstract class Bullet : MonoBehaviour {
		[SerializeField] private float lifeTime_ = 10f;
		protected HitBoxComponent HitBoxComponent;
		protected VelocityComponent VelocityComponent;
		protected BulletData Data;

		protected virtual void Awake() {
			HitBoxComponent = GetComponent<HitBoxComponent>();
			VelocityComponent = GetComponent<VelocityComponent>();
			Destroy(this.gameObject, lifeTime_);
		}

		protected virtual void OnEnable() => HitBoxComponent.HitHurtBox += OnHit;

		protected virtual void OnDisable() => HitBoxComponent.HitHurtBox -= OnHit;

		protected virtual void OnHit(HurtBoxComponent hitBoxComponent) => Destroy(this.gameObject);


		public void SetBulletData(BulletData data) => Data = data;

		public void AccelerateToTarget(Vector3 targetPosition) => VelocityComponent.Move(targetPosition);

	}
}
