using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpet : MonoBehaviour, IInstrument
{
    [SerializeField] private List<GameObject> spells = new List<GameObject>(); //Insert on Editor
    private Dictionary<string, List<string>> spellComboMap = new Dictionary<string, List<string>>();
    private Dictionary<string, GameObject> spellPrefabDictonary = new Dictionary<string, GameObject>();
    private List<string> spellList = new List<string>();

    //PROPIEDADES
    public Dictionary<string, List<string>> SpellComboMap => spellComboMap;
    public List<string> SpellList => spellList;

    private float spellSiezeModifier = 1;

    private void Awake()
    {
        foreach (var spell in spells)
        {
            spellComboMap.Add(spell.GetComponent<ISpell>().Id, spell.GetComponent<ISpell>().Combo); //Nombre del Spell >> Lista de Combo
            spellPrefabDictonary.Add(spell.GetComponent<ISpell>().Id, spell); //Nombre del Spell >> Prefab
            spellList.Add(spell.GetComponent<ISpell>().Id); //Lista ordenada con un i que devuelve un Id de cada spell
        }
    }

    public bool Cast(string spellId)
    {
        spellPrefabDictonary.TryGetValue(spellId, out GameObject prefab);
        if (prefab != null)
        {
            //Si es direccional
            if (prefab.GetComponent<IDirectionalSpell>() != null)
            {
                GameObject spell = Instantiate(prefab);
                spell.transform.position = transform.position;
                spell.transform.rotation = transform.rotation;
                spell.transform.localScale = Vector3.one * spellSiezeModifier;
                return true;
            }
            //Si es SelfCasteable
            if (prefab.GetComponent<ISelfCastSpell>() != null)
            {
                prefab.GetComponent<ISelfCastSpell>().SelfCast();
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public void ChangeSpellSiezeModifier(float multiplier)
    {
        spellSiezeModifier = multiplier;
    }

}
