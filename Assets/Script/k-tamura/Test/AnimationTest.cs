using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
/// <summary>
/// アニメーション確認用
/// </summary>
public class AnimationTest : MonoBehaviour
{
    [SerializeField]
    private GameObject AnimationObject;
    [SerializeField]
    private string[] animationName;
    private int _num;

    // Start is called before the first frame update
    public void NextButton()
    {
        if (_num >= animationName.Length) _num = 0;
        AnimationObject.GetComponent<Animator>().SetTrigger(animationName[_num]);
        _num++;
    }
    public void ResetButton()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().name));
    }

}
