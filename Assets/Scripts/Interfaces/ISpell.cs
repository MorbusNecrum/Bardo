using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell 
{
    string Id { get; }
    List<string> Combo {  get; }
}
