using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem fishSpawner;
    
    public void interact()
    {
        fishSpawner.Play();
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
