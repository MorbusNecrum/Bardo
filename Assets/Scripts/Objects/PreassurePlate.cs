using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class PreassurePlate : MonoBehaviour
{
    [SerializeField] int connectedDoorIndex;
    private int collsOnPlate = 0;
    private List<Door> linkedDoors = new List<Door>();
    private Animator animator;

    private void Start()
    {
        //Encuentra todas las puertas
        Door[] temp = FindObjectsOfType<Door>();
        foreach (Door door in temp)
        {
            //Se guarda las puertas que controla
            if(door.DoorIndex == connectedDoorIndex)
            {
                linkedDoors.Add(door);
            }
        }
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collsOnPlate == 0) //Si es el primer objeto en pisar
        {
            foreach (Door door in linkedDoors)
            {
                door.Open();
            }
                animator.SetBool("IsPressed", true);
            AudioManager.Instance.PlayAudioClip("PreassurePlateOn");
        }
        collsOnPlate++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collsOnPlate--;
        if(collsOnPlate == 0)//Si no queda ningun objeto en la plate
        {
            foreach (Door door in linkedDoors)
            {
                door.Close();
            }
            animator.SetBool("IsPressed", false);
            AudioManager.Instance.PlayAudioClip("PreassurePlateOff");
        }
    }
}
