using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private bool isInDialogue = false;


    private MyDynamicQueue<string> senteces = new MyDynamicQueue<string>();

    [Header("(Typing Speed is in chars per second)")]
    [SerializeField] private float typingSpeed;
    private bool isTyping;
    private string typingThisSentece;

    private TMPro.TMP_Text nameText;
    private TMPro.TMP_Text dialogueText;
    private Animator dialogueBoxAnimator;
    public bool IsInDialogue => isInDialogue;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        senteces.InitializeQueue();
    }

    private void Start()
    {
    }
    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.Instance.FreezeTime();

        isInDialogue = true;

        Debug.Log("Started conversation with " +  dialogue.speakerName);

        senteces.Clear();

        dialogueBoxAnimator.SetBool("IsOpen", true);

        //Cambia el nombre de la UI
        nameText.text = dialogue.speakerName;

        //Carga cada frase del dialogo
        foreach(string sentence in dialogue.senteces)
        {
            senteces.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    private IEnumerator TypeSentece(string sentece)
    {
        dialogueText.text = "";
        //Se escribe por char
        foreach(char c in sentece.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(1/typingSpeed); //Corre aunque el Time esté en 0
        }
        isTyping = false;
    }

    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = typingThisSentece;
            isTyping = false;
            return;
        }
        else
        {
            if (senteces.Count() == 0)
            {
                EndDialogue();
                isTyping = false;
                return;
            }

            string sentence = senteces.Dequeue();
            isTyping = true;
            StartCoroutine(TypeSentece(sentence));
            typingThisSentece = sentence;
        }
    }
    public void EndDialogue()
    {
        dialogueBoxAnimator.SetBool("IsOpen", false);
        typingThisSentece = null;
        Debug.Log("End of conversation");
        isInDialogue = false;
        GameManager.Instance.UnfreezeTime();
    }

    public void GetReferences()
    {
        nameText = GameObject.Find("SpeecherName").GetComponent<TMPro.TMP_Text>();
        dialogueText = GameObject.Find("Dialogue").GetComponent<TMPro.TMP_Text>();
        dialogueBoxAnimator = GameObject.Find("DialogueBox").GetComponent<Animator>();

        dialogueBoxAnimator.SetBool("IsOpen", false);
        isTyping = false;
    }
}
