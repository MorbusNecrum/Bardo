using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private List<string> knownSpells = new List<string>();
    public List<string> KnownSpells => knownSpells;


    // Start is called before the first frame update
    void Start()
    {
        AddSpellKnown("Fireball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSpellKnown(string spellID)
    {
        knownSpells.Add(spellID);
    }
}
