using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    private string _gameVersion = "0.1"; 
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings (_gameVersion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJoinedLobby()
    {
        Debug.Log("Trying to connect to a random room.");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room. No room created. ");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Room joined");
        PhotonNetwork.Instantiate("Prefabs/" + playerPrefab.name, playerPrefab.transform.position, Quaternion.identity, 0);
    }
}