using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Yes : MonoBehaviour
{
    public void OnClick()
    {
        SceneLoadManager.LoadScene("Title");
        Time.timeScale = 1;
    }
}
