using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour, IDamageable, IHealeable
{
    
    [SerializeField] private int maxHealth;
    private bool isAlive;
    public bool IsAlive => isAlive;
    [SerializeField] private int currentHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField] private string hurtSoundId = null;
    [SerializeField] private string diedSoundId = null;

    private FlashEffect flashEffect;

    public UnityEvent<int> OnLifeChanged = new UnityEvent<int>();
    public UnityEvent<int> OnMaxHealthChanged = new UnityEvent<int>();
    public UnityEvent OnDeath = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        OnMaxHealthChanged.Invoke(maxHealth);
        currentHealth = maxHealth;
        OnLifeChanged.Invoke(currentHealth);
        TryGetComponent<FlashEffect>(out FlashEffect fx);
        flashEffect = fx;
    }
    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        OnMaxHealthChanged.Invoke(maxHealth);
    }
    public void Revive(int health)
    {
        currentHealth = health;
        isAlive = true;
        OnLifeChanged?.Invoke(currentHealth);
        if (flashEffect != null)//Cancela Animacion de Flash
        {
            flashEffect.CancelFlash();
        }
        gameObject.SetActive(true);
    }
    public void ReviveAtMaxHealth()
    {
        currentHealth = maxHealth;
        isAlive = true;
        OnLifeChanged?.Invoke(currentHealth);
        if (flashEffect != null)//Cancela Animacion de Flash
        {
            flashEffect.CancelFlash();
        }
        gameObject.SetActive(true);
    }
    public void GetDamage(int damage)
    {
        if (IsAlive)
        {
            if (damage > 0)
            {
                currentHealth -= damage;
                OnLifeChanged.Invoke(currentHealth);
                if (hurtSoundId != null)//Sonido de damage
                {
                    AudioManager.Instance.PlayAudioClip(hurtSoundId);
                }
                if(flashEffect != null)//Animacion de Flash
                {
                    flashEffect.Flash();
                }
                if (currentHealth <= 0)//Muere
                {
                    currentHealth = 0;
                    isAlive = false;
                    if (diedSoundId != null)//Sonido de muerte
                    {
                        AudioManager.Instance.PlayAudioClip(diedSoundId);
                    }
                    gameObject.SetActive(false);
                    OnDeath.Invoke();
                }
            }
        }
    }

    public void GetHeal(int amount)
    {
        if (IsAlive)
        {
            if (amount > 0)
            {
                currentHealth += amount;

                if (currentHealth > maxHealth)//Se paso
                {
                    currentHealth = maxHealth;
                }
                    OnLifeChanged.Invoke(currentHealth);
            }
        }
    }
}
