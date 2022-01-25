using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private SpawnParameters spawnParameters;
    [SerializeField] private Spawner spawner;
   
    void Start()
    {
        spawner.Spawn(null, spawnParameters);
        spawner.SetItem(spawnParameters);
        StartCoroutine(SpawnBack());
    }
   public IEnumerator SpawnBack()
    {
        while (true)
        {
            spawner.SetItem(spawnParameters);
            yield return new WaitForSeconds(9f);
        }
    }
}
