using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBox : MonoBehaviour
{
    [Header("Street Sides")]
    [SerializeField] StreetLight[] nStreet;
    [SerializeField] StreetLight[] eStreet;
    [SerializeField] StreetLight[] sStreet;
    [SerializeField] StreetLight[] wStreet;

    [Header("Street Sides")]
    [SerializeField] Camera cam;

    [Header("Vehicles")]
    [SerializeField] GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.transform.GetChild(0).transform.gameObject.GetComponent<Camera>();
        cam.enabled = false;
        foreach(StreetLight sl in nStreet)
        {
            sl.setPos("north");
        }
        foreach (StreetLight sl in eStreet)
        {
            sl.setPos("east");
        }
        foreach (StreetLight sl in wStreet)
        {
            sl.setPos("west");
        }
        foreach (StreetLight sl in sStreet)
        {
            sl.setPos("south");
        }
    }

    // Update is called once per frame
    void Update()
    {
        addCam();
    }

    private void addCam()
    {
        car = GameObject.FindGameObjectWithTag("Car");
        Vector3 carP = car.transform.position;
        Vector3 boxP = this.transform.position;
        float dist = Vector3.Distance(car.transform.position, this.transform.position);
        float horDist = Mathf.Sqrt((Mathf.Pow(dist, 2)) + (Mathf.Pow(boxP.y - carP.y, 2)));
        if (horDist < 30f)
        {
            cam.enabled = true;
        }
        else 
        {
            cam.enabled = false;
        }
    }
}
