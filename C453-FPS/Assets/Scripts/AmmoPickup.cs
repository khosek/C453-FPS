using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, IPickUpAble
{
    [SerializeField] int ammo;

    public void PickUp(PlayerController player)
    {
        player.PickUpAmmo(ammo);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUp(other.gameObject.GetComponent<PlayerController>());
        }
    }
}
