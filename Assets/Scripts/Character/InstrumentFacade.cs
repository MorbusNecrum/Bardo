using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentFacade : MonoBehaviour
{
    private NotesController notesController;
    private void Start()
    {
        notesController = GetComponent<NotesController>();
    }
    public void PlayNote(string note)
    {
        notesController.PlayNote(note);
    }
}
