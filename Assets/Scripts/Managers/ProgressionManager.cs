using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] private List<string> knownSpells = new List<string>();
    public List<string> KnownSpells => knownSpells;
    public UnityEvent<string> OnSpellLearned = new UnityEvent<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddSpellKnown(string spellID)
    {
        knownSpells.Add(spellID);
        OnSpellLearned.Invoke(spellID);
    }

}
