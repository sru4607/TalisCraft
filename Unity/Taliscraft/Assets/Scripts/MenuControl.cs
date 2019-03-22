using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public List<GameObject> items;
    public int index;
    public GameObject TextObj;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Instruction()
    {
        SceneManager.LoadScene(1);
    }
    public void Next()
    {
        items[index].SetActive(false);
        index++;
        if(index == items.Count-1)
        {
            TextObj.GetComponent<Text>().text = "Menu";
        }
        if(index == items.Count)
        {
            SceneManager.LoadScene(0);
            return;
        }
        items[index].SetActive(true);
    }
}
