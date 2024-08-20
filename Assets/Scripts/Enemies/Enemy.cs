using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected GameObject player;
    protected LifeController lifeController;
    public LifeController LifeController => lifeController;
    // Start is called before the first frame update
    protected void StartAbstract()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeController = GetComponent<LifeController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


}
