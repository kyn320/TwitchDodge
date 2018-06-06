using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Camera mainCam;
    public PlayerController player;
    public UIInGame ui;

    public bool isPlay = false;

    public float playTime = 0;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(StartCounter());
    }

    IEnumerator StartCounter()
    {
        //for (int i = 0; i < 5; ++i)
        //{
        //    TwitchIRC.Instance.SendChat("시작까지 " + (5 - i) + " 초 남았습니다!");
        //
        //    switch (i)
        //    {
        //        case 0:
        //            TwitchIRC.Instance.SendChat("체력 회복 아이템 : [하트] 를 넣어서 채팅");
        //            TwitchIRC.Instance.SendChat("함정 생성 : [함정] 를 넣어서 채팅");
        //            break;
        //        //case 1:
        //        //    break;
        //        //case 2:
        //        //    TwitchIRC.Instance.SendChat("이 외의 숨겨진 명령어가 존재합니다.");
        //        //    break;
        //        case 3:
        //            TwitchIRC.Instance.SendChat("도움말 보기 : !게임규칙 ");
        //            break;
        //    }
        //    yield return new WaitForSeconds(1f);
        //}
        //TwitchIRC.Instance.SendChat("게임 시작! 채팅으로 공격하세요!");
        yield return null;
        isPlay = true;
    }

    private void Update()
    {
        if (!isPlay)
            return;

        playTime += Time.deltaTime;
        //ui.timer.UpdateTimer(playTime);
    }

    public void EndGame()
    {
        isPlay = false;
        ui.endPanel.View();
    }

}
