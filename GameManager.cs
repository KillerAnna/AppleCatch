using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Text timeText, pointText, gameOver, score;
    GameObject itemManager;

    public float time;
    int point;
    //시작할때 모드들을 꺼줍니다.
    public bool time_start = false;
    public bool score_start = false;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time").GetComponent<Text>();
        pointText = GameObject.Find("Point").GetComponent<Text>();
        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        itemManager = GameObject.Find("ItemManager");
    }

    // Update is called once per frame
    void Update()
    {
        //모드가 chooseMode스크립트로부터 신호를 받는 즉시 모드 시작
        if(time_start)
        {
            TimeMode();
        }
        if(score_start)
        {
            ScoreMode();
        }
        // 시간이 0이 될때
        if (time <= 0)
        {
            //시간과 점수쌓기 ui를 꺼주고 아이템스폰도 꺼줍니다.
            time_start = false;
            score_start = false;

            //결과출력
            gameOver.text = "GAMEOVER";
            score.text = "쌓은점수 : " + point.ToString() + "Point";
            itemManager.SetActive(false);
        }
    }
    //시간모드
    public void TimeMode()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("F1");
        pointText.text = point.ToString() + "Point";
        if (time <= 40 && time > 30)
        {
            //itemmanager스크립트로 속도값을 전달하기
            itemManager.GetComponent<ItemManager>().speed = -0.02f;
        }
        else if (time <= 30 && time > 20)
        {
            itemManager.GetComponent<ItemManager>().speed = -0.03f;
        }
        else if (time <= 20)
        {
            itemManager.GetComponent<ItemManager>().speed = -0.04f;
        }
    }
    //점수모드
    public void ScoreMode()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("F1");
        pointText.text = point.ToString() + " Point";
        if (point > 200 && point < 400)
        {
            itemManager.GetComponent<ItemManager>().speed = -0.02f;
        }
        else if (point >= 400 && point < 600)
        {
            itemManager.GetComponent<ItemManager>().speed = -0.03f;
        }
        else if (point >= 600)
        {
            itemManager.GetComponent<ItemManager>().speed = -0.04f;
        }
    }

    public void GetApple()
    {
        point += 100;
    }
    public void GetBomb()
    {
        point /= 2;
    }
}
