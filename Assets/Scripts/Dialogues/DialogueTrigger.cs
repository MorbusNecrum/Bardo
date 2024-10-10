using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour , IInteractable
{
    [SerializeField] private Dialogue dialogue;
    [Header("Meta Button not required")]
    [SerializeField] private GameObject metaButton;

    public void Interact()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().EnterInteractableZone(this);
            if(metaButton != null)
            {
                metaButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().LeftInteractableZone(this);
            if (metaButton != null)
            {
                metaButton.SetActive(false);
            }
        }
    }

    public void ChangeDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }
}
