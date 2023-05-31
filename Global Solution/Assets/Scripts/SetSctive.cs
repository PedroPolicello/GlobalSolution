using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSctive : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    void Start()
    {
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(30f);
        spawner.SetActive(true);

    }
}
