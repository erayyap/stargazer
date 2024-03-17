using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSineX : MonoBehaviour
{

    float initX;
    public float amplitude = 1;
    public float frequency = 1;
    // Start is called before the first frame update
    void Start()
    {
        initX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = initX + Mathf.Sin(pos.y * frequency) * amplitude;
        transform.position = pos;
    }
}
