using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlimeFlyweight", menuName = "Flyweight/SlimeFlyweight", order = 2)]
public class SlimeFlyweight : EnemyFlyweight
{
    [SerializeField] public float jumpForce;
    [SerializeField] public float pushBackForce;
    [SerializeField] public float jumpCD;
}
