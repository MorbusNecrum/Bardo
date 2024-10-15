using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private int healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IHealeable>().GetHeal(healAmount);
            AudioManager.Instance.PlayAudioClip("PickUp");
            Destroy(gameObject);
        }
    }
}
