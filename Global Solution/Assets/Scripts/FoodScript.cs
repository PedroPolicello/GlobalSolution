using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private Rigidbody2D foodRig;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;

    void Awake()
    {
        foodRig = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float forceX = Random.Range(minForce, maxForce);
        float forceY = Random.Range(minForce, maxForce);
        foodRig.AddForce(new Vector2(forceX,forceY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GameManager.instance.LoseScore();
        }

        Destroy(gameObject);
    }
}
