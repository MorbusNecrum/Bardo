using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstrument 
{
    Dictionary<string, List<string>> SpellComboMap { get; }
    List<string> SpellList { get; }
    bool Cast(string spellId);
}
