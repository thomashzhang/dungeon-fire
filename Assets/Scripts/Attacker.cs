using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] float currentSpeed = 1f;
    [SerializeField] Animation deathAnitmation;

    private Defender currentTarget;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    internal void PlayDeathAnimationAndDestory()
    {
        if (deathAnitmation != null)
        {
            deathAnitmation.Play();
            Destroy(gameObject, 3f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Attack(Defender defender)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = defender;
    }
}
