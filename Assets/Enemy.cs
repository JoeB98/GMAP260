using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;
    public float health;
    public float maxHealth;
    public int value;
    public GameObject playAgain;
    public GameObject gameOver;
    private GameObject[] enemies;
    public Sprite[] spriteList;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
    public void takeDamage( int damage )
    {
        health -= damage;
        if (tag == "Enemy" || tag == "Spawner")
        {
            if (health / maxHealth <= .8f && health / maxHealth > .6f)
            {
                GetComponent<SpriteRenderer>().sprite = spriteList[3];
            }
            else if (health / maxHealth <= .6f && health / maxHealth > .4f)
            {
                GetComponent<SpriteRenderer>().sprite = spriteList[2];
            }
            else if (health / maxHealth <= .4f && health / maxHealth > .2f)
            {
                GetComponent<SpriteRenderer>().sprite = spriteList[1];
            }
            else if (health / maxHealth <= .2f)
            {
                GetComponent<SpriteRenderer>().sprite = spriteList[0];
            }
        }
        if(health <= 0f)
        {
            die();
        }
    }
    void die()
    {
        if (tag == "Spawner")
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            gameOver.SetActive(true);
            playAgain.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("Player").SendMessage("AddScore", value, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
