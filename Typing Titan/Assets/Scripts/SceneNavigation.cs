using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class SceneNavigation : MonoBehaviour
{
    
    public void MoveToGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
