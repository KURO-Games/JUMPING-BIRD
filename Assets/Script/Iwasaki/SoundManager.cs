﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    ClearField,
    Clear,
    GameOver,
    Settings,
    Title,
    Urgent,
}

public enum SE
{
    AttackBuilding,
    AttackZombie,
    SPReady,
    Damage,
}

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    [Range(0.0f, 1.0f)]
    public float volume;
}

[DefaultExecutionOrder(-1)]
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    public Sound[] bgmSound;
    public Sound[] seSound;

    public Dictionary<BGM, Sound> bgmdic = new Dictionary<BGM, Sound>();
    public Dictionary<SE, Sound> sedic = new Dictionary<SE, Sound>();

    [SerializeField]
    private AudioSource audioSource_BGM;
    [SerializeField]
    private AudioSource audioSource_SE;

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

   
    private void BgmRegister()
    {
        for (int i = 0; i < bgmSound.Length; i++)
        {
            bgmdic.Add((BGM)i, bgmSound[i]);
        }
    }

    private void SeRegister()
    {
        for (int i = 0; i < seSound.Length; i++)
        {
            sedic.Add((SE)i, seSound[i]);
        }
    }

    public static void PlayBgm(BGM key)
    {
        Sound sound = Instance.bgmdic[key];
        AudioClip clip = sound.clip;
        float volume = sound.volume;
        //Debug.Log("<color=blue>" + clip.name + ":" + volume + "</color>");
        Instance.audioSource_BGM.clip = clip;
        Instance.audioSource_BGM.volume = volume;
        Instance.audioSource_BGM.loop = true;
        Instance.audioSource_BGM.Play();
    }

    public void PlaySe(SE key)
    {
        Sound sound = sedic[key];
        AudioClip clip = sound.clip;
        float volume = sound.volume;
        //Debug.Log("<color=blue>" + clip.name + ":" + volume + "</color>");
        audioSource_SE.volume = volume;
        audioSource_SE.PlayOneShot(clip);
    }

    public void FadeOutBgm(float fadeTime)
    {
        StartCoroutine(FadeOut(fadeTime));
    }

    private IEnumerator FadeOut(float time)
    {
        float _time = time;
        float vol = audioSource_BGM.volume;
        while(_time > 0f)
        {
            _time -= Time.deltaTime;
            audioSource_BGM.volume = vol * _time / time;
            yield return null;
        }
        audioSource_BGM.Stop();
        audioSource_BGM.clip = null;
        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        BgmRegister();
        SeRegister();

        //Debug.Log("LoadBGMCount:" + bgmdic.Count);
        //Debug.Log("LoadSECount:" + sedic.Count);
    }
}