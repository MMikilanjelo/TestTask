
using System.Collections.Generic;
using System.Linq;
using Game.Bullets;
using Game.Core;
using UnityEngine;

public class ResourceSystem : Singleton<ResourceSystem> {
	public IReadOnlyList<BulletData> BulletData;
	private const string BULLET_RESOURCE_FOLDER = "BULLETS";
	private Dictionary<BulletTypes, BulletData> bulletDataCollection_ = new();
	protected override void Awake() {
		base.Awake();
		AssembleResources();
		Debug.Log(bulletDataCollection_.Count);
	}

	private void AssembleResources() {
		BulletData = Resources.LoadAll<BulletData>(BULLET_RESOURCE_FOLDER).ToList();

		bulletDataCollection_ = BulletData.ToDictionary(bullet => bullet.Type, bullet => bullet);
	}

	private bool TryGetData<K, T>(K key, Dictionary<K, T> collection, out T data) where T : class => collection.TryGetValue(key, out data);
	public bool TryGetBulletData(BulletTypes type, out BulletData data) => TryGetData(type, bulletDataCollection_, out data);

}
