using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleDefender : Mercenary
{
    private Animator animator;
    private Stack<Attacker> currentTarget;

    protected override void Start()
    {
        base.Start();
        currentTarget = new Stack<Attacker>();
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (currentTarget.Count == 0)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void Attack(Attacker attacker)
    {
        animator.SetBool("isAttacking", true);
        currentTarget.Push(attacker);
    }

    public void AttackCurrentTarget(int damage)
    {
        // Get rid of targets that have been destoryed
        while (currentTarget.Count > 0 && currentTarget.Peek() == null)
        {
            currentTarget.Pop();
        }
        if (currentTarget.Count == 0)
        {
            return;
        }
        var health = currentTarget.Peek().GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker != null && Math.Abs(attacker.transform.position.y - transform.position.y) <= Mathf.Epsilon)
        {
            Attack(attacker);
        }
    }
}
