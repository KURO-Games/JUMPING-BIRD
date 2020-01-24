using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameMgr : SingletonMonoBehaviour<GameMgr>
{
    [Header("BirdParamater")]
    public float BirdJumpPower;
    public float BirdJumpMaxPosition, BirdJumpMinPosition;
    [Header("ZombieParamater")]
    public int ZombieIt;

    private void Start()
    {
        SoundManager.PlayBgm(BGM.Settings);
    }
}
