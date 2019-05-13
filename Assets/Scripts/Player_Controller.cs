using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D RB;
    private float SpeedX;
    public float HorizontalSpeed;
    public float JumpForce;
    private bool isGrounded;
    public GameObject hitbox;
    public Transform HitPoint;
    public float HitRadius;
    public GameObject Punch;
    public SpriteRenderer SR;
    private float T;
    private bool faceright = true;
    public Animator anim;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
     }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Fight2D.Action(HitPoint.position, HitRadius, 10, 12, false);
            Punch.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Punch.SetActive(false);
        }
        /* if (Input.GetKeyDown(KeyCode.R))
         {
             hitbox.SetActive(true);
         }
         if (Input.GetKeyUp(KeyCode.R))
         {
             hitbox.SetActive(false);
         }*/
    }
    public void FixedUpdate()
    {
        Run();
        Jump();
        
    }

   
    private void Run()
    {
       
        if (Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.D))
        {
          //  T = T+Time.deltaTime;
            SpeedX = -HorizontalSpeed;
          if (faceright)
                flip();
            // if (T > 1 ) SpeedX = SpeedX * 2;
        }
        else if (Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
          //  T = T + Time.deltaTime;
            SpeedX = HorizontalSpeed;
            if (!faceright)
                flip();
            //  if (T > 1) SpeedX = SpeedX * 2;
        }
        if (Input.GetKeyUp(KeyCode.A)| Input.GetKeyUp(KeyCode.D))
         {
             T = 0;
         }
        
        transform.Translate(SpeedX, 0, 0);
        anim.SetFloat("SpeedX", Mathf.Abs(SpeedX));
        SpeedX = 0;
       
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            RB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void flip()
    {
        faceright = !faceright;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        if (collision.gameObject.tag == "Exit")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
