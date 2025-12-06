using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); 
    }

    public void Launch(Vector2 direction,float force)
    {
        rigidbody.AddForce(direction * force);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile collision with" +  other.gameObject);
        Destroy(gameObject);
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate (projectilePrefab,rigidbody2d.position + Vector2.up * 0.5f,Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(
    }
}
