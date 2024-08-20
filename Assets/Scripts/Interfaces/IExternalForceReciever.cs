using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExternalForceReciever
{
    void AddExternalForce(Vector2 force);
}
