using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject[] optionsMenuItems;
    public GameObject[] LevelsItems;

    void Start()
    {

    }
    private enum Scene
    {
        TutorialLevel,
        Level1,
        Level2,
    }

    private static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void PlayButton()
    {
        Load(Scene.TutorialLevel);
    }
    public void Levels()
    {
        for (int i = 0; i < optionsMenuItems.Length; i++)
        {
            optionsMenuItems[i].SetActive(false);
        }

        for (int i = 0; i < LevelsItems.Length; i++)
        {
            LevelsItems[i].SetActive(true);
        }
    }

    public void Options()
    {
        for (int i = 0; i < optionsMenuItems.Length; i++)
        {
            optionsMenuItems[i].SetActive(true);
        }

        for (int i = 0; i < LevelsItems.Length; i++)
        {
            LevelsItems[i].SetActive(false);
        }
    }

    public void Level1()
    {
        Load(Scene.Level1);
    }
    public void Level2()
    {
        Load(Scene.Level2);
    }
}
