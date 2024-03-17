using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public Shooter[] shooters;
    

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool shoot;
    public bool mouseControls = true;
    public float moveSpeed = 3.0f;
    public Destructible destructible;
    public static Ship instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Ship in scene!");
            return;
        }

        instance = this;
    }

    void Start()
    {
        shooters = transform.GetComponentsInChildren<Shooter>();
    }

    void Update()
    {
        if (!mouseControls)
        {
            moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        }
        if(Input.GetMouseButton(0))
        {
            foreach(var shooter in shooters)
            {
                shooter.isActive = true;
            }
        } else
        {
            foreach (var shooter in shooters)
            {
                shooter.isActive = false;
            }
        }


    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (!mouseControls) {
            float moveAmount = moveSpeed * Time.fixedDeltaTime;
            Vector2 move = Vector2.zero;

            if (moveUp)
            {
                move.y++;
            }

            if (moveDown)
            {
                move.y--;
            }

            if (moveRight)
            {
                move.x++;
            }

            if (moveLeft)
            {
                move.x--;
            }

            move.Normalize();

            pos += move * moveAmount;
        } else {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        var cameraPos = Camera.main.transform.position;
        cameraPos.x = Mathf.Clamp(pos.x/2, -2, 2);
        Camera.main.transform.position = cameraPos;
        transform.position = pos;
    }

    public void CalculateProperties(int level)
    {
        destructible.maxHP = 5 + level;
        destructible.HP = destructible.maxHP;
        destructible.armor = (float)level / 10f;
        foreach(var shooter in shooters)
        {
            shooter.CalculateProperties(level);
        }
    }

}
