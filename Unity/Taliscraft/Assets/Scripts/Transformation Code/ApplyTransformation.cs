using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTransformation : MonoBehaviour {

    int scaleCount;
    bool array;
    int rotate;
    List<GameObject> children;

	// Use this for initialization
	void Start () {
        scaleCount = 0;
        rotate = 0;
        array = false;
	}
	
    //increase the scale of the object
    void ScaleUp()
    {
        if (scaleCount < 3)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ApplyTransformation>().ScaleUp();
                }
            }
            scaleCount++;
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
    }
    //decrease the scale of the object
    void ScaleDown()
    {
        if (scaleCount > -3)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ApplyTransformation>().ScaleDown();
                }
            }
            scaleCount--;
            gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
    //decrease the scale of the object
    void RotateObject()
    {
        if (array)
        {
            foreach (GameObject c in children)
            {
                c.GetComponent<ApplyTransformation>().RotateObject();
            }
        }
        gameObject.transform.Rotate(0, 0, 90);
        rotate++;
    }
    //Array the object and set children array and all child transformations
    void Array()
    {
        if(!array)
        {

        }
    }
}
