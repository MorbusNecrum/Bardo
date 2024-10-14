using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IFactoryzable
{
    [SerializeField] private string prefabID;
    [SerializeField] private int connectedDoorIndex;
    public string PrefabID => prefabID;

    private List<Door> linkedDoors = new List<Door>();

    private void Start()
    {
        //Encuentra todas las puertas
        Door[] temp = FindObjectsOfType<Door>();
        foreach (Door door in temp)
        {
            //Se guarda las puertas que controla
            if (door.DoorIndex == connectedDoorIndex)
            {
                linkedDoors.Add(door);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudioClip("PickUp");
            foreach (Door door in linkedDoors)
            {
                door.Open();
            }
            Destroy(gameObject);
        }
    }
}
