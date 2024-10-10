using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NoticeSound : MonoBehaviour
{
    [SerializeField] private string soundId;
    [SerializeField] private float soundCDTimer;
    private float timer = 0;

    public void PlayNoticeSound()
    {
        if (timer <= 0) 
        {
            AudioManager.Instance.PlayAudioClip(soundId);
            timer = soundCDTimer;
        }
    }

    private void Update()
    {
        //Hace el conteo de CD
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }


}
