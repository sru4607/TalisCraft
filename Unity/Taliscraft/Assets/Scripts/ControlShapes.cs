using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlShapes : MonoBehaviour {
    // Use this for initialization
    List<GameObject> Shapes;
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject ListTemplate;
    public GameObject activeShape;
    public GameObject TriangleTemplate;
    public GameObject CircleTemplate;
    public GameObject DiamondTemplate;
    public GameObject HexagonTemplate;
    public void SpawnCircle()
    {
        activeShape = Instantiate(CircleTemplate);
        AddToList();
    }

    public void SpawnTriangle()
    {
        activeShape = Instantiate(TriangleTemplate);
        AddToList();
    }

    public void SpawnDiamond()
    {
        activeShape = Instantiate(DiamondTemplate);
        AddToList();
    }

    public void SpawnHexagon()
    {
        activeShape = Instantiate(HexagonTemplate);
        AddToList();
    }

    public void AddToList()
    {
        Shapes.Add(activeShape);
        CheckWin();
    }

    public void SelectShape()
    {
        //activeShape = GameObject.Find(EventSystem.current.currentSelectedGameObject.name.Substring(1));
    }

    public void ScaleUpShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            activeShape.GetComponent<ApplyTransformation>().ScaleUp();
            CheckWin();
        }
    }

    public void ScaleDownShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            activeShape.GetComponent<ApplyTransformation>().ScaleDown();
            CheckWin();
        }
    }

    public void RotateShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            activeShape.GetComponent<ApplyTransformation>().RotateObject();
            CheckWin();
        }
    }

    public void ArrayShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            activeShape.GetComponent<ApplyTransformation>().Array();
            CheckWin();
        }
    }

    public void Pause()
    {
        Debug.Log("Pasued");
    }

    public bool CheckWin()
    {
        bool win = false;
        


        if (win)
        {
            Debug.Log("Win");
            return true;
        }
        else
        {
            Debug.Log("Not Win");
            return false;
        }
    }
}
