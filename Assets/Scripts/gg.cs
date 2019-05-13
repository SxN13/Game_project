using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gg : MonoBehaviour
{
    [SerializeField]
    public int lives = 5;
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public float jumpForce = 3000.0f;
    public Animator anim;

    private bool isGrounded;

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
        set
        {
            isGrounded = value;
        }
    }

    new private Rigidbody2D rigidbody;
    private bool faceright = true;


    private void Update()
    {
       
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
        }

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {


       
        float moveX = Input.GetAxis("Horizontal");
        rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);

        anim.SetFloat("SpeedX", Mathf.Abs(moveX));


        if (moveX > 0 && !faceright)
            flip();
        else if (moveX < 0 && faceright)
            flip();
    }
  
   

    void flip()
    {
        faceright = !faceright;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Exit")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
   


}
