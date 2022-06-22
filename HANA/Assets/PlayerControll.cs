using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D PlayerRigidbody;
    private Transform transform;
    public float speed = 8f;
    public float jumpForce = 700f; // Á¡ÇÁ Èû

    private int jumpCount = 0; // ´©Àû Á¡ÇÁ È½¼ö
    private bool isGrounded = false; // ¹Ù´Ú¿¡ ´ê¾Ò´ÂÁö ³ªÅ¸³¿

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");
        float xSpeed = xInput * speed;
        //float zSpeed = zInput * speed;

        float ySpeed = 0;

        if (Input.GetKeyUp(KeyCode.R))
        {
            Respawn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            //PlayerRigidbody.velocity = Vector2.zero;
            //PlayerRigidbody.AddForce(new Vector2(0, jumpForce));
            ySpeed = speed*0.75f;

        }
        else if (Input.GetKeyUp(KeyCode.Space) && PlayerRigidbody.velocity.y > 0)
        {
            //PlayerRigidbody.velocity = PlayerRigidbody.velocity * 0.5f;
            ySpeed = PlayerRigidbody.velocity.y/2;
        }
        else
        {
            ySpeed = PlayerRigidbody.velocity.y;
        }


        Vector2 newVelocity = new Vector3(xSpeed, ySpeed);
        PlayerRigidbody.velocity = newVelocity;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        if(transform.position.x<0)
            transform.position = new Vector3(-7, 0, 0);
        else
            transform.position = new Vector3(7, 0, 0);
        PlayerRigidbody.velocity = Vector2.zero;
    }
}
