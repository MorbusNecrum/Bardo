using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstrument 
{
    Dictionary<string, List<string>> SpellComboMap { get; }
    List<string> SpellList { get; }

    void ChangeSpellSiezeModifier(float multiplier);

    bool Cast(string spellId);
}
