using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string soundID;
}

public class AudioManager : MonoBehaviour
{

    #region    "Variables"
    // Singleton //
    public static AudioManager Instance { get; private set; }
    // Event //

    // Audio //
    [SerializeField] private Sound[] GameSounds;
    [SerializeField] private AudioSource SoundAudioSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioClip[] _bgm;// 0: Main Menu, 1: Training screen, 2: Mission //
                                                                  //[SerializeField] private AudioClip[] _sfx = new AudioClip[3]; 

    #endregion "Variables"
    #region  "Main Methods"
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    //void Start()
    //{
    //    SetBGM(0);
    //}
    #endregion  "Main Methods"   
    #region    "Custom Methods"

    //public void SetBGM(int Int_Index)
    //{
    //    Instance._bgmSource.clip = _bgm[Int_Index];
    //    Instance._bgmSource.Play();
    //}

    public AudioClip GetAudioClipFromID(string id)
    {
        for (int i = 0; i < GameSounds.Length; i++)
        {
            var sound = GameSounds[i];
            if (sound.soundID == id)
            {
                return sound.clip;
            }
        }
        Debug.Log($"No se pudo encontrar el id {id}");
        return default;
    }

    public void PlayAudioClip(string id)
    {
        AudioClip clipToPlay = GetAudioClipFromID(id);

        if (clipToPlay == default)
        {
            return;
        }
        if (clipToPlay != null)
        {
            SoundAudioSource.PlayOneShot(clipToPlay);
        }
    }

    /*public void PlaySFX(int Int_Index)
    {
        Instance._sfxSource.clip = _sfx[Int_Index];
        Instance._sfxSource.Play();
    }*/

    #endregion "Custom Methods"


}

