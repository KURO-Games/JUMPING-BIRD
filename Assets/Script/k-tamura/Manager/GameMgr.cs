using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// GameManager
/// </summary>
public class GameMgr : SingletonMonoBehaviour<GameMgr>
{
    [Header("BirdParamater")]
    public float BirdJumpPower;
    public float BirdJumpMaxPosition, BirdJumpMinPosition;
    [Header("ZombieParamater")]
    public int ZombieIt;

    [HideInInspector]
    public int Wave = 1;//今のステージレベル
    [HideInInspector]
    public int wantKills = 0;//必要なゾンビを倒す数

    [SerializeField]
    private int Wave1Zombies;
    [SerializeField]
    private int Wave2Zombies;
    [SerializeField]
    private int Wave3Zombies;

    private void Start()
    {
        WaveChange();
        SoundManager.PlayBgm(BGM.Settings);
    }

    private void Update()
    {
        
    }

    public void WaveChange()
    {
        if (Wave == 1)
        {
            wantKills = Wave1Zombies;
        }

        if (Wave == 2)
        {
            wantKills = Wave2Zombies;
        }

        if (Wave == 3)
        {
            wantKills = Wave3Zombies;
        }
    }
}
