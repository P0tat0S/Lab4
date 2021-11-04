using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Vector3 rotation;
    private Rigidbody rb;
    public float speed;

    private void Start() {
        rotation = new Vector3(Random.Range(-1,1), Random.Range(-1,1), Random.Range(-1,1));
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        //Random Rotation
        Quaternion deltaRotation = Quaternion.Euler(-90*rotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);
        //X and Y Movement
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        
        //Top Boundary
        if (rb.position.z <= -6) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } 
    }
}
