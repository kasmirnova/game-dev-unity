using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamonBehavior : MonoBehaviour
{
    public static int Coin;
    private int count;
    Text text;
    public Text MyTestLabel;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("coins", Coin);
        MyTestLabel.text = "Hello world";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Coin.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // Уничтожаем наш объект
            Destroy(gameObject);
            PlayerPrefs.SetInt("coins", Coin);
            Debug.Log("Object was destroyed");
            if(gameObject.tag == "Diamond")
            {
                Coin += 1;
                Debug.Log(Coin);
            }
            
        }
    }
}
