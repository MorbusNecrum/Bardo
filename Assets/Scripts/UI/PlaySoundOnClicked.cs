using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClicked : MonoBehaviour
{
    public void PlaySound(string id)
    {
        AudioManager.Instance.PlayAudioClip(id);
    }
}
