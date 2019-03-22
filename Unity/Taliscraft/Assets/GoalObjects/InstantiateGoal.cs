using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InstantiateGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentGoal;
    public List<GameObject> levels;
    public int currentLevel = 0;
    public string currentLevelName;
    void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        currentLevel = GetLevelNumber(currentLevelName);
        currentGoal = SpawnGoal(currentLevel - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject SpawnGoal(int currentLevel)
    {
        GameObject goal = Instantiate(levels[currentLevel], transform.position, Quaternion.identity);
        goal.transform.parent = gameObject.transform;
        goal.name = levels[currentLevel].gameObject.name;
        return goal;

    }
    public int GetLevelNumber(string name)
    {
        string x = "";
        for(int i =0; i < name.Length; i++)
        {
            if (char.IsDigit(name[i]))
            {
                x += name[i];
            }
        }
        return int.Parse(x);
    }
}
