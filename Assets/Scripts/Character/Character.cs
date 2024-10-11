using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private IInstrument instrument;
    private float siezeChangeTimer = 0;
    private IZone zone;
    private bool hasToRevertSieze = false;


    // Start is called before the first frame update
    void Start()
    {
        instrument = GetComponentInChildren<IInstrument>();
        GetComponent<LifeController>().OnDeath.AddListener(Die);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEffects();
    }

    private void CheckEffects()
    {
        if(siezeChangeTimer > 0)
        {
            siezeChangeTimer -= Time.deltaTime;
            if(siezeChangeTimer <= 0 )
            {
                siezeChangeTimer = 0;
                hasToRevertSieze = true;
     
            }
        }

        if(hasToRevertSieze)
        {
            if (zone == null || zone.Id != "SmallOnly")
            {
                ChangeSieze(1);
                instrument.ChangeSpellSiezeModifier(1);
            }
        }
    }

    public void ChangeSieze(float siezeMultiplier)
    {
        transform.localScale = Vector3.one * siezeMultiplier;
        instrument.ChangeSpellSiezeModifier(siezeMultiplier);
        hasToRevertSieze = false;
    }
    public void ChangeSieze(float siezeMultiplier, float duration)
    {
        if (zone != null)
        {
            //Si se quiere agrandar en una zona q solo puede ser chico, sale.
            if (siezeMultiplier >= 1 && zone.Id == "SmallOnly")
            {
                return;
            }
            //Si quiere hacerse grande donde solo se puede ser mediano, sale
            if (siezeMultiplier > 1 && zone.Id == "MediumOnly")
            {
                return;
            }
        }
            transform.localScale = Vector3.one * siezeMultiplier;
            instrument.ChangeSpellSiezeModifier(siezeMultiplier);
            siezeChangeTimer = duration;
            hasToRevertSieze = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void EnterZone(IZone zoneEntered)
    {
        zone = zoneEntered;
    }

    public void LeftZone(IZone zoneLeft)
    {
        zone = null;
    }
}
