/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D PlayerRigidbody;
    private Transform transform;
    public float speed = 8f;

    private int jumpCount = 0; 
    AudioSource audioSource;

    public AudioClip jumpClip, walkClip, landClip;
    bool isGrounded = false, isWalking=false, isJumping=false, isPlayingJumpSound, isStunned=false;

    private Vector2 exSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;

        if (!isWalking && xInput != 0) isWalking = true;
        else if (isWalking && xInput == 0) isWalking = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Respawn();
        }
        
        float ySpeed = 0;

        if (!isStunned)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            {
                jumpCount++;
                ySpeed = speed * 0.75f;
                isJumping = true;
                isPlayingJumpSound = false;
            }
            else if (Input.GetKeyUp(KeyCode.Space) && PlayerRigidbody.velocity.y > 0)
            {
                ySpeed = PlayerRigidbody.velocity.y / 2;
            }
            else
            {
                ySpeed = PlayerRigidbody.velocity.y;
            }

            Vector2 newVelocity = new Vector3(xSpeed, ySpeed);
            PlayerRigidbody.velocity = newVelocity;
        }

        exSpeed = PlayerRigidbody.velocity;

        if (isJumping&&!isPlayingJumpSound)
        {
            audioSource.clip = jumpClip;
            audioSource.loop = false;
            audioSource.Play();
            isPlayingJumpSound = true;
        }
        else if (audioSource.isPlaying&&!isGrounded&&audioSource.clip == walkClip) {
            audioSource.Stop();
        }
        else if (isWalking&&isGrounded)
        {
            if (!(audioSource.isPlaying && audioSource.clip == walkClip)) {
                audioSource.clip = walkClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            if(collision.contacts[0].normal.y>0.7f)
            {
                isGrounded = true;
                jumpCount = 0;
                Debug.Log("G");
                
                isPlayingJumpSound = false;
                audioSource.Stop();
                audioSource.clip = landClip;
                audioSource.loop = false;
                audioSource.Play();
            }
            else if (collision.contacts[0].normal.y<0.3f)
            {
                Debug.Log("S");
                Debug.Log("income :" + exSpeed);
                Vector2 normal = collision.contacts[0].normal;
                PlayerRigidbody.velocity = Vector2.Reflect(exSpeed, normal).normalized*speed/2;
                Debug.Log("reflect :" + PlayerRigidbody.velocity);
                StartCoroutine(Stunned());
            }
    }

    IEnumerator Stunned()
    {
        isStunned = true;
        float stuntime = (Mathf.Abs(exSpeed.x) - speed)*0.1f + 1f;
        Debug.Log("Stunned - " + stuntime);
        yield return new WaitForSecondsRealtime(stuntime);
        isStunned = false;
        Debug.Log("Stun end");
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("NG0");
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("NG");
        }
    }
*/
    /*private void CheckIsGrounded(bool except)
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.03f, new Color(0, 1, 0), LayerMask.GetMask("Default"));
        RaycastHit2D hit= Physics2D.Raycast(transform.position, Vector3.down, 0.03f, LayerMask.GetMask("Default"));
        if (hit.collider!=null&&!except)
        {
            Debug.Log("T");
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            Debug.Log("F");
            isGrounded = false;
        }
    }*/
/*
    public bool getIsGrounded() { return isGrounded; }

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
*/