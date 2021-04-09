using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class Typer : MonoBehaviour
{

    public Text codeOutput = null;
    private string remainingCode = string.Empty;
    // This "currentCode" will be pulled from the Input Field
    private string currentCode;


    void Start()
    {
        SetCurrentCode();
    }

    public void ChooseFile()
    {
        string openPath = EditorUtility.OpenFilePanel("Please select a .txt file!", "", "txt");

        if (openPath.Length != 0)
        {
            var fileContent = File.ReadAllBytes(openPath);
        }
        string lineRead = "";
        codeOutput.text = "";

        StreamReader reader = new StreamReader(openPath);
        while (!reader.EndOfStream)
        {
            lineRead = reader.ReadLine();
            Debug.Log(lineRead);
            codeOutput.text += lineRead.Trim() + "\n";
        }
        reader.Close();
    }

    void SetCurrentCode()
    {
        //This will set the remaining code to the currentCode
        ChooseFile();
        SetRemainingCode(codeOutput.text);
    }

    void SetRemainingCode(string newCode)
    {
        remainingCode = newCode;
        codeOutput.text = remainingCode;
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            
            //If the number of keys pressed in the frame is = 1, call EnterLetter
            if (keysPressed.Length == 1)
                EnterLetter(keysPressed);
        }
    }

    /* If the key pressed is the first letter of the word it will call
    RemoveLetter() which will remove the letter */
    void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            /* Calls IsCodeComplete fucntion, if the length of the
            code, or string, is = 0 go to end scene */
            if (IsCodeComplete())
                SceneManager.LoadScene("GameComplete");
        }
    }

    //This will check if the letter is the correct letter for the word
    bool IsCorrectLetter(string letter)
    {
        return remainingCode.IndexOf(letter) == 0;
    }

    //Removes first letter from code if it is the correct letter
    void RemoveLetter()
    {
        string newString = remainingCode.Remove(0, 1);
        
        // Updates the current code to the previous code minus the first letter
        SetRemainingCode(newString);
    }

    //Checks if the code is complete
    bool IsCodeComplete()
    {
        return remainingCode.Length == 0;
    }
}
