using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public Dropdown timeLimit;

    public static float time;
    public bool check = false;

    public void MoveToGame()
    {
        SceneManager.LoadScene("Gameplay");

        if (check == false)
        {
            time = 90f;
        }
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Drop()
    {
        switch (timeLimit.value)
        {
            default:
                time = 90f;
                break;
            case 1:
                time = 30f;
                break;
            case 2:
                time = 60f;
                break;
            case 3:
                time = 90f;
                break;
        }

    }
}
