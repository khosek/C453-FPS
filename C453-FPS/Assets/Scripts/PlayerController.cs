using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float sensitivity;
    public float sprintSpeed;

    [Header("Inventory")]
    [SerializeField] private int bullets;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;
    private CharacterController cc;
    private Camera _camera;

    private Weapon _gun;
    [SerializeField] private BurgerBomb bomb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
        _camera = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Camera>();
        _gun = _camera.transform.GetChild(0).gameObject.GetComponent<Weapon>();
    }

    private void Update()
    {
        Move();

        // Fires the gun upon the mouse being clicked
        if (Input.GetMouseButtonDown(0))
        {
           _gun.Shoot();
        }

        // Reloads the gun if the player is trying to reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("Reloading");
            // Also updates how many bullets they have left
            int newBullets = _gun.Reload(bullets);
            bullets = newBullets;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            bomb.detonate();
        }
    }

    public void PickUpAmmo(int amount)
    {
        bullets += amount;
    }

    private void Move()
    {
        float movementSpeed = speed;
        
        // Checking to see if the player is holding the sprint key
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }

        // Checking to see if the player has released the sprint key
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = speed;
        }

        // Grabbing axis and mouse movement
        moveFB = Input.GetAxis("Vertical") * movementSpeed;
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp the Y rotation
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        // Creating the movement vector
        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;

        // Rotating the player camera
        transform.Rotate(0, rotX, 0);
        _camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        // Applying movement to the player
        movement = transform.rotation * movement;
        cc.Move(movement * Time.deltaTime);
    }    
}
