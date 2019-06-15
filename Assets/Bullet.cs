using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy hit = hitInfo.GetComponent<Enemy>();
        if ( hit != null)
        {
            hit.takeDamage(1);
            Destroy(gameObject);
        }
        
    }
}
