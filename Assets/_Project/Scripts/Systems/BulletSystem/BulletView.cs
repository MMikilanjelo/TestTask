
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Game.Bullets;
namespace Game.System.BulletSystem {
	public class BulletView : MonoBehaviour {
		[SerializeField] public BulletSelectionButton[] Buttons;
		private readonly Key[] keys_ = { Key.Digit1, Key.Digit2, Key.Digit3 };
		private void Awake() {
			for (int i = 0; i < Buttons.Length; i++) {
				if (i >= keys_.Length) {
					Debug.LogError("Not enough keycodes for the number of Buttons.");
					break;
				}
				Buttons[i].Initialize(i, keys_[i]);
			}
		}
		public void UpdateButtonsText(List<BulletData> data) {
			for (int i = 0; i < Buttons.Length; i++) {
				if (i < data.Count) {
					Buttons[i].UpdateText(data[i].Type.ToString());
				}
				else {
					Buttons[i].gameObject.SetActive(false);
				}
			}
		}
	}
}
