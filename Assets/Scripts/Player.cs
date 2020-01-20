﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 0.1f; //移動量

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        //ライトキーで右に移動
        
        //レフトキーで左に移動
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move -= moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move += moveSpeed;
        }
        Vector2 newPos = new Vector2(transform.position.x + move, transform.position.y);
        float margin = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = Utils.GetClampedPosition(newPos, margin);
    }

}
