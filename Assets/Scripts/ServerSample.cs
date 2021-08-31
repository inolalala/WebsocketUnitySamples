using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

public class ServerSample : MonoBehaviour
{

    [SerializeField] private Text myPrivateIPAddressText;
    [SerializeField] private Text debugText;

    WebSocketServer server;

    [Header("デバッグ"), SerializeField]
    private string messageStr;


    void Start()
    {
        server = new WebSocketServer(3333);

        server.AddWebSocketService<Echo>("/");

        server.Start();

        myPrivateIPAddressText.text = getLocalIPAddress();

    }

    void Update()
    {
        debugText.text = WebsocketMessageAccesor.StrMessage;
        Debug.Log("メッセージ:"+WebsocketMessageAccesor.StrMessage);
    }

    void OnDestroy()
    {
        server.Stop();
        server = null;
    }



    private string getLocalIPAddress()
    {
        string localIPStr = string.Empty;
        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        {
            socket.Connect("8.8.8.8", 65530);
            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            localIPStr = endPoint.Address.ToString();
        }
        return localIPStr;
    }
}

public class Echo : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Debug.Log("OnMessage");
        Debug.Log(e.Data);
        WebsocketMessageAccesor.StrMessage = e.Data;
        Sessions.Broadcast(e.Data);
        //uGUIService.Instance.StatusText.text = "bbbb";//なんかうまくいかん
        
        
    }
}

public static class WebsocketMessageAccesor
{
    public static string StrMessage = string.Empty;
}
