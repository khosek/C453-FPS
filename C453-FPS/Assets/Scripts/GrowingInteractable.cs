using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingInteractable : MonoBehaviour, IInteractable
{

    public void Start()
    {
    }

    // Every time the player interacts with this object, the object's size scales up
    public void interact()
    {
        transform.localScale = transform.localScale * 1.25f;
    }

    public void Update()
    {
        
    }
}
