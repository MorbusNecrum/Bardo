using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private LifeController playerLifeController;

    private void Start()
    {
        playerLifeController = GameObject.Find("Player").GetComponent<LifeController>();
        playerLifeController.OnLifeChanged.AddListener(SetHealth);
        playerLifeController.OnMaxHealthChanged.AddListener(SetMaxHealth);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }
   
}
