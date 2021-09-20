using UnityEngine;

public class Heroe : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public  bool isGround = false;

    public Transform upPoint;
    private bool cantStand;
    public bool crouching;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        upPoint = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        CheckGround();
        Crouch();
    }



    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGround && Input.GetButtonDown("Jump"))
            Jump();
    }


    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f; 


        /* Option 1
         * 
         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _speedX = -_horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _speedX = _horizontalSpeed;
        }
        transform.Translate(_speedX, 0, 0);
        _speedX = 0;
        */
        /*Option 2
         * 
         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _player.AddForce(new Vector2(-_speedX,0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _player.AddForce(new Vector2(_speedX, 0), ForceMode2D.Force);
        }
         */
        /*Option 3
         * 
          if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * (Time.deltaTime * _speedX);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * (Time.deltaTime * _speedX);
        }
         */
        /*Option 4
         * 
         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left  * (Time.deltaTime * _speedX));
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * (Time.deltaTime * _speedX));
        }
         */
        /*Option 5
         * 
            moveCharacter(movement);
        
         */
    /*for Option 5
     * void moveCharacter(Vector2 direction)
    {
        _player.MovePosition((Vector2)transform.position + (direction * _speedX * Time.deltaTime));
    }*/
}

private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGround = collider.Length > 1;
        cantStand = Physics2D.OverlapCircle(upPoint.position, _groundCheckerRadius, _whatIsGround);
    }
    private void Crouch()
    {
        if((Input.GetKeyDown(KeyCode.S) || cantStand == true) && isGround == true) 
        {
            crouching = true;
        }
        else
        {
            crouching = false;
        }
    }
}
