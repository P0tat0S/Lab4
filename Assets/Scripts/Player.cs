using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    
    public Vector2 moveValue;
    public float speed;
    private Rigidbody rb;
    public GameObject projectile;
    public Transform guns;
    public float fireRate;
    private float nextFire;

    public void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }
    
    void OnFire() {
        if(Time.time > nextFire) {
            Instantiate(projectile, guns);
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        Vector3 rotation = new Vector3(0.0f, 0.0f, moveValue.x);
        Quaternion deltaRotation = Quaternion.Euler(-90*rotation * Time.fixedDeltaTime);
        //X and Y Movement
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        //Z Rotation
        rb.MoveRotation(rb.rotation * deltaRotation);

        //Top and Bottom Boundaries
        if (rb.position.z >= 14) {
            moveValue.y = 0;
        } else if (rb.position.z <= -0.4) {
            moveValue.y = 0;
        }

        //Left and RIght Boundaries
        if (rb.position.x >=4.75) {
            moveValue.x = 0;
        } else if (rb.position.x <= -4.75) {
            moveValue.x = 0;
        }
        
    }
}