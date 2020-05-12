using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll1 : Attacker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var defender = collision.gameObject.GetComponent<Defender>();
        if (defender != null)
        {
            Attack(defender);
        }
    }
}
