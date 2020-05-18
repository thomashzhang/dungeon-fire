using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleDefender : Defender
{
    private Animator animator;
    private Attacker currentTarget;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void Attack(Attacker attacker)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = attacker;
    }

    public void AttackCurrentTarget(int damage)
    {
        if (currentTarget == null)
        {
            return;
        }
        var health = currentTarget.GetComponent<Health>();
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
