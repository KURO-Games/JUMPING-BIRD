using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingColiderAnimator : MonoBehaviour
{
    enum BoxColiders
    {
        BuildingLeft,
        BuildingRight,
        BuildingUnder
    }
    [SerializeField, Header("アニメーション")]
    GameObject Building;
    [SerializeField, Header("ビルBoxColider設定")]
    BoxColiders BoxColiderChoice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bird")
        {
            SoundManager.Instance.PlaySe(SE.AttackBuilding);
            Building.GetComponent<Animator>().SetTrigger(BoxColiderChoice.ToString());
        }
    }

}
