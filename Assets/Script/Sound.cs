using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sound : MonoBehaviour
{
    public AudioClip BGM;
    public AudioClip sound1;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = BGM;
    }
    public void Sound1()
    {
        audioSource.PlayOneShot(sound1);
    }

    public void BGMPlay() //BGMを再生します
    {
        audioSource.Play();
    }
    public void BGMStop() //BGMを止めます
    {
        audioSource.Stop();
    }

    void Update()
    {

    }

}