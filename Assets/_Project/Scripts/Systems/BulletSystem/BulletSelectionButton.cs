
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
namespace Game.System.BulletSystem {
	public class BulletSelectionButton : MonoBehaviour {
		public event Action<int> OnButtonPressed = delegate { };
		public int Index { get; private set; }
		public Key Key { get; private set; }
		private Button button_;
		private Text text_;
		private void Awake() {
			if (TryGetComponent(out Button button)) {
				button_ = button;
				button_.onClick.AddListener(() => OnButtonPressed(Index));
			}
			text_ = GetComponentInChildren<Text>();
		}
		void Update() {
			if (Keyboard.current[Key].wasPressedThisFrame) {
				OnButtonPressed(Index);
			}
		}
		public void Initialize(int index, Key key) {
			Index = index;
			Key = key;
		}
		public void RegisterListener(Action<int> listener) => OnButtonPressed += listener;
		public void UnregisterListeners(Action<int> listener) => OnButtonPressed -= listener;
		public void UpdateText(string text) => text_.text = text;
	}
}

