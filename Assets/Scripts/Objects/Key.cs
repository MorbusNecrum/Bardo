using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IFactoryzable
{
    [SerializeField] private string prefabID;
    [SerializeField] private int indexOfDoorThatItOpens;
    public string PrefabID => prefabID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudioClip("PickUp");
            GameObject.Find("DoorsMANAGER").GetComponent<DoorsManager>().OpenDoor(indexOfDoorThatItOpens);
            Destroy(gameObject);
        }
    }
}
