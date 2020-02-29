using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    [SerializeField]private float speedAcc;
    [SerializeField]private float turningVel;
    [SerializeField] private float tvSpeed;
    [SerializeField]private bool isTurning;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        isTurning = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Updates values based on PLAYER INPUT
        speedAcc = Input.GetAxisRaw("Vertical");
        turningVel = Input.GetAxisRaw("Horizontal");

        //adds velocity accordingly
        addVel(speedAcc, 3);

        //turns vechicle
        if (Mathf.Abs(turningVel) > 0)
        {
            isTurning = true;
        }
        else
        {
            isTurning = false;
        }
        turning(turningVel);

        //shows velocity
        Debug.Log("" + rb.velocity);
    }

    public void addVel(float f, float b)
    {
        if (rb.velocity == Vector3.zero)
        {
            anim.SetBool("Stop", true);
        }
        else
        {
            anim.SetBool("Stop", false);
        }
        if (Mathf.Abs(rb.velocity.z) > 15 )
        {
            rb.velocity = Vector3.zero;
        }

        if (f > 0)
        {
            if (rb.velocity.z < 0)
            {
                rb.AddForce(transform.forward * (b + 5) * f);
            }
            else
            {
                if (isTurning)
                {
                  
                    rb.velocity = transform.forward * (Mathf.Sqrt(Mathf.Pow(rb.velocity.z, 2) + Mathf.Pow(rb.velocity.x,2)));
                    rb.AddForce(transform.forward * b * f);
                }
                else 
                {
                    
                    rb.AddForce(transform.forward * b * f);
                }
                
            }
        }
        else if (f == 0)
        {
            if (rb.velocity.z > .2)
            {
                rb.AddForce(transform.forward * -(b - 2));
            }
            else if (rb.velocity.z < -.2)
            {
                rb.AddForce(transform.forward * (b - 2));
            }
            else 
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {

            if (rb.velocity.z > 0)
            {
                rb.AddForce(transform.forward * (b + 5) * f);
            }
            else
            {
                if (isTurning)
                {
                    rb.velocity = transform.forward * -(Mathf.Sqrt(Mathf.Pow(rb.velocity.z, 2) + Mathf.Pow(rb.velocity.x, 2)));
                    rb.AddForce(transform.forward * b * f);
                }
                else
                {
                    
                    rb.AddForce(transform.forward * b * f);
                }
            }
        }

       
    }
    public void turning(float f)
    {
        this.transform.Rotate(0f, tvSpeed * f * Time.deltaTime, 0f);
    }
   


}
