using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int layerNumber;
    
    
    private Rigidbody2D rb2;
    public bool isGround;
    public Vector2 direction;

    private AnimationCharacter animationCharacter;
    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animationCharacter = GetComponent<AnimationCharacter>();
    }
    //Metodo Update
    //private void Update()
    //{
    //    HandleInput();
    //    HandleMovement();
    //}
    private void FixedUpdate()
    {
        
    }
    public  void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");

        if (jumpInput)
        {
            TryJump();
        }

        UpdateDirection(horizontalInput);
    }

    public  void HandleMovement()
    {
        Vector2 movement = new Vector2(direction.x * speed, rb2.velocity.y);
        rb2.velocity = movement;
    }

    private void TryJump()
    {
        if (isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb2.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGround = false;
        // Você pode chamar métodos relacionados à animação aqui, se necessário.

        animationCharacter.SetAnimation(animationCharacter.JumpAnim);
    }

    private void UpdateDirection(float horizontalInput)
    {
        direction = new Vector2(horizontalInput, Input.GetAxisRaw("Vertical"));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == layerNumber)
        {
            isGround = true;
        }
    }
}

