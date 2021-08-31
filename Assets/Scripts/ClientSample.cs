using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class ClientSample : MonoBehaviour
{
    WebSocket ws;

    void Start()
    {
        ws = new WebSocket("ws://localhost:3333/");

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("WebSocket Message IsBinary: " + e.IsBinary + ", Data: " + e.Data);
            Debug.Log("WebSocket Message IsPing: " + e.IsPing + ", Data: " + e.Data);
            Debug.Log("WebSocket Message IsText: " + e.IsText + ", Data: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };

        ws.Connect();

    }

    void Update()
    {

        if (Input.GetKeyUp("s"))
        {
            ws.Send("Test Message");
        }

    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}
