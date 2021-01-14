using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainGameCanvas;
    public GameObject sceneCamera;
    public TMP_Text roomName;
    public GameObject disconnectUI;
    private bool off = false;

    public GameObject playerFeed;
    public GameObject feedGrid;

    private void Awake()
    {
        mainGameCanvas.SetActive(true);

        roomName.text = "Room: " + PhotonNetwork.room.Name;
    }

    public void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            off = false;
        }
        else if(!off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            off = true;
        }
    }
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y * randomValue), Quaternion.identity, 0);
        mainGameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }

    private void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(playerFeed, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(feedGrid.transform, false);
        obj.GetComponent<TextMeshProUGUI>().text = player.name.ToString() + " joined";
        obj.GetComponent<TextMeshProUGUI>().color = Color.green;
    }

    private void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(playerFeed, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(feedGrid.transform, false);
        obj.GetComponent<TextMeshProUGUI>().text = player.name.ToString() + " left";
        obj.GetComponent<TextMeshProUGUI>().color = Color.red;
    }
}
