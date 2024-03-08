using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManagerSFX : MonoBehaviour
{
    public static AudioManagerSFX Audio;

    private AudioSource audioSource;

    [Header("Audio Settings")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float sfxVolume;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip stateChangeClip;
    [SerializeField] private AudioClip selectionClip;
    [SerializeField] private AudioClip deselectionClip;
    [SerializeField] private AudioClip roundWinClip;
    [SerializeField] private AudioClip roundLoseClip;
    [SerializeField] private AudioClip roundDrawClip;

    //public static bool IsMuted { get; private set; }

    //public Action OnMuteSettingUpdate;

    private void Awake()
    {
        #region Singleton
        if (Audio != null && Audio != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Audio = this;
        }
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
        #endregion

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //SetMuteSetting(IsMuted);
    }

    public void PlaySoundEffect(SFXType type)
    {
        AudioClip usedClip = stateChangeClip;

        switch (type)
        {
            case SFXType.StateChange:
                usedClip = stateChangeClip;
                break;
            case SFXType.Select:
                usedClip = selectionClip; 
                break;
            case SFXType.Deselect:
                usedClip = deselectionClip;
                break;
            case SFXType.Win:
                usedClip = roundWinClip;
                break;
            case SFXType.Lose:
                usedClip = roundLoseClip;
                break;
            case SFXType.Draw:
                usedClip = roundDrawClip;
                break;
        }

        audioSource.PlayOneShot(usedClip, sfxVolume);
    }
    /*public void PlaySoundEffect(string effect)
    {
        AudioClip usedClip = stateChangeClip;

        switch (effect)
        {
            case "tileSelected":
                usedClip = stateChangeClip;
                break;
            case "tileDeselected":
                usedClip = roundWinClip;
                break;
            case "successfulCheck":
                usedClip = roundLoseClip;
                break;
            case "failedCheck":
                usedClip = roundDrawClip;
                break;
            case "gameWin":
                usedClip = gameWinClip;
                break;
        }

        audioSource.PlayOneShot(usedClip, sfxVolume);

        //Debug.LogFormat("PlaySoundEffect({0})", effect);
    }*/
    /*public void PlayInterfaceEffect(string effect)
    {
        AudioClip usedClip = stateChangeClip;

        switch (effect)
        {
            case "click":
                usedClip = clickedClip;
                break;
            case "slide":
                usedClip = sliderClip;
                break;
        }

        audioSource.PlayOneShot(usedClip, menuFXVolume);
    }*/

    public void SetVolumeSetting()
    {
        audioSource.volume = sfxVolume;
    }
    /*public void SetMuteSetting(bool isMuted)
    {
        IsMuted = isMuted;
        audioSource.mute = isMuted;
    }
    public bool GetMuteSetting()
    {
        return audioSource.mute;
    }*/
}

public enum SFXType { StateChange, Select, Deselect, Win, Lose, Draw }
