using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private GameObject foodPrefab;

    private void Update()
    {
        StartCoroutine(SpawnerFood());
    }

    private IEnumerator SpawnerFood()
    {
        Instantiate(foodPrefab, spawner.position, spawner.rotation);
        yield return new WaitForSeconds(5f);
    }

}
