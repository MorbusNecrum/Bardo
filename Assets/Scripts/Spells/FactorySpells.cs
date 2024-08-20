using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpells : MonoBehaviour
{
    [SerializeField] private List<ISpell> spells = new List<ISpell>();
    private Dictionary<string, GameObject> spellDic = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    for (int i = 0; i < spells.Count; i++)
    //    {
    //        spellDic.Add(spells[i].id, spells[i]);
    //    }
    //}

}
