﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 3f;
    public Vector2 offset = new Vector2(1.5f, 0.5f);
    public bool isLeft = false;
    private Transform player;
    private int lastX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerisLeft)
    {
        player = GameObject.FindWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if(playerisLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z); 
        }else
        {
 transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); 
        }
    }
     private void FixedUpdate()
    {
        if(player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;

            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if(isLeft)
            {
                target= new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);

            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
             
        }
    }
}
