using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameMgr : SingletonMonoBehaviour<GameMgr>
{
    [Header("BirdParamater")]
    public float BirdJumpPower, BirdJumpMaxPosition, BirdJumpMinPosition;
}
