using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellComboUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> spellDisplay = new List<GameObject>();
    //OBJECT NAME MUST BE SPELL ID
    private Dictionary<string, GameObject> spellsDisplayDict = new Dictionary<string, GameObject>();

    private void Start()
    {
        ProgressionManager.Instance.OnSpellLearned.AddListener(DisplaySpell);//Le pasa el string del ID

        foreach (var spell in spellDisplay)
        {
            spellsDisplayDict.Add(spell.name, spell);
        }

        foreach(string id in ProgressionManager.Instance.KnownSpells)
        {
            spellsDisplayDict.TryGetValue(id, out GameObject spell);
            spell.SetActive(true);
        }
    }

    private void DisplaySpell(string id)
    {
        spellsDisplayDict.TryGetValue(id, out GameObject spell);
        spell.SetActive(true);
    }
}
