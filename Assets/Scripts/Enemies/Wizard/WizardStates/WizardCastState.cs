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
    private Wizard self;
    private bool canChangeDirection;
    private Animator animator;

    public void Enter()
    {
        if (self == null)
        {
            self = GetComponent<Wizard>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("IsWalking", false);
        Debug.Log("Entered Wizard Cast State");
        canChangeDirection = true;
    }

    public void Exit()
    {
        canChangeDirection = false;
    }

    public void UpdateState()
    {
        if (self.PlayerDistance > self.CastingDistance)
        {
            Exit();
            onChangeStateTo.Invoke("Chase");
        }

        //Si ya puede castear
        if (self.CastCDTimer == 0)
        {
            CastSpell();//castea
            self.CastCDTimer = self.CastCD;//le pone el CoolDown, el wizard script se encarga del timer.
        }
    }

    private void CastSpell()
    {
        GameObject spell = Instantiate(spellPrefab);
        spell.transform.position = transform.position;
        //Calcula la direccion del spell y lo settea
        float angle = Mathf.Atan2(self.Direction.y, self.Direction.x) * Mathf.Rad2Deg;
        spell.transform.eulerAngles = (new Vector3(0, 0, angle));
    }
    private void FixedUpdate()
    {
        if (canChangeDirection)
        {
            //CAMBIO DE ORIENTACION
            if (self.Direction.x < 0) //va para la izq
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);

            }
            else if (self.Direction.x > 0) //va para la derecha
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
    }
}
