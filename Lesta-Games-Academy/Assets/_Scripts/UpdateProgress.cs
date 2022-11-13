using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateProgress : MonoBehaviour
{
    public List <GameObject> _cubes;
    private string[] _tags = new[] { "Red", "Orange", "Yellow" };

    public GameObject LevelCompletePanel;

    private void Start()
    {
        for (int i = 0; i < _tags.Length; i++)
            for(int j = 0; j < GameObject.FindGameObjectsWithTag(_tags[i]).Length; j++)
                _cubes.Add(GameObject.FindGameObjectsWithTag(_tags[i])[j]);
    }

    public void Check()
    {
        int counter = 0;

        for (int i = 0; i < _cubes.Count; i++)
        {
            switch(_cubes[i].tag, _cubes[i].transform.position.x)
            {
                case ("Red", 2):
                    counter++;
                    break;
                case ("Orange", 0):
                    counter++;
                    break;
                case ("Yellow", -2):
                    counter++;
                    break;
            }
        }

        if (counter == _cubes.Count)
        {
            Time.timeScale = 0;
            LevelCompletePanel.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}