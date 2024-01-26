using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string gunName;
    [SerializeField] protected int currentBullets;
    [SerializeField] protected int maxBullets;

    [SerializeField] protected GameObject bulletHole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot()
    {
        if (currentBullets > 0)
        {
            // Raycast shoot woah
            // RaycastHits are objects which hold data about whatever the raycast hit
            RaycastHit hit;
            // This statement will only trigger if it hits something w/ a collider on it
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) 
            {
                // Spawning a bullet hole at the point of contact with the same rotation as me
                GameObject decal = Instantiate(bulletHole, hit.point, Quaternion.identity);
                // Giving it the angle we want
                decal.transform.forward = -hit.normal;
                decal.transform.Translate(Vector3.back * 0.01f);

                // Saving its current position so it doesn't get fucked up once we change its position
                Vector3 worldPosition = decal.transform.position;
                Quaternion worldRotation = decal.transform.rotation;
                // Need to set up parentage with the transforms
                decal.transform.SetParent(hit.transform);
                decal.transform.position = worldPosition;
                decal.transform.rotation = worldRotation;

                currentBullets--;
            }
        }
    }

    public virtual int Reload(int rounds)
    {
        if (currentBullets < maxBullets)
        {
            currentBullets += rounds;
            int roundsLeftOver = currentBullets - maxBullets;
            if (roundsLeftOver < 0)
            {
                roundsLeftOver = 0;
            }
            if (currentBullets > maxBullets)
            {
                currentBullets = maxBullets;
            }
            return roundsLeftOver;
        }
        else
        {
            return rounds;
        }
    }
}
