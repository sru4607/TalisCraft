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
        scaleCount = 0;
        rotate = 0;
        array = false;
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            ScaleDown();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ScaleUp();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateObject();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Array();
        }
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
            array = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x-gameObject.GetComponent<SpriteRenderer>().sprite.rect.width/100, gameObject.transform.position.y, gameObject.transform.position.z);
            children.Add(GameObject.Instantiate(gameObject));
            children.Add(GameObject.Instantiate(gameObject));
            children.Add(GameObject.Instantiate(gameObject));
            children.Add(GameObject.Instantiate(gameObject));
            children.Add(GameObject.Instantiate(gameObject));

            for (int i = 0; i<5; i++)
            {

                children[i].GetComponent<ApplyTransformation>().children.Clear();
                if (scaleCount < 0)
                {
                    for(int j = 0; j>scaleCount; j--)
                    {
                        children[i].GetComponent<ApplyTransformation>().ScaleDown();
                    }
                }
                else if (scaleCount > 0)
                {
                    for (int j = 0; j < scaleCount; j++)
                    {
                        children[i].GetComponent<ApplyTransformation>().ScaleUp();
                    }
                }
                for(int j = 0; j<rotate; j++)
                {
                    children[i].GetComponent<ApplyTransformation>().RotateObject();
                }
                children[i].transform.Rotate(new Vector3(0, 0, 1), (60 * (i + 1)),Space.Self);
            }
          
            Debug.Log(array);
        }
    }
}
