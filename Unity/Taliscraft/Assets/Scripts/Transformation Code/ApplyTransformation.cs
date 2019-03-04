using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTransformation : MonoBehaviour {

    public int scaleCount;
    public bool array;
    public int rotate;
    public List<GameObject> children;
    public GameObject baseSprite;

	// Use this for initialization
	void Start () {
       
	}

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.D))
        //{
        //    ScaleDown();
        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    ScaleUp();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    RotateObject();
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Array();
        //}
    }
    //increase the scale of the object
    public void ScaleUp()
    {
        if (scaleCount < 3)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ChildTransformation>().ScaleUp();
                }
            }
            scaleCount++;
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
    }
    //decrease the scale of the object
    public void ScaleDown()
    {
        if (scaleCount > -3)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ChildTransformation>().ScaleDown();
                }
            }
            scaleCount--;
            gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
    //decrease the scale of the object
    public void RotateObject()
    {
        if (array)
        {
            foreach (GameObject c in children)
            {
                c.GetComponent<ChildTransformation>().RotateObject();
            }
        }
        gameObject.transform.SetPositionAndRotation(gameObject.transform.position,Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 90));
        rotate++;
    }
    //Array the object and set children array and all child transformations
    public void Array()
    {
        
        if(!array)
        {
            array = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x-gameObject.GetComponent<SpriteRenderer>().sprite.rect.width/100, gameObject.transform.position.y, gameObject.transform.position.z);
            children.Add(GameObject.Instantiate(baseSprite));
            children.Add(GameObject.Instantiate(baseSprite));
            children.Add(GameObject.Instantiate(baseSprite));
            children.Add(GameObject.Instantiate(baseSprite));
            children.Add(GameObject.Instantiate(baseSprite));
            for (int i = 0; i<5; i++)
            {
                children[i].transform.position = gameObject.transform.position;
                if (scaleCount < 0)
                {
                    for(int j = 0; j>scaleCount; j--)
                    {
                        children[i].GetComponent<ChildTransformation>().ScaleDown();
                    }
                }
                else if (scaleCount > 0)
                {
                    for (int j = 0; j < scaleCount; j++)
                    {
                        children[i].GetComponent<ChildTransformation>().ScaleUp();
                    }
                }
                for(int j = 0; j<rotate; j++)
                {
                    children[i].GetComponent<ChildTransformation>().RotateObject();
                }
                children[i].transform.RotateAround(new Vector3(0, 0, 0),Vector3.forward,(60 * (i + 1)));
            }
        }  
    }

}
