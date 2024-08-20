using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeableSpeed
{
    void ChangeSpeed(float multiplier);
    void ChangeSpeed(float multiplier, float duration);
}
