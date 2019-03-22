using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlShapes : MonoBehaviour {
    // Use this for initialization
    public List<GameObject> Shapes;
    public List<GameObject> solution;
    public Sprite circleSprite;
    public Sprite triangleSprite;
    public Sprite hexagonSprite;
    public Sprite diamondSprite;
    public GameObject levelComplete;
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
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnTriangle()
    {
        activeShape = Instantiate(TriangleTemplate);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnDiamond()
    {
        activeShape = Instantiate(DiamondTemplate);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnHexagon()
    {
        activeShape = Instantiate(HexagonTemplate);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
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

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public bool CheckWin()
    {
        
        for(int i = 0; i<solution.Count; i++)
        {
            bool exists = false;
            Sprite spriteT = solution[i].GetComponent<SpriteRenderer>().sprite;
            int scale = solution[i].GetComponent<ApplyTransformation>().scaleCount;
            int rotation = solution[i].GetComponent<ApplyTransformation>().rotate;
            bool array = solution[i].GetComponent<ApplyTransformation>().array;
            for(int j = 0; j < Shapes.Count; j++)
            {
                Sprite spriteC = Shapes[j].GetComponent<SpriteRenderer>().sprite;
                int rotationC = Shapes[j].GetComponent<ApplyTransformation>().rotate;
                if (spriteC == circleSprite)
                {
                    rotation %= 1;
                }
                if (spriteC == hexagonSprite)
                {
                    rotation %= 1;
                }
                if (spriteC == diamondSprite)
                {
                    rotation %= 1;
                }
                if (spriteC == triangleSprite)
                {
                    rotation %= 4;
                }
                int scaleC = Shapes[j].GetComponent<ApplyTransformation>().scaleCount;
                
                bool arrayC = Shapes[j].GetComponent<ApplyTransformation>().array;
                if(spriteC == spriteT && scaleC == scale && rotationC == rotation && array == arrayC)
                {
                    exists = true;
                    Debug.Log("Match");
                }

            }
            if(exists == false)
            {
                return false;
            }
        }
        Debug.Log("Win");
        levelComplete.SetActive(true);
        return true;
    }
}
