using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public AudioSource audioSource;
    public AudioClip audioPickUp = null;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        audioSource.PlayOneShot(audioPickUp);
        Debug.Log("Picking up " + item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
