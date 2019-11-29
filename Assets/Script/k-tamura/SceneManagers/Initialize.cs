using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        SceneLoadManager.LoadScene("Title");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
