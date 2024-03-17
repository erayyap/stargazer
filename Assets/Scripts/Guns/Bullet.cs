using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float speed = 6.0f;
    public float damage = 1;
    public bool isEnemy = false;
    public int timer = 150;

    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
        timer--;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
