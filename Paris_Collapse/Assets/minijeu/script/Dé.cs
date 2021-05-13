using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dé : MonoBehaviour
{
    public int face, force = 200;
    private Rigidbody rb;
    bool playdice = false;
    public Text txt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && rb.velocity.magnitude == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                rb.AddForce(hit.point * force);
                playdice = true;
            }
        }
    }

    private void Update()
    {
        if (playdice && rb.velocity.magnitude == 0)
        {
            playdice = false;
            StartCoroutine(ShowFace());
        }
    }

    IEnumerator ShowFace()
    {
        txt.enabled = true;
        txt.GetComponent<Text>().text = face.ToString();
        yield return new WaitForSeconds(2f);
        txt.enabled = false;
    }
}
