using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;
    public int health = 1;
    public float timeOutHurt = 2;

    public Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
            
              
        }
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null && attacking) { 
                    enemy.Hurt();
        }  
    }



}
