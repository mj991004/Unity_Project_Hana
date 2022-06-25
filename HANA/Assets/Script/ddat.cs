using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddat : MonoBehaviour
{
    Rigidbody2D r;
    float speed = 60.0f;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        int i = Random.Range(0, 2);
        speed = Random.Range(60f, 90f);
        float s = (i == 0 ? -speed:speed);
        Vector2 v = new Vector2(s, -2);
        r.AddForce(v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Death")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "Cake")
        {
            gm.getCake();
            Destroy(gameObject);
        }
    }
}
