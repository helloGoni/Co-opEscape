using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    //UI
    public TMP_InputField roomNameInput;
    
    void Start()
    {
        Screen.SetResolution(960,540,false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JoinOrCreateRoom() {
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(roomNameInput.text,roomOption,null);
    }

    public void JoinRoom() {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }
    public override void OnJoinedRoom() {
        roomNameInput.text="";
    }
    public override void OnJoinRoomFailed(short returnCode, string message) {
        print("방이 없나봐요");
    }
    public void CreateRoom() {
        string name = MakeRoomNumber();
        PhotonNetwork.CreateRoom(name, new RoomOptions {MaxPlayers = 2});
    }
    public override void OnCreatedRoom() {
        print("방만들기 성공");
    }
    public override void OnCreateRoomFailed(short returnCode, string message) {
        print("다시 시도하세요 같은 방이 있나봐요");
    }
    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnConnectedToMaster() {

    }


    public override void OnPlayerEnteredRoom(Player newPlayer) {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers) {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }


    //6자리
    public string MakeRoomNumber() {
        string name ="";
        for(int i = 0 ; i<6; i++) {
            System.Random rand = new System.Random();
            int t = rand.Next(0,10);
            name += t.ToString();
        }
        return name;
    }
    
}
//https://mingyu0403.tistory.com/309 포톤함수


