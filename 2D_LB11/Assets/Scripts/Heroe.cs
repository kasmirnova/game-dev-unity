using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Heroe : MonoBehaviour
{
    [Header("Heroe Info")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 20f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [Header("Colliders")]
    [SerializeField] Collider2D _headCollider;
    public BoxCollider2D stand;
    public BoxCollider2D crouch;
    public bool crouching = false;

    [Header("Ground")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float _groundCheckerRadius;
    public LayerMask _whatIsGround;
    public bool isGround = false;

    [Header("Up Point")]
    public Transform upPoint;
    private bool cantStand;

    [Header("Health and Mana")]
    public Image bar;
    public Image bar_mana;
    public float hp;
    public float mana;

    [Header("COINSSS")]
    public GameObject[] coinses;
    public Text cash;
    private int cash_value;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        upPoint = GetComponent<Transform>();
        hp = 100;

    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, _groundCheckerRadius, _whatIsGround);
        cantStand = Physics2D.OverlapCircle(upPoint.position, _groundCheckerRadius, _whatIsGround);
        Regeneration();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGround && Input.GetButtonDown("Jump"))
            Jump();
        CheckGround();
        Crouch();
        bar.fillAmount = (float)hp / 100;
        bar_mana.fillAmount = (float)mana / 100;
    }
    async private void Regeneration()
    {
        if (hp < 70 && hp < 100)
        {
            await Task.Delay(2000);
            if (hp < 100)
            {
                hp += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hp"))
        {
            ChangeHealth(5);
            Destroy(other.gameObject);
            Debug.Log("Add HP");
        }
        if (other.CompareTag("Mana"))
        {
            ChangeMana(5);
            Destroy(other.gameObject);
            Debug.Log("Add mana");
        }
        if (other.gameObject.tag == "Enemy")
           {
            ChangeHealth(-1);
            Debug.Log("-HP");
          }
        if (other.gameObject.tag == "Exit")
        {
            Debug.Log("Out");
        }
        for (int a = 0; a < coinses.Length; a++)
        {
            if (other.gameObject == coinses[a])
            {
                Destroy(coinses[a]);
                cash_value += 1;
                cash.text = "Coins: " + Convert.ToString(cash_value);
            }
        }
    }

    public void ChangeHealth(int healthValue)
    {
        bar.fillAmount += healthValue;
        hp += healthValue;
    }
    public void ChangeMana(int manaValue)
    { 
        bar_mana.fillAmount += manaValue;
        mana += manaValue;
    }
    private void Run()
    {
        Vector3 _direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, speed * Time.deltaTime);
        sprite.flipX = _direction.x < 0.0f;
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
        if ((Input.GetKey(KeyCode.DownArrow) || cantStand == true) && isGround == true)
        {
            stand.enabled = false;
            crouch.enabled = true;
        }
        else if(cantStand ==false)
        {
            stand.enabled = true;
            crouch.enabled = false;
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //if()
        }

    }

}

