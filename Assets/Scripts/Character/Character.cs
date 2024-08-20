using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private IInstrument instrument;
    private float siezeChangeTimer = 0;

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
                ChangeSieze(1);
                instrument.ChangeSpellSiezeModifier(1);
            }
        }
    }

    public void ChangeSieze(float siezeMultiplier)
    {
        transform.localScale = Vector3.one * siezeMultiplier;
        instrument.ChangeSpellSiezeModifier(siezeMultiplier);
    }
    public void ChangeSieze(float siezeMultiplier, float duration)
    {
        transform.localScale = Vector3.one * siezeMultiplier;
        instrument.ChangeSpellSiezeModifier(siezeMultiplier);
        siezeChangeTimer = duration;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
