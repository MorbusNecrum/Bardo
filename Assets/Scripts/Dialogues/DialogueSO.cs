using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue", order = 1)]

public class Dialogue : ScriptableObject
{
    [SerializeField] public string speakerName;

    [TextArea(3,10)]
    [SerializeField] public string[] senteces;
    
}
