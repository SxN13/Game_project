using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    public bool flip=false;
    public bool EndDialog;
    public GameObject Dialog;

    new private SpriteRenderer SR;
    new private Rigidbody2D RB;

     void Update()
    {
        if(EndDialog==true)
        {
            Time.timeScale = 1;
            Dialog.SetActive(false);
        }
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            Time.timeScale = 0;
            Dialog.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            RB.AddForce(Vector2.up * 1);
            flip = true;
       }


    }
}
