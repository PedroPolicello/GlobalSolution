using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : MonoBehaviour
{
    [SerializeField] private GameObject missionText;

    void Start()
    {
        StartCoroutine(Mission());
    }

    private IEnumerator Mission()
    {
        missionText.SetActive(true);
        yield return new WaitForSeconds(20f);
        missionText.SetActive(false);
    }
}
