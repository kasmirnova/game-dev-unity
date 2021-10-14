
using UnityEngine;

public class Heroe_Animation : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Runer();
        Jumper();
        Hearter();
        Croucher();
        Atacker();


    }
    private void Runer()
    {
        if (Input.GetButton("Horizontal"))
        {
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }
    }
    private void Jumper()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("jump");
        }
    }
    private void Atacker()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _animator.SetBool("attack", true);
        }
        else
        {
            _animator.SetBool("attack", false);
        }

    }
    private void Croucher()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool("crouch", true);
        }
        else
        {
            _animator.SetBool("crouch", false);
        }
    }
    private void Hearter()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetBool("hurt", true);
        }
        else
        {
            _animator.SetBool("hurt", false);
        }
    }
}
