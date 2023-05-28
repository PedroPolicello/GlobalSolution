using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D playerRig;
    private SpriteRenderer playerSprite;

    [Header("Player Movement")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpForce;
    private bool onFloor = true;

    //Dash
    private int normalSpeed;
    private bool canDash = true;

    //Singleton
    public static PlayerScript instance;


    void Awake()
    {
        instance = this;
        playerTransform = GetComponent<Transform>();
        playerRig = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        normalSpeed = speed;
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

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Dash());
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && onFloor == true)
        {
            playerRig.AddForce(Vector2.up * jumpForce);
            onFloor = false;
        }
    }

    //COLLIDER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onFloor = true;

        if (collision.gameObject.tag == "Food")
        {
            StartCoroutine(FlashSprite());
            GameManager.instance.PlayerLife();
        }
    }

    //TRIGGER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashSprite());
            GameManager.instance.PlayerLife();
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

    private IEnumerator Dash()
    {
        if (Input.GetButtonDown("Fire1") && canDash)
        {
            speed *= 2;
            yield return new WaitForSeconds(.3f);
            speed = normalSpeed;
            canDash = false;
            yield return new WaitForSeconds(5f);
            canDash = true;
        }
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

}
