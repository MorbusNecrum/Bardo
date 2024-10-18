using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheet : MonoBehaviour
{
    [SerializeField] private string spellToUnlockID = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudioClip("PickUp");
            if (spellToUnlockID != null)
            {
                ProgressionManager.Instance.AddSpellKnown(spellToUnlockID);
            }
            Destroy(gameObject);
        }
    }
}
