using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    [SerializeField]private float speedVel;
    [SerializeField]private float turningVel;
    [SerializeField]private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedVel = Input.GetAxisRaw("Vertical");
        turningVel = Input.GetAxisRaw("Horizontal");

        rb.AddForce(transform.forward * speedVel);
    }
}
