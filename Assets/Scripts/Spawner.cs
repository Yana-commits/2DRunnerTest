using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(Action OnTouch, SpawnParameters _spawnParameters)
    {
        for (int i = 0; i < 6; i++)
        {
            var instance = Instantiate(_spawnParameters.prefab) as GameItem;
            instance.gameObject.SetActive(false);
            instance.gameObject.transform.SetParent(this.transform);
            instance.OnPlayerTouch += OnTouch;
            instance.Init(_spawnParameters.finishPoint, _spawnParameters.moveTime);
            _spawnParameters.items.Add(instance);
        }
    }
    public void SetItem(SpawnParameters _spawnParameters)
    {
        var enemy = _spawnParameters.items[_spawnParameters.number];
        enemy.gameObject.transform.position = _spawnParameters.startPosition;
        enemy.gameObject.SetActive(true);

        _spawnParameters.number++;

        if (_spawnParameters.number >= _spawnParameters.items.Count)
            _spawnParameters.number = 0;
    }
}
[Serializable]
public class SpawnParameters
{
    public Vector2 startPosition;
    public float finishPoint;
    public float moveTime;
    public GameItem prefab;
    [HideInInspector]
    public List<GameItem> items = new List<GameItem>();
    [HideInInspector]
    public int number = 0;
}