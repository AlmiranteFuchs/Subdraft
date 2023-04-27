using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    /// <summary>
    /// This is the player controller script
    /// Physics based movement
    /// </summary>

    // Character variables
    // Body components
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Collider2D collider;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float speed = 140f;
    [SerializeField] private float max_speed = 9999f;
    [SerializeField] private float jumpForce = 215f;


    // Inputs
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    // Logic
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float raycast_offset = 0.5f;

//  Unity Functions 

    // Setting variables
    void Awake()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        if (collider == null)
        {
            collider = GetComponent<Collider2D>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void FixedUpdate() {
        // Getting input 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if player is grounded
        isGroundedCheck();

        // Animation
        animation();

    }

// Private Class Functions

    private void movement()
    {

        // Horizontal movement
        rigidbody.velocity = new Vector2(
            Mathf.Lerp(rigidbody.velocity.x, horizontalInput * speed, 0.1f), rigidbody.velocity.y);


        // Vertical movement
        // Jumping
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }


        // Old phyics based 

        
        //// Horizontal movement
        //// Add velocity to rigidbody
        // if(horizontalInput >= 0.2f){
        //     rigidbody.AddForce(new Vector2(speed,0));
        // }else if(horizontalInput <= -0.2f ){
        //     rigidbody.AddForce(new Vector2(-speed,0));
        // }else{
        //     // Lol
        // }
    


        // if(rigidbody.velocity.x > max_speed){
        //     rigidbody.velocity = new Vector2(max_speed, rigidbody.velocity.y);
        // }else if (-rigidbody.velocity.x > max_speed){
        //     rigidbody.velocity = new Vector2(-max_speed, rigidbody.velocity.y);
        // }
        // if (rigidbody.velocity.y > max_speed)
        //     rigidbody.velocity = new Vector2(rigidbody.velocity.x, max_speed);
        // if (rigidbody.velocity.y < -max_speed)
        //     rigidbody.velocity = new Vector2(rigidbody.velocity.x, -max_speed);

    }

    private void isGroundedCheck()
    {
        // Raycast to check if player is grounded
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - raycast_offset), Vector2.down, 0.1f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - raycast_offset), Vector2.down * raycast_offset, Color.red);

        if (hit.collider != null && !(hit.collider.tag == "Player"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void animation(){
        // Animation
        animator.SetFloat("Walking", Mathf.Abs(rigidbody.velocity.x));

        if(!isGrounded){
            animator.SetBool("Jumping", true);
        }else{
            animator.SetBool("Jumping", false);
        }

        if(rigidbody.velocity.x > 0.2f){
            spriteRenderer.flipX = false;
        }else if(rigidbody.velocity.x < -0.2f){
            spriteRenderer.flipX = true;
        }
    }
}
