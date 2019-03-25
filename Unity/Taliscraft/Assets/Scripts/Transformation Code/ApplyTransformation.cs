using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTransformation : MonoBehaviour {

    public int scaleCount;
    public bool array;
    public int rotate;
    public List<GameObject> children;
    public GameObject baseSprite;
    const int maxScale = 5;

    public Color32[] shapeColors = { new Color32(200, 191, 231, 255), new Color32(187, 125, 255, 255), new Color32(163, 73, 164, 255), new Color32(1, 121, 231, 255),
        new Color32(0, 0, 160, 255), new Color32(0, 0, 0, 255), new Color32(136, 0, 21, 255), new Color32(237, 28, 36, 255), new Color32(255, 127, 39, 255), new Color32(255, 201, 14, 255), new Color32(255, 242, 0, 255) };
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
        if (scaleCount < maxScale)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ChildTransformation>().ScaleUp();
                    c.GetComponent<SpriteRenderer>().color = shapeColors[scaleCount + 6];
                }
            }
            scaleCount++;
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
            gameObject.GetComponent<SpriteRenderer>().color = shapeColors[scaleCount + 5];
        }
    }
    //decrease the scale of the object
    public void ScaleDown()
    {
        if (scaleCount > -maxScale)
        {
            if (array)
            {
                foreach (GameObject c in children)
                {
                    c.GetComponent<ChildTransformation>().ScaleDown();
                    c.GetComponent<SpriteRenderer>().color = shapeColors[scaleCount + 4];
                }
            }
            scaleCount--;
            gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            gameObject.GetComponent<SpriteRenderer>().color = shapeColors[scaleCount + 5];
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
    public void Array(GameObject parent)
    {
        
        if(!array)
        {
            array = true;
            if(parent.transform.localScale.x == 1)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 100, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 200, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            children.Add(GameObject.Instantiate(baseSprite, parent.transform));
            children.Add(GameObject.Instantiate(baseSprite, parent.transform));
            children.Add(GameObject.Instantiate(baseSprite, parent.transform));
            children.Add(GameObject.Instantiate(baseSprite, parent.transform));
            children.Add(GameObject.Instantiate(baseSprite, parent.transform));
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
                children[i].GetComponent<SpriteRenderer>().color = shapeColors[scaleCount + 5];
            }
        }  
    }

}
