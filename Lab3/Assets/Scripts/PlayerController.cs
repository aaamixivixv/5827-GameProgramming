using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private PlayerAnimatorController animatorController;

    [Header("Player Values")] 
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.01f;
    
    //Input Values
    private float _moveInput;

    // Boolean Flags
    private bool _isGrounded;
    private void Update()
    {   
        CheckGround();
        SetAnimatorParameter();

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
        Move();   
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
    }
    

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        FlipPlayerSprite();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        TryJumping();

        //rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-force to prevent player stacking up jump momentum.
        //rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
    }

    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-force to prevent player stacking up jump momentum.
        rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
    }
    private void TryJumping()
    {
        if (!_isGrounded) return;
        Jump(jumpForce);
    }
   
   private void FlipPlayerSprite()
   {
    if (_moveInput < 0 )
    {
        player.localScale = new Vector3(-1,1,1);
    }
    else if (_moveInput > 0 )
    {
        player.localScale = Vector3.one;
    }
   }

   private void CheckGround()
   
   {
        var playerBounds = playerCollider.bounds;

        RaycastHit2D raycastHit = Physics2D.BoxCast(
                playerBounds.center, 
                (Vector2)playerBounds.size,
                angle:0f, 
                direction:Vector2.down,
                groundCheckDistance,
                (int)groundLayers);
        
        _isGrounded = raycastHit.collider != null;

   }
   private void SetAnimatorParameter()
   {
        animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
   }
}

