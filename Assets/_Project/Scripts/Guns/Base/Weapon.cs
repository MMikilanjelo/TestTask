
using UnityEngine;

namespace Game.Weapons {
	/// <summary>
	/// Base Class for all weapons in game
	/// </summary>
	public abstract class Weapon : MonoBehaviour {
		[field: SerializeField] protected Transform ShootPoint;
		public abstract void Shoot();
	}
}
