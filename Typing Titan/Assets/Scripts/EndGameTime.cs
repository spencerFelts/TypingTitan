using UnityEngine.UI;
using UnityEngine;

public class EndGameTime : MonoBehaviour
{
    public Text timeLeft;

    private void Start()
    {
        float timeEnd = PlayerPrefs.GetFloat("timeEnd");


        if (timeEnd >= 0)
        {
            timeLeft.text = "Time remaining: " + timeEnd.ToString("F2") + " seconds";
        } else
        {
            timeLeft.text = "Time remaining: 0 seconds";
        }
    }
}
