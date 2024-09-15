using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WizardCastState : MonoBehaviour, IState
{
    private string id = "Cast";
    public string Id => id;

    private UnityEvent<string> onChangeStateTo = new UnityEvent<string>();
    public UnityEvent<string> OnChangeStateTo => onChangeStateTo;

    //EDITABLES
    [SerializeField] private GameObject spellPrefab;
    [SerializeField] private float spellCD;
    [SerializeField] private float spellCDTimer;

    //EXTRAS
    private Wizard wizard;
    public void Enter()
    {
        if (wizard == null)
        {
            wizard = GetComponent<Wizard>();
        }

        Debug.Log("Entered Wizard Cast State");

    }

    public void Exit()
    {

    }

    public void UpdateState()
    {
        if (wizard.PlayerDistance > wizard.CastingDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Chase");
        }

        CastSpell();

    }

    private void CastSpell()
    {
        Instantiate(spellPrefab, transform.position, Quaternion.identity);
    }
}
