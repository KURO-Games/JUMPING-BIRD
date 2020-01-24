using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [HideInInspector]
    public int Kill = 0;
    [SerializeField]
    private GameObject Bird;
    bool DeBug = false; //debug用    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Kill + " / " + GameMgr.Instance.wantKills;

        if(Make.Instance.ZombieCount == GameMgr.Instance.wantKills - 1)
        {
            Make.Instance.makeZonbies = false;
            //ボスゾンビを出す処理
            if(Kill == GameMgr.Instance.wantKills)
            {
                if (GameMgr.Instance.Wave == 3)
                {                    
                    CameraFollow.Instance.AllowBool = true;
                    CameraFollow.Instance.goalCol.isTrigger = true;
                    return;
                }
                Kill = 0;
                StartCoroutine(NextWave(2.5f));
            }
            
            if (DeBug == false)//debug用
            {
                //Debug.Log("ゾンビを倒しました！");
                DeBug = true;
            }
        }
    }

    private IEnumerator NextWave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //「Wave2」みたいなUI表示
        GameMgr.Instance.Wave++;
        GameMgr.Instance.WaveChange();
        Make.Instance.makeZonbies = false;
        yield return null;
    }
}
