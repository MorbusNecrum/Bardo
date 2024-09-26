using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHands : MonoBehaviour
{
    private Zombie zombie;

    private void Start()
    {
        zombie = GetComponentInParent<Zombie>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<IDamageable>().GetDamage(zombie.SlamDamage);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(zombie.Direction * zombie.SlamPushBackForce, ForceMode2D.Impulse);
            }
        }
    }
}
