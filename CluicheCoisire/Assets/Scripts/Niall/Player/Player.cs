using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public GameObject playerCamera;
    public SpriteRenderer sr;
    public TMP_Text playerNameText;

    public float moveSpeed;

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            playerNameText.text = PhotonNetwork.playerName;
            playerNameText.color = Color.blue;
        }
        else
        {
            playerNameText.text = photonView.owner.name;
            playerNameText.color = Color.red;
        }
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

   
}
