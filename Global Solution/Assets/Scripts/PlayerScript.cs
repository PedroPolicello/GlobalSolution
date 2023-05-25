using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D playerRig;
    private SpriteRenderer playerSprite;

    [Header("Player Movement")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpForce;
    private bool onFloor = true;


    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerRig = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        playerTransform.Translate(new Vector3(moveX, 0, 0) * speed * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && onFloor == true)
        {
            playerRig.AddForce(Vector2.up * jumpForce);
            onFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onFloor = true;

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashSprite());
        }
    }

    private IEnumerator FlashSprite()
    {
        for (int i = 0; i < 6; i++)
        {
            playerSprite.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(.1f);
            playerSprite.color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(.1f);
        }
    }
}
