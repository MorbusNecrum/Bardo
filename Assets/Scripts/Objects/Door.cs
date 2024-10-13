using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        AudioManager.Instance.PlayAudioClip("DoorOpens");
        Destroy(gameObject);
    }
}
