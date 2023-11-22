using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public Animator animator; // Drag and drop the Animator component here
    public float gravity = 9.8f;
    public float jumpForce = 20f;
    public Rigidbody rb;
    public CapsuleCollider collider;


    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Set the "Walking" parameter to true when moving
            animator.SetBool("Walking", true); 
            animator.SetBool("Crouch", false);
            animator.SetBool("CrouchWalking", false);

            speed = 3f;
            controller.height = 0.4f;
            collider.height = 2.02f;

            if(Input.GetKey("left shift"))    
            {
                animator.SetBool("Running", true);
                animator.SetBool("Walking", false);
                speed = 6f;
            }
            if(!Input.GetKey("left shift"))    
            {
                animator.SetBool("Running", false);
                speed = 3f;
            }
            if(Input.GetKey("c"))
            {
                animator.SetBool("CrouchWalking",true);
                animator.SetBool("Walking", false);
                animator.SetBool("Running", false);
                speed = 2f;
            }
            if(animator.GetBool("Crouch"))
            {
                controller.height = 0.41f;
                collider.height = 0.41f;         
            }
            if(animator.GetBool("CrouchWalking"))
            {
                controller.height = 0.41f;
                collider.height = 0.41f;         
            }
            
        }
        else
        {
            controller.Move(Vector3.zero); // Stop the player when no movement input
            // Set the "Walking" parameter to false when not moving
            animator.SetBool("Walking", false);
            
            animator.SetBool("Running", false);
            animator.SetBool("CrouchWalking", false);
        }
        if(!Input.GetKey("c") && animator.GetBool("CrouchWalking"))
        {
            animator.SetBool("Crouch", false);
            animator.SetBool("CrouchWalking", false);
        }
        if(Input.GetButton("Jump") && IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce);
        }
        
          
        ApplyGravity();
        if(Input.GetKey("c"))
        {
            animator.SetBool("Crouch",true);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
        }
    }
    bool IsGrounded()
    {
        // Example using CharacterController
        if (controller.isGrounded)
        {
            return true;
        }

        // Or, using raycasting (adjust the ray length as needed)
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            // Apply gravity to pull the character down
            controller.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }

}
