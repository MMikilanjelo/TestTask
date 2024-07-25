using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace Game.Core.Input {
	[CreateAssetMenu(fileName = "InputReader", menuName = "Game/InputReader")]
	public class InputReader : ScriptableObject, GameInput.IGameplayActions {
		public UnityAction Shoot = delegate { };
		private GameInput gameInput_;
		public void EnablePlayerActions (){
			gameInput_.Gameplay.Enable();
		}
		private void OnEnable() {
			if (gameInput_ == null) {
				gameInput_ = new GameInput();
				gameInput_.Gameplay.SetCallbacks(this);
			}
		}
		public void OnShoot(InputAction.CallbackContext context) {
			switch (context.phase) {
				case InputActionPhase.Started:
					Shoot?.Invoke();
					break;
			}
		}
	}
}

