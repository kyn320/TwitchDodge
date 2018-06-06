using UnityEngine;
using UnityEngine.Events;
using System;
using System.IO;
using System.Net.Sockets;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

public class TwitchIRC : Singleton<TwitchIRC>
{
    public string oauth;
    public string nickName;
    public string channelName;
    private string server = "irc.chat.twitch.tv";
    private int port = 6667;

    private TcpClient client;
    private StreamReader reader;
    private StreamWriter writer;

    public UnityAction<string> messageRecievedEvent;

    void Start()
    {
        oauth = PlayerPrefs.GetString("oauth","");
        channelName = nickName = PlayerPrefs.GetString("nickName","");
        Connect();
    }

    void Update()
    {
        if (!client.Connected)
            Connect();

        ReadChat();
    }

    private void Connect()
    {
        client = new TcpClient(server, port);

        reader = new StreamReader(client.GetStream());
        writer = new StreamWriter(client.GetStream());

        writer.WriteLine("PASS " + oauth);
        writer.WriteLine("NICK " + nickName);
        writer.WriteLine("USER " + nickName + " 8 * :" + nickName);
        writer.WriteLine("JOIN #" + channelName);

        writer.Flush();

//        print("connect");
    }

    private void ReadChat()
    {
        if (client.Available > 0)
        {
            var message = reader.ReadLine();

            if (message.Contains("PRIVMSG"))
            {
                //Get the users name by splitting it from the string
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //Get the users message by splitting it from the string
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);

//               print(string.Format("{0} : {1}", chatName, message));

                MessageAction(message);
            }
        }
    }

    public void SendChat(string _message)
    {
        writer.WriteLine("PRIVMSG #" + channelName + " :" + _message);
        writer.Flush();

//        print("send " + _message);
    }

    private void MessageAction(string _message)
    {
        if (!GameManager.Instance.isPlay)
            return;

        messageRecievedEvent.Invoke(_message);
    }


}
