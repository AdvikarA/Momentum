using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    string button;
    public GameObject playa;
    public Rigidbody2D rd;
    public float movespeed;
    public float minVelocity;
    public float MaxVelocity;
    public float moveinair;
    public float jump;
    public float groundcheckr;
    public float wallcheckx;
    public float wallchecky;
    public Transform feet;
    public float airr;
    public bool enem;
    public float slide;
    public float jumpsleft; 
    private bool inWall;
    public LayerMask groundlayer;
    public Transform fee;
    public ParticleSystem checkp;
    // Update is called once per frame
    private void Start()
    {
        gameObject.tag = "Player";
    }
    void Update()
    {

        if (inWall)
        {

            if (Input.GetKey(KeyCode.W) && jumpsleft != 0)
            {
                Jump();
                jumpsleft = 0; 

            }
        }
        if (Input.GetKey(KeyCode.W) && IsGrounded())
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("press");
            button = "left";

        }
        else if (Input.GetKey(KeyCode.D))
        {
            button = "right";
        }
        else
        {
            button = null;
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Bbbbb");
        if(col.gameObject.CompareTag("wall"))
        {
            inWall = true;
            jumpsleft = 1;
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            enem = true;
            
        }
        
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            inWall = false;
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            enem = false;

        }
    }

    private void FixedUpdate()
    {

        fee.position = transform.position;
       
        if (button == "left")
        {
            if (IsGrounded())
            {
                rd.AddForce(new Vector2(-movespeed, 0), ForceMode2D.Impulse);
                
            }
            else
            {
                rd.AddForce(new Vector2(-moveinair, 0), ForceMode2D.Impulse);

            }
        }
        else if (button == "right")
        {
            if (IsGrounded())
            {
                rd.AddForce(new Vector2(movespeed, 0), ForceMode2D.Impulse);
            }
            else
            {
                rd.AddForce(new Vector2(moveinair, 0), ForceMode2D.Impulse);

            }
        }
    }
    void Jump()
    {

        Vector2 movement = new Vector2(rd.velocity.x / airr, jump);
        Vector2 vel = movement;
        vel.y = Mathf.Clamp(movement.y, minVelocity, MaxVelocity);
        rd.velocity = vel;

    }

    public bool IsGrounded()
    {

        Collider2D groundcheck = Physics2D.OverlapBox(feet.position, new Vector2(groundcheckr, groundcheckr), 0f, groundlayer);
        if (groundcheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(fee.position, new Vector3(wallcheckx, wallchecky));

        //Gizmos.DrawWireCube(feet.position, new Vector3(groundcheckr, groundcheckr));

    }
    
}
