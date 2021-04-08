using UnityEngine;
using System.Collections;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3((float) -0.1, 0, 0));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3((float) 0.1, 0, 0));
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3( 0, 0, (float) -0.1));
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0, (float) 0.1));
        }
    }
}
