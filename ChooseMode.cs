using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{
    GameObject itemManager, scoreMode, timeMode;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        itemManager = GameObject.Find("ItemManager");
        scoreMode = GameObject.Find("ScoreMode");
        timeMode = GameObject.Find("TimeMode");
        scoreMode.SetActive(true);
        timeMode.SetActive(true);
    }

    //점수모드
    public void ScoreMode()
    {
        //게임모드를 선택하는 즉시 아이템 스폰을 시작해줍니다.
        itemManager.GetComponent<ItemManager>().spawnStart = true;
        //게임모드 선택버튼을 지웁니다.
        scoreMode.SetActive(false);
        timeMode.SetActive(false);
        //점수모드 시작
        gm.score_start = true;
    }

    //시작모드
    public void TimeMode()
    {
        itemManager.GetComponent<ItemManager>().spawnStart = true;
        timeMode.SetActive(false);
        scoreMode.SetActive(false);
        gm.time_start = true;
    }
}
