using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueDialogueButton : MonoBehaviour
{
   public void OnClicked()
   {
        DialogueManager.Instance.DisplayNextSentence();
   }
}
