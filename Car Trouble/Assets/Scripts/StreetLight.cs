using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    [Header("Light Status")]
    [SerializeField] bool Red;
    [SerializeField] bool Yellow;
    [SerializeField] bool Green;

    [Header("Type & Exceptions")]
    [SerializeField] string Exceptions;
    [SerializeField] string Pos;
    [SerializeField] bool isLeft;

    [Header("Materials")]
    [SerializeField] Material rMat;
    [SerializeField] Material gMat;
    [SerializeField] Material yMat;
    [SerializeField] Material dullMat;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(runLights());
        
    


    }

    public string getStatus()
    {
        string r = "";
        if (Red)
        {
            r = "Red";
        }
        else if (Yellow)
        {
            r = "Yellow";
        }
        else if (Green)
        {
            r = "Green";
        }
        return r;
    }
    IEnumerator runLights()
    {
        
        //firstRun
        if ((Pos.Equals("north") || Pos.Equals("south")) && isLeft)
        {
            Green = true;
            Red = false;
            
        }
        else 
        {
            Red = true;
            Green = false;
           
        }
        changeColor();
        yield return new WaitForSeconds(Random.Range(5f, 10.0f));

        if ((Pos.Equals("north") || Pos.Equals("south")))
        {
            Green = true;
            Red = false;
            
        }
        else 
        {
            Red = true;
            Green = false;
            
        }
        changeColor();
        yield return new WaitForSeconds(Random.Range(10f, 15.0f));

        if ((Pos.Equals("east") || Pos.Equals("west")) && isLeft)
        {
            Green = true;
            Red = false;
            
        }
        else
        {
            Red = true;
            Green = false;
           
        }
        changeColor();
        yield return new WaitForSeconds(Random.Range(5f, 10.0f));

        if ((Pos.Equals("east") || Pos.Equals("west")))
        {
            Green = true;
            Red = false;
           
        }
        else
        {
            Red = true;
            Green = false;
           
        }
        changeColor();
        yield return new WaitForSeconds(Random.Range(10f, 15.0f));
    }
    public void setPos(string s) { Pos = s; }
    public void changeColor()
    {
        if (Green)
        {
            this.transform.GetChild(2).gameObject.GetComponent<Renderer>().material = gMat;
            this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = dullMat;
            this.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = dullMat;
        }
        else if (Red)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = rMat;
            this.transform.GetChild(2).gameObject.GetComponent<Renderer>().material = dullMat;
            this.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = dullMat;
        }
        if (Yellow)
        {
            this.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = yMat;
            this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = dullMat;
            this.transform.GetChild(2).gameObject.GetComponent<Renderer>().material = dullMat;
        }
    }

}
