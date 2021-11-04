using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    public void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
        //X and Y Movement
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        //Top Boundary
        if (rb.position.z >= 15) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "asteroid") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } 
    }
}