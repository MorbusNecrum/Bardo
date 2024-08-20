using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int CurrentHealth { get; }

    void GetDamage(int damage);


}
