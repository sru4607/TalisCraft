using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlShapes : MonoBehaviour {
	// Use this for initialization
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
    }

    public void SpawnTriangle()
    {
        activeShape = Instantiate(TriangleTemplate);
    }

    public void SpawnDiamond()
    {
        activeShape = Instantiate(DiamondTemplate);
    }

    public void SpawnHexagon()
    {
        activeShape = Instantiate(HexagonTemplate);
    }

    public void AddToList()
    {
        
    }

    public void SelectShape()
    {
        activeShape = GameObject.Find(EventSystem.current.currentSelectedGameObject.name.Substring(1));
    }

    public void ScaleUpShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
            activeShape.GetComponent<ApplyTransformation>().ScaleUp();
    }

    public void ScaleDownShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
            activeShape.GetComponent<ApplyTransformation>().ScaleDown();
    }

    public void RotateShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
            activeShape.GetComponent<ApplyTransformation>().RotateObject();
    }

    public void ArrayShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
            activeShape.GetComponent<ApplyTransformation>().Array();
    }
}
