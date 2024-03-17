using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{

    public float moveSpeed = 5.0f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= moveSpeed * Time.fixedDeltaTime; 

        if(pos.y < -7)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
