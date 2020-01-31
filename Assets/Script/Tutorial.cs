using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Sprite TutorialImage2;
    private int TutorialImage = 1;

    private bool ScaneLoading = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TutorialImage == 1)
            {
                GetComponent<Image>().sprite = TutorialImage2;
                TutorialImage = 2;
            } else if(TutorialImage == 2)
            {
                StartCoroutine("NextScens");
            }
        }
    }

    private IEnumerator NextScens()
    {
        yield return new WaitUntil(() => !ScaneLoading);
        SceneLoadManager.LoadScene("MainGame");
        Debug.Log("abcdefg");
        ScaneLoading = true;
    }
}
