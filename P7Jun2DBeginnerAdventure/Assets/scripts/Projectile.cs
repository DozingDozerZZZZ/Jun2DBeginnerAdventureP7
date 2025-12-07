using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction,float force)
    {
        GetComponent<Rigidbody>().AddForce(direction * force);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       EnemyController enemy = other.GetComponent<EnemyController>();
        if(enemy != null)
         {
             enemy.Fix();

               Destroy(gameObject);
        }
    }
   
}
