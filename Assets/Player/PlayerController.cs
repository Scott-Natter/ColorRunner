using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator anim;
    public float moveSpeed = 5;
    public float JumpForce = 2;
    bool isGrounded = true;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor; 
    public float lastTimeGrounded;
    GameObject UIPalette;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UIPalette = GameObject.FindWithTag("Palette");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        if(Input.GetKeyDown(KeyCode.Space))
            SpaceHit();

        //float moveDirection = Input.GetAxisRaw("Vertical");
        //rb.velocity = new Vector2(0, moveDirection * moveSpeed);
    }

    public void SpaceHit()
    {
        if(isGrounded)
        {
            Jump();
            JumpGameGoo();
        }

        transform.GetComponent<PlayerColor>().NextColor();
        Debug.Log(UIPalette);
        UIPalette.GetComponent<PaletteColor>().NextColor();
        
        //TO DO:
        //CreateColorSplash
    }


    void Jump() {
        //if (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor) {

        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            anim.SetBool("Jumping", true);
        }
    }

    void JumpGameGoo() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }


    void CheckIfGrounded() { 
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (colliders != null) { 
            isGrounded = true;
            anim.SetBool("Jumping", false); 
        } else { 
            if (isGrounded) { 
                lastTimeGrounded = Time.time; 
            } 
            isGrounded = false;
            anim.SetBool("Jumping", true); 
        } 
    }
}
