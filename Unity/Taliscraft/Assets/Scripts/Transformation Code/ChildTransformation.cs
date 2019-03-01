using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTransformation : MonoBehaviour {


    //increase the scale of the object
    public void ScaleUp()
    {
        gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);

    }
    //decrease the scale of the object
    public void ScaleDown()
    {

        gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);

    }
    //decrease the scale of the object
    public void RotateObject()
    {
        gameObject.transform.SetPositionAndRotation(gameObject.transform.position,Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 90));
    }
    

}
