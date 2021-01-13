using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject SetUsernameButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
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
        PhotonNetwork.playerName = UsernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { maxPlayers = 4 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Niall");
    }

}
