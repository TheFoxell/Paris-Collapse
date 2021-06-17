using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIController : MonoBehaviour
{
    Text statusText, masterText;
    // Start is called before the first frame update
    void Start()
    {
        statusText = GameObject.Find("statusText").GetComponent<Text>();
        masterText = GameObject.Find("masterText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        statusText.text = "Status : " + PhotonNetwork.connectionStateDetailed.ToString();
        masterText.text = "isMasterClient : " + PhotonNetwork.isMasterClient;
    }
}
