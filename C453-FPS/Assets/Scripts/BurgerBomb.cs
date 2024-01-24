using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BurgerBomb : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private float power = 50f;

    [SerializeField] private ParticleSystem explosion;

    // Explodes the burger bomb
    public void detonate()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider collider in hitColliders)
        {
            // Checking if the object has a rigidbody
            if(collider.GetComponent<Rigidbody>())
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                rb.AddExplosionForce(power, position, radius, 1.0f, ForceMode.Impulse);
            }
        }
        explosion.Play();
    }
}
