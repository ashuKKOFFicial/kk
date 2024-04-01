using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public TMP_InputField create;
    public TMP_InputField join;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(create.text);

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(join.text);

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
