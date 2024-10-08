using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWizardFlyweight", menuName = "Flyweight/WizardFlyweight", order = 2)]
public class WizardFlyweight : EnemyFlyweight
{
    [SerializeField] public float castingDistance;
    [SerializeField] public float castCD;
}
