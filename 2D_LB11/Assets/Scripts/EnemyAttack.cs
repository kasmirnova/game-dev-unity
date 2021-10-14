using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAttack : MonoBehaviour
{

    [Header("Health")]
    public Image bar_enemy;
    public float hp_enemy;
    //public GameObject enem;
    void Start()
    {
        hp_enemy = 30;
    }
    void Update()
    {
        bar_enemy.fillAmount = (float)hp_enemy / 30;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeHealthEnemy(-1);
            Debug.Log("- enemy HP");
        }
    }
    public void ChangeHealthEnemy(int healthValueEnemy)
    {

        bar_enemy.fillAmount += healthValueEnemy;
        hp_enemy += healthValueEnemy;
        if (hp_enemy == 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy is died");
        }
    }
}
