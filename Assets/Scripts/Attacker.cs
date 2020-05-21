using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] float currentSpeed = 1f;

    private Mercenary currentTarget;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<LevelController>()?.AttackerSpawned();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>()?.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(Mercenary defender)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = defender;
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
}
