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
    [SerializeField]
    private GameObject[] zombiePrefabs;
    [SerializeField]
    private float Random1;
    private bool doOnce = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Kill + " / " + GameMgr.Instance.wantKills;
        Debug.Log(GameMgr.Instance.Wave + ":" + GameMgr.Instance.wantKills);
        Debug.Log(Make.Instance.ZombieCount);
        if(Make.Instance.ZombieCount == GameMgr.Instance.wantKills - 1)
        {
            Debug.Log(GameMgr.Instance.Wave + " InBoss");
            Make.Instance.makeZombies = false;            
            if (Kill == GameMgr.Instance.wantKills - 1)
            {
                if (doOnce)
                {
                    doOnce = false;
                    //ボスゾンビを出す処理
                    GameObject _zombie = Instantiate(zombiePrefabs[GameMgr.Instance.Wave - 1], new Vector3(Bird.transform.position.x + Random1, -5f, 1f), Quaternion.identity);

                    switch (GameMgr.Instance.Wave)
                    {
                        case 1:
                            _zombie.gameObject.GetComponent<ZombieState>()._zombieStatus = ZombieState.ZombieStatus.Red;
                            break;
                        case 2:
                            _zombie.gameObject.GetComponent<ZombieState>()._zombieStatus = ZombieState.ZombieStatus.Green;
                            break;
                        case 3:
                            _zombie.gameObject.GetComponent<ZombieState>()._zombieStatus = ZombieState.ZombieStatus.Big;
                            break;
                    }
                }                                                
            }

            if (Kill == GameMgr.Instance.wantKills)
            {
                if (GameMgr.Instance.Wave == 3)
                {
                    CameraFollow.Instance.AllowBool = true;
                    CameraFollow.Instance.goalCol.isTrigger = true;
                    return;
                }
                Kill = 0;
                Make.Instance.ZombieCount = 0;
                doOnce = true;
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
        Make.Instance.makeZombies = true;
        Make.Instance.MakeZombie();
        yield return null;
    }
}
