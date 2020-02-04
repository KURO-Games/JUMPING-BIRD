using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [HideInInspector]
    public int Kill;
    [SerializeField]
    private GameObject Bird;
    bool DeBug = false; //debug用  
    [SerializeField]
    private GameObject[] zombiePrefabs;
    [SerializeField]
    private float Random1;
    private bool doOnce = true;
    [SerializeField]
    private float fadeTime = 1.5f;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Sprite[] waveSprites;
    [SerializeField]
    private Image mainSprite;
    void Start()
    {                
        StartCoroutine(imageFade(fadeTime));        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "×" + Kill;
        //Debug.Log(GameMgr.Instance.Wave + ":" + GameMgr.Instance.wantKills);
        //Debug.Log(Make.Instance.ZombieCount);
        if(Make.Instance.ZombieCount == GameMgr.Instance.wantKills - 1)
        {
            //Debug.Log(GameMgr.Instance.Wave + " InBoss");
            Make.Instance.makeZombies = false;            
            if (Kill == 1)
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

            if (Kill == 0)
            {
                if (GameMgr.Instance.Wave == 3)
                {
                    CameraFollow.Instance.AllowBool = true;
                    CameraFollow.Instance.goalCol.isTrigger = true;
                    return;
                }                
                Make.Instance.ZombieCount = 0;
                doOnce = true;
                //次のWaveに行くまでの時間
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
        GameMgr.Instance.Wave++;
        yield return StartCoroutine(imageFade(fadeTime));        
        GameMgr.Instance.WaveChange();
        Kill = GameMgr.Instance.wantKills;
        yield return null;
    }

    //FadeIn用のCoroutine
    private IEnumerator imageFade(float FadeTime)
    {
        Debug.Log("inFade");
        mainSprite.sprite = waveSprites[GameMgr.Instance.Wave - 1];
        float time = 0f;
        while (canvasGroup.alpha < 1)
        {
            Debug.Log("inFade");
            canvasGroup.alpha = 1f * (time / FadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
        StartCoroutine(TimeForFadeOut(fadeTime));
        yield return null;
    }

    //FadeOut用のCoroutine
    private IEnumerator TimeForFadeOut(float FadeTime)
    {
        float time = 0f;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = 1f - (time / FadeTime);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
        Make.Instance.makeZombies = true;
        Make.Instance.MakeZombie();
        yield return null;
    }
}
