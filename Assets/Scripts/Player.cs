using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private int extraJumps = 2;
    private Location location = Location.Floor;

    public bool readyJump;
    public bool isGrounded;
   
    void Start()
    {
        location = Location.Floor;
    }
    public void Jump(float jumpForce)
    {
        if (location == Location.Floor)
        {
            if (readyJump && extraJumps > 0)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                extraJumps--;
                readyJump = extraJumps > 0 ? true : false;
            }
        }
        else 
        {
            rb.gravityScale = 1;
            location = Location.Floor;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            if (ground.isUpper != true)
            {
                readyJump = true;
                extraJumps = 2;
            }
            else
            {
                readyJump = false;
                rb.gravityScale = 0;
                location = Location.Ceiling;
            }
        }
        else if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.FinalTouch();
        }
    }
    public enum Location
    {
        Floor,
        Ceiling
    }
}
