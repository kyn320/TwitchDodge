using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TwitchIRC))]
public class TwitchChat : MonoBehaviour
{
    private TwitchIRC IRC;

    public List<ChatCommand> commandList;

    void Awake()
    {

    }

    void Start()
    {
        IRC = GetComponent<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent += OnChatMsgRecieved;
    }

    ChatCommand FindChatCommand(string _message)
    {
        for (int i = 0; i < commandList.Count; ++i)
        {
            if (_message.Contains(commandList[i].command))
                return commandList[i];
        }
        return null;
    }

    void OnChatMsgRecieved(string _message)
    {
        CreateMessage(_message);
    }

    void CreateMessage(string _message)
    {
        GameObject go = null;
        TextBullet b;
        Transform prevTarget = null;

        if (_message.Contains("!게임규칙"))
        {
            TwitchIRC.Instance.SendChat("일반 공격 : 아무 말이나 채팅");
            TwitchIRC.Instance.SendChat("체력 회복 아이템 : [하트] 를 넣어서 채팅");
            TwitchIRC.Instance.SendChat("함정 생성 : [함정] 를 넣어서 채팅");
            TwitchIRC.Instance.SendChat("이 외의 숨겨진 명령어가 존재합니다.");
        }
        else if (_message.Contains("!개발자"))
        {
            TwitchIRC.Instance.SendChat("영남군(dudskazns)");
        }
        else
        {
            Vector2 pos = ObjectGenerator.Instance.GetRandomEdgePosition();

            ChatCommand chatCommand = FindChatCommand(_message);

            int randMove = Random.Range(0, 3);
            int randDir = Random.Range(0, 2);
            float randSpeed = Random.Range(1f, 10f);

            if (chatCommand != null)
            {
                for (int i = 0; i < chatCommand.source.Length; ++i)
                {
                    go = ObjectPoolManager.Instance.Get(chatCommand.source[i].name);
                    b = go.GetComponent<TextBullet>();

                    if (chatCommand.isText)
                    {
                        if (i != 0)
                            b.SetText(chatCommand.command[i], prevTarget, 0);
                        else
                            b.SetText(chatCommand.command[i], 0);
                    }

                    go.transform.position = pos;

                    prevTarget = go.transform;
                }
            }
            else
            {
                int bulletCount = 0;
                string bulletCategory = "";
                switch (randDir)
                {
                    case 0:
                        // direct
                        bulletCategory = "Head_Direct";
                        break;
                    case 1:
                        //follow
                        bulletCategory = "Head_Target";
                        break;
                }

                switch (randMove)
                {
                    case 0:
                        //direct
                        break;
                    case 1:
                        //follow
                        break;
                    case 2:
                        //curve
                        bulletCategory += "_Curve";
                        break;
                }

                for (int i = 0; i < _message.Length; ++i)
                {
                    if (bulletCount > 7)
                        break;

                    if (_message[i] == ' ')
                        continue;

                    if (i != 0)
                    {
                        go = ObjectPoolManager.Instance.Get("Body");
                        b = go.GetComponent<TextBullet>();
                        b.SetText(_message[i], prevTarget, randSpeed);
                    }
                    else
                    {
                        go = ObjectPoolManager.Instance.Get(bulletCategory);
                        b = go.GetComponent<TextBullet>();
                        b.SetText(_message[i], randSpeed);
                    }

                    go.transform.position = pos;

                    prevTarget = go.transform;
                    ++bulletCount;
                }
            }
        }
    }


}
