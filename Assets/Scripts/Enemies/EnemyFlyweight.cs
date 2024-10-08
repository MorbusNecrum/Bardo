using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyFlyweight", menuName = "Flyweight/EnemyFlyweight", order = 1)]
public class EnemyFlyweight : ScriptableObject
{
    [SerializeField] public string prefabId;

    [SerializeField] public int basicAttackDamage;
    [SerializeField] public float speed;
    [SerializeField] public float chaseDistance;
}
