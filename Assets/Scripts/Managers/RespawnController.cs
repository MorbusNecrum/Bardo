using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private List<IRespawneable> elementsToRespawn;

    // Start is called before the first frame update
    void Start()
    {
        var temp = FindObjectsOfType<Object>().OfType<IRespawneable>();
        foreach (IRespawneable element in temp)
        {
            elementsToRespawn.Add(element);
        }
    }
    public void RemoveRespawneable(IRespawneable element)
    { 
        elementsToRespawn.Remove(element); 
    }

    public void RespawnElements()
    {
        foreach (IRespawneable element in elementsToRespawn)
        {
            element.Respawn();
        }
    }
}
