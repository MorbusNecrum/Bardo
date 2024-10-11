using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Note : MonoBehaviour, IFactoryzable
{
    [SerializeField] private string prefabID;
    public string PrefabID => prefabID;

    public void Die()
    {
        Destroy(gameObject);
    }

}
