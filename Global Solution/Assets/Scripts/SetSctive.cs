using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSctive : MonoBehaviour
{
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;
    void Start()
    {
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(30f);
        spawner1.SetActive(true);
        yield return new WaitForSeconds(30f);
        spawner2.SetActive(true);
    }
}
