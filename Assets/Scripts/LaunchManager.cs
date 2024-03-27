using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    byte maxPlayerPerRoom = 4;
    bool isConnecting;
    public TextMeshProUGUI feedback;
    //public TextMeshProUGUI playerName;
    string gameVersion = "1";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ConnectNetwork()
    {
        feedback.text = "";
        isConnecting = true;

        //PhotonNetwork.NickName = playerName.text;

        if (PhotonNetwork.IsConnected)
        {
            feedback.text += "\n Joining Room";
            PhotonNetwork.JoinRandomRoom();
        }

        else
        {
            feedback.text += "\nConnecting....";
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }

    }


    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            feedback.text += "\nOnConnectedToMaster..";
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        feedback.text += "\nFailed to join random room.";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayerPerRoom });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        feedback.text += "\n Disconnected beacuse " + cause;
        isConnecting = false;
    }


    public override void OnJoinedRoom()
    {
        feedback.text += "\nJoined Room with " + PhotonNetwork.CurrentRoom.PlayerCount + " Players";
        PhotonNetwork.LoadLevel("CarAIWaypointBasedAashu");
    }
 
}
