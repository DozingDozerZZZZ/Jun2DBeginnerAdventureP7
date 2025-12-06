using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Temporary invincibilty
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    //movement
    public InputAction MoveAction;
    public float speed = 3.0f;

    //rigd fix
    Rigidbody2D rigidbody2d;
    Vector2 move;

    //Health
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; } }

    //animation
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();

        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        animator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        move = MoveAction.ReadValue<Vector2>();

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x,move.y);
            moveDirection.Normalize();
        }
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;

            animator.SetTrigger("Hit");
        }


        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIhandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }
}
