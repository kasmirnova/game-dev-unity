using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // коли ми будемо додавати наш скрипт, то компонента rigidbody2d
                                        // додасться автоматично та видалити її ми не зможемо,
                                        // тобто ми залежні від чієї компоненти
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigibody;
    [SerializeField] private float _speed=3f; //зара в нас є поле вводу для цієї змінної в юніті
    [SerializeField] private SpriteRenderer _spritrenderer;
    [SerializeField] private float _jumpForce=15f;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;
    private bool isground = false;

    void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        // RIGHT LEFT
        float direction = Input.GetAxisRaw("Horizontal");

        _rigibody.velocity = new Vector2(  direction * _speed, _rigibody.velocity.y); // velocity змінює все


        if (direction > 0 && _spritrenderer.flipX)
        {
            _spritrenderer.flipX = false;
        }

        else if (direction < 0 && !_spritrenderer.flipX)
        {
            _spritrenderer.flipX = true;
           
        }

        // SPACE

        if (isground&&Input.GetKeyDown(KeyCode.Space))
        {
            _rigibody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse); // додає якесь значення 
        }

        // GROUND
     
        //bool canJump = Physics2D.OverlapCircle(_groundChecker.position,_groundCheckerRadius, _whatIsGround);
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.position, _groundCheckerRadius);
        //if(colliders.Length > 1)
        //{
        //    canJump = true;
        //if (Input.GetKeyDown(KeyCode.Space) && canJump)
        //{
        //    _rigibody.AddForce(Vector2.up * _jumpForce); // додає якесь значення 
        //}
    }
    private void Running()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
    //}
    private void FixedUpdate()
    {
        CheckedGround();
    }
    private void CheckedGround()
    {
        Collider2D[] collide = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isground = collide.Length > 0;
    }
}
