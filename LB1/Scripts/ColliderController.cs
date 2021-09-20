using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField] public BoxCollider2D stand;
    [SerializeField] public BoxCollider2D crouch;
    //[SerializeField] public CircleCollider2D bottom;


    Heroe heroe;
    // Start is called before the first frame update
    void Start()
    {
       heroe = GetComponent<Heroe>();

        stand.enabled = true;
        crouch.enabled = false;
        //bottom.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (heroe.isGround == false)
        {
            stand.enabled = true;
            crouch.enabled = false;
            //bottom.enabled = true;
        }
        else
        {
            if(heroe.crouching == true) {
                stand.enabled = false;
                crouch.enabled = true;
                //bottom.enabled = true;
            }
            else
            {
                stand.enabled = true;
                crouch.enabled = false;
                //bottom.enabled = true;
            }

        }
    }
}
