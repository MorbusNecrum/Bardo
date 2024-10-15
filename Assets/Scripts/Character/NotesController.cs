using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    [SerializeField] private List<string> notesPlayed = new List<string>();

    private float lastTimePlayedTimer = 0;
    [SerializeField] private float comboStopTimeBuffer;

    private bool canBasicAttack = true;
    [SerializeField] private float basicAttackCDDuration;
    private float basicAttackCDTimer = 0;

    private IInstrument instrument;
    private AbstractFactory notesFactory;
    [SerializeField] private GameObject noteSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        instrument = GetComponent<IInstrument>();
        notesFactory = GameObject.Find("NotesAbstractFACTORY").GetComponent<AbstractFactory>(); //Referencia al factory de notas
    }

    // Update is called once per frame
    void Update()
    {
        TimeCountersUpdate();
    }
    
    public void PlayNote(string note)
    {
        notesPlayed.Add(note);
        lastTimePlayedTimer = comboStopTimeBuffer;
        Debug.Log($"Played note: {note}");
        AudioManager.Instance.PlayAudioClip(note);
        GameObject visualNote = notesFactory.CreateObjectInAbstractFactory(note);
        visualNote.transform.position = noteSpawnPoint.transform.position;
        SpellsUpdate();
    }

    private void TimeCountersUpdate()
    {
        //Chequea contadores de tiempo y los updatea

        if (lastTimePlayedTimer >= 0)
        {
            lastTimePlayedTimer -= Time.deltaTime;
        }

        if (lastTimePlayedTimer <= 0) //si el buffer de tiempo entre combos paso
        {
            notesPlayed.Clear(); //Se borran las notas tocadas
            lastTimePlayedTimer = 0;
        }

        if(basicAttackCDTimer > 0)
        {
            basicAttackCDTimer -= Time.deltaTime;
            if (basicAttackCDTimer <= 0)
            {
                basicAttackCDTimer = 0;
                canBasicAttack = true;
            }
        }
        
    }

 
    private void SpellsUpdate()
    {
        for(int i = 0; i < instrument.SpellList.Count; i++)
        {
            CheckSpellCast(instrument.SpellList[i]);
        }
    }
    private void CheckSpellCast(string spellId)
    {
       

        instrument.SpellComboMap.TryGetValue(spellId, out List<string> combo);
         if(combo != null)
         {
            if (notesPlayed.Count == combo.Count) //Si toco solo la cantidad de notas del combo
            {
                for (int i = 0; i < combo.Count; i++)
                {
                    if (notesPlayed[i] != combo[i])//Si alguna nota NO es del combo, sale del metodo
                    {
                        return;
                    }
                }
                instrument.Cast(spellId);
            }
         }
       
        
    }

}
