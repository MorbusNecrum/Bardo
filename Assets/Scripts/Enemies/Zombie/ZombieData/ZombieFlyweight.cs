using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewZombieFlyweight", menuName = "Flyweight/ZombieFlyweight", order = 2)]
public class ZombieFlyweight : EnemyFlyweight
{
    [SerializeField] public float slamPushBackForce;
}
