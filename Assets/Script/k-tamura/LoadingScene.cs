using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private AsyncOperation async;
    [SerializeField] GameObject error;
    [SerializeField]
    private GameObject loadUI;
    [SerializeField]
    private Slider slider;
    string nextScene;
    bool _error;
    public void NextScene()
    {
        loadUI.SetActive(true);
        StartCoroutine("Loaddata");
    }
    IEnumerator Loaddata()
    {
        Time.timeScale = 1.0f;
        SceneLoadManager.FadeIn();

        nextScene = SceneLoadManager.NextScene;
        async = SceneManager.LoadSceneAsync(nextScene);
        if (async != null)
        {
            while (!async.isDone)
            {
                var progressVal = Mathf.Clamp01(async.progress / 0.9f);
                //slider.value = progressVal;
                yield return null;
            }
        }
        else
        {
            Debug.LogError("シーンが見つかりません。");
            _error = true;
        }
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Loaddata());
    }

    private void OnGUI()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (_error)
        {
            error.SetActive(true);
        }
    }
}
