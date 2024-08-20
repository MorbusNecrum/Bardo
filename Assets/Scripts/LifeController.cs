using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour, IDamageable
{
    
    [SerializeField] private int maxHealth;
    private bool isAlive;
    public bool IsAlive => isAlive;
    [SerializeField] private int currentHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField] private string hurtSoundId = null;

    public UnityEvent OnDeath = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void GetDamage(int damage)
    {
        if (IsAlive)
        {
            currentHealth -= damage;
            if(hurtSoundId != null)
            {
                AudioManager.Instance.PlayAudioClip(hurtSoundId);
            }

                if(currentHealth <= 0)
                {
                    currentHealth = 0;
                    isAlive = false;
                    OnDeath.Invoke();
                }
        }
    }

}
