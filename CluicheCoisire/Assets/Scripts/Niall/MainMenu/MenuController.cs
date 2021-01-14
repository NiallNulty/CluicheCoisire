using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameCanvas;
    [SerializeField] private GameObject MainMenuCanvas;

    [SerializeField] private TMP_InputField UsernameInput;
    [SerializeField] private TMP_InputField CreateGameInput;
    [SerializeField] private TMP_InputField JoinGameInput;
    [SerializeField] private TMP_Dropdown GameTypeDropdown;

    [SerializeField] private GameObject SetUsernameButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
        Debug.Log("connected");
    }
    private void Start()
    {
        UsernameCanvas.SetActive(true);
    }
    private void OnConnectedToServer()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("connected");
    }
    public void ChaneUsernameInput()
    {
        if (UsernameInput.text.Length < 3)
        {
            SetUsernameButton.SetActive(false);
        }
        else
        {
            SetUsernameButton.SetActive(true);
        }
    }
    public void SetUsername()
    {
        UsernameCanvas.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text.ToString();
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(GenerateRoomName(), new RoomOptions() { maxPlayers = 4 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text.ToString(), roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        if (GameTypeDropdown.value == 0)
        {
            PhotonNetwork.LoadLevel("Niall");
        }

        if (GameTypeDropdown.value == 1)
        {
            PhotonNetwork.LoadLevel("James");
        }

        if (GameTypeDropdown.value == 2)
        {
            PhotonNetwork.LoadLevel("Michael");
        }

        if (GameTypeDropdown.value == 3)
        {
            PhotonNetwork.LoadLevel("Ryan");
        }
    }

    private string GenerateRoomName()
    {
        int length = 4;

        // creating a StringBuilder object()
        StringBuilder str_build = new StringBuilder();
        System.Random random = new System.Random();

        char letter;

        for (int i = 0; i < length; i++)
        {
            double flt = random.NextDouble();
            int shift = Convert.ToInt32(Math.Floor(25 * flt));
            letter = Convert.ToChar(shift + 65);
            str_build.Append(letter);
        }
        return str_build.ToString();
    }
}
