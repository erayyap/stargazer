using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownStop : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float stopPointY = 2f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if(pos.y > stopPointY) pos.y -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
