using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private GameObject roomButton;

    [SerializeField]
    private Transform content;

    public List<RoomInfo> roomList = new List<RoomInfo>();

    public List<string> roomNames = new List<string>();
   
    public void UpdateRoomList()
    {
        ClearRoomsList();
        GetRoomNames();
        AddRoomButtons();
    }

    private void ClearRoomsList()
    {
        if (content.childCount > 0)
        {
            foreach (GameObject roomName in content)
            {
                Destroy(roomName);
            }
        }
        else
        {
            return;
        }
    }

    private void GetRoomNames()
    {
        Debug.Log(PhotonNetwork.GetRoomList().Length);

        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            roomNames.Add(room.Name);
        }
    }

    private void AddRoomButtons()
    {
        int length = 0;

        for (int i = 0; i < length; i++)
        {
            Instantiate(roomButton, content);
            roomButton.GetComponent<JoinRoomButton>().UpdateText();
        }
    }

   


}
    
       

