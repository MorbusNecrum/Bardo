using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int doorIndex;
    public int DoorIndex => doorIndex;
    public void Open()
    {
        if (gameObject.activeSelf)
        {
            AudioManager.Instance.PlayAudioClip("DoorOpens");
            gameObject.SetActive(false);
        }
    }
    public void Close()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
}
