using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainGameCanvas;
    public GameObject sceneCamera;

    private void Awake()
    {
        mainGameCanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y * randomValue), Quaternion.identity, 0);
        mainGameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }
}
