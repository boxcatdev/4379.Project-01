using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManagerMusic : MonoBehaviour
{
    public static AudioManagerMusic Audio;

    private AudioSource audioSource;

    [Header("Audio Settings")]
    [SerializeField, Range(0.0f, 1.0f)] private float musicVolume;

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
        SetVolumeSetting();
    }

    public void SetVolumeSetting()
    {
        audioSource.volume = musicVolume;
    }
}
