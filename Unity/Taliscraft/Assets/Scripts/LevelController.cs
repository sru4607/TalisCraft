using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public int levelCount;
    public List<GameObject> AllShapes;
    public GameObject GameWin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(levelCount)
        {
            case 1:
            {
                if(CheckSolutionLevel1())
                {
                    BeatLevel();
                }
                break;
            }
            default:
            {
                break;
            }
        }
	}

    bool CheckSolutionLevel1()
    {

        return true;
    }

    void BeatLevel()
    {

        
    }
}
