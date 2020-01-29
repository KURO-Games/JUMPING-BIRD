using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoleFlags : SingletonMonoBehaviour<GoleFlags>
{
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 ThisPosition()
    {
        return this.gameObject.transform.position;
    }
}
