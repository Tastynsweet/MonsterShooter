using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Monster-----------")]
    public AudioClip monsterDescend;
    public AudioClip monsterSpawn;
    public AudioClip monsterDeath;
    public AudioClip monsterAttack;

    [Header("-----------Cannon-----------")]
    public AudioClip cannonFire;
    public AudioClip cannonImpact;

    [Header("-----------Ambient-----------")]
    public AudioClip thunderstorm;
    public AudioClip breathing;
    public AudioClip heartbeat;
    public AudioClip omniousSound;

    [Header("---------Interactive---------")]
    public AudioClip buttonClick;

    public void Start()
    {
        musicSource.clip = thunderstorm;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
