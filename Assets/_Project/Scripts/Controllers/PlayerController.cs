using UnityEngine;
using Game.Core.Input;
using Game.Weapons;
namespace Game.Controllers {
	public class PlayerController : MonoBehaviour {
		[field: SerializeField] private InputReader inputReader_;
		[field: SerializeField] private Weapon currentWeapon_;
		private void Start() => inputReader_.EnablePlayerActions();
		private void OnEnable() {
			inputReader_.Shoot += OnShoot;
		}
		private void OnDisable() {
			inputReader_.Shoot -= OnShoot;
		}
		private void OnShoot() {
			currentWeapon_?.Shoot();
		}
	}
}

