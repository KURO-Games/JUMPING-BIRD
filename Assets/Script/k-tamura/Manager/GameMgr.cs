using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// GameManager
/// </summary>
public class GameMgr : SingletonMonoBehaviour<GameMgr>
{
    [SerializeField]//Header("BirdParamater")]
    protected float BirdJumpPower { get; set; }
    public float BirdJumpMaxPosition, BirdJumpMinPosition;
    [Header("ZombieParamater")]
    public int ZombieIt;
    
    private void Start()
    {
        SoundManager.PlayBgm(BGM.Settings);
    }
}
