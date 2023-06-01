using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTime : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawTime;

    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private IEnumerator SpawnTime()
    {
        while (true)
        {
            float spawTime = Random.Range(minSpawnTime, maxSpawTime);
            yield return new WaitForSeconds(spawTime);
            
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }

}
