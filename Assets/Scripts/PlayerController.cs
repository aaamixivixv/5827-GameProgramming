using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    private float moveInput;
    private float moveSpeed = 5f;
    [SerializeField] private ObjectColor color;
    [SerializeField] private SpriteRenderer render;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(jumpForce * transform.up,ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    
    private void Update()
    {
        rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ColorCh colorCh))
        {
            ObjectColor color = colorCh.color;

            switch(color)
            {
                case ObjectColor.Red:
                    render.color = Color.red;
                    break;
                case ObjectColor.Yellow:
                    render.color = Color.yellow;
                    break;
                case ObjectColor.Green:
                    render.color = Color.green;
                    break;
            }

            Destroy(colorCh.gameObject);
        }
    }
}