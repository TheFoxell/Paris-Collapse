using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class deplacement : MonoBehaviour
{
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        if (view.isMine)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(gameObject.transform.position.x - 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
                    
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(gameObject.transform.position.x + 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
                    
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 0.01f);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
                    
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.01f);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
    }
}