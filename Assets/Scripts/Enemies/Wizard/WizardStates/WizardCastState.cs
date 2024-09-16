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

        //Si ya puede castear
        if (wizard.CastCDTimer == 0)
        {
            CastSpell();//castea
            wizard.CastCDTimer = wizard.CastCD;//le pone el CoolDown, el wizard script se encarga del timer.
        }
    }

    private void CastSpell()
    {
        GameObject spell = Instantiate(spellPrefab);
        spell.transform.position = transform.position;
        //Calcula la direccion del spell y lo settea
        float angle = Mathf.Atan2(wizard.Direction.y, wizard.Direction.x) * Mathf.Rad2Deg;
        spell.transform.eulerAngles = (new Vector3(0, 0, angle));
    }
}
