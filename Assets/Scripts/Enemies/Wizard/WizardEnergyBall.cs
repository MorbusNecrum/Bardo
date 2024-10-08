using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnergyBall : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private float lifeSpan;
    private float lifeTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().GetDamage(damage);
        }

        Destroy(gameObject);
    }
}
