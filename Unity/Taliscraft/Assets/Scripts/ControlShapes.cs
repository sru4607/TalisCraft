﻿using System.Collections;
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
    public GameObject pause;
    public AudioClip clickSound;
    public AudioClip victorySound;
    public AudioSource audioSource;
    public GameObject parent;
    public GameObject fireWorks;
    void Start () {
        audioSource = GetComponent<AudioSource>();
        pause.GetComponent<Canvas>().worldCamera = Camera.main;
        pause.GetComponent<Canvas>().planeDistance = 5;
        pause.SetActive(false);
        
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
        activeShape = Instantiate(CircleTemplate,parent.transform);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnTriangle()
    {
        activeShape = Instantiate(TriangleTemplate, parent.transform);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnDiamond()
    {
        activeShape = Instantiate(DiamondTemplate, parent.transform);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void SpawnHexagon()
    {
        activeShape = Instantiate(HexagonTemplate, parent.transform);
        activeShape.GetComponent<SpriteRenderer>().color = Color.black;
        AddToList();
    }

    public void AddToList()
    {
        
        audioSource.PlayOneShot(clickSound);
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
            audioSource.PlayOneShot(clickSound);
            activeShape.GetComponent<ApplyTransformation>().ScaleUp();
            CheckWin();
        }
        
    }

    public void ScaleDownShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            audioSource.PlayOneShot(clickSound);
            activeShape.GetComponent<ApplyTransformation>().ScaleDown();
            CheckWin();
        }
    }

    public void RotateShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            audioSource.PlayOneShot(clickSound);
            activeShape.GetComponent<ApplyTransformation>().RotateObject();
            CheckWin();
        }
    }

    public void ArrayShape()
    {
        if (activeShape.GetComponent<ApplyTransformation>() != null)
        {
            audioSource.PlayOneShot(clickSound);
            activeShape.GetComponent<ApplyTransformation>().Array(parent);
            CheckWin();
            parent.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void Pause()
    {
        pause.SetActive(true);
        gameObject.GetComponent<AudioSource>().Pause();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Resume()
    {
        audioSource.PlayOneShot(clickSound);
        pause.SetActive(false);
        gameObject.GetComponent<AudioSource>().UnPause();
    }
    public bool CheckWin()
    {
        if(Shapes.Count != solution.Count)
        {
            return false;
        }
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
                    rotationC %= 1;
                }
                if (spriteC == hexagonSprite)
                {
                    rotationC %= 2;
                }
                if (spriteC == diamondSprite)
                {
                    rotationC %= 1;
                }
                if (spriteC == triangleSprite)
                {
                    rotationC %= 4;
                }
                int scaleC = Shapes[j].GetComponent<ApplyTransformation>().scaleCount;
                
                bool arrayC = Shapes[j].GetComponent<ApplyTransformation>().array;
                if(spriteC == spriteT && scaleC == scale && rotationC == rotation && array == arrayC)
                {
                    exists = true;
                }

            }
            if(exists == false)
            {

                return false;
            }
        }
        audioSource.PlayOneShot(victorySound);
        GameObject fw = Instantiate(fireWorks, Vector3.zero, Quaternion.identity);
        levelComplete.SetActive(true);
        return true;
    }
}
