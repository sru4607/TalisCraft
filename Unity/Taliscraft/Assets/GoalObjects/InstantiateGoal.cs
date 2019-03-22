using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Written By Kesavan Shanmugasundaram
/// Instantiates the correct target based off the current level
/// Must add additional levels to canvas prefab
/// </summary>
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
    /// <summary>
    /// Spawns the target
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    public GameObject SpawnGoal(int currentLevel)
    {
        GameObject goal = Instantiate(levels[currentLevel], new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
        goal.transform.parent = gameObject.transform;
        goal.name = levels[currentLevel].gameObject.name;
        return goal;

    }
    /// <summary>
    /// Extracts level number from scene name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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
