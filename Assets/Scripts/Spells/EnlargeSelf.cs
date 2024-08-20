using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeSelf : MonoBehaviour, ISpell, ISelfCastSpell
{
    private string id = "EnlargeSelf";
    public string Id => id;

    [SerializeField] private List<string> combo = new List<string>(); //Insert on Editor
    [SerializeField] private float effectDuration;
    public List<string> Combo => combo;

    GameObject playerRef;

    public void SelfCast()
    {
        playerRef = GameObject.Find("Player");
        playerRef.GetComponent<Character>().ChangeSieze(2f, effectDuration);
    }
}
