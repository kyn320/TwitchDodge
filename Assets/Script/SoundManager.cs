using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public List<AudioClip> audioList;

    public List<AudioClip> bgmList;

    AudioSource[] audioSource = new AudioSource[2];

    void Awake()
    {
        audioSource = GetComponents<AudioSource>();
    }

    public void Start()
    {
        PlayBGM(bgmList[Random.Range(0, bgmList.Count)].name);
    }

    public void PlayBGM(string _name)
    {
        audioSource[0].Stop();
        audioSource[0].clip = bgmList.Find(item => item.name == _name);
        audioSource[0].Play();
    }

    public void PlaySE(string _name)
    {
        audioSource[1].PlayOneShot(audioList.Find(item => item.name == _name));
    }

}
