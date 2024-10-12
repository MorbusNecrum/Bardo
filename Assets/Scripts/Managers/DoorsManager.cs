using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    [SerializeField] private List <GameObject> doors;

    public void OpenDoor(int doorIndex)
    {
        doors[doorIndex].GetComponent<Door>().Open();
    }

}
