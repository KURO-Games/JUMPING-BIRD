using UnityEngine;
/// <summary>
/// SoundManager InitializeSceneにて実装予定
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
