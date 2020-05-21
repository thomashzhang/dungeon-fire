using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll1 : Attacker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var defender = collision.gameObject.GetComponent<Mercenary>();
        if (defender != null && Math.Abs(defender.transform.position.y - transform.position.y) <= Mathf.Epsilon)
        {
            Attack(defender);
        }
    }
}
