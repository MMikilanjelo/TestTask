using Game.Core;
using UnityEngine;

namespace Game.Managers {
	public class GameManager : Singleton<GameManager> {
		[field: SerializeField] public GameObject EnemyGameObject { get; private set; }
		//for simplicity this class just 
		//store a middle enemy target but could be used for bootstrapping all system in game
		//and so on
	}
}
