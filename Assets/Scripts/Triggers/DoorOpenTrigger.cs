using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] int connectedDoorIndex;
    private List<Door> linkedDoors = new List<Door>();
    private Animator animator;
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
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Door door in linkedDoors)
            {
                door.Open();
            }
            animator.SetBool("IsPressed", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsPressed", false);
        }
    }
}
