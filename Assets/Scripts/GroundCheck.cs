using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private gg player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==8)
        {
            player.IsGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            player.IsGrounded = false;
        }
    }

}
