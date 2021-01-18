using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoinRoomButton : MonoBehaviour
{
    public string roomName = "";
    public TMP_Text text;

    public void UpdateText()
    {
        text.text = roomName;
    }
    public void JoinGame()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
