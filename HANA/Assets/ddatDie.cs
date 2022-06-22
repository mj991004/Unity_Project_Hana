using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddatDie : MonoBehaviour
{
    Rigidbody2D r;
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        int i = Random.Range(0, 2);
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
    }
}
