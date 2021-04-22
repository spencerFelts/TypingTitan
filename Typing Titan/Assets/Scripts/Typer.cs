using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class Typer : MonoBehaviour
{

    public Text codeOutput = null;
    private string remainingCode = string.Empty;
    // This "currentCode" will be pulled from the Input Field
    private string currentCode;


[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]

public class OpenFileName
    {
        public int structSize = 0;
        public IntPtr dlgOwner = IntPtr.Zero;
        public IntPtr instance = IntPtr.Zero;
        public String filter = null;
        public String customFilter = null;
        public int maxCustFilter = 0;
        public int filterIndex = 0;
        public String file = null;
        public int maxFile = 0;
        public String fileTitle = null;
        public int maxFileTitle = 0;
        public String initialDir = null;
        public String title = null;
        public int flags = 0;
        public short fileOffset = 0;
        public short fileExtension = 0;
        public String defExt = null;
        public IntPtr custData = IntPtr.Zero;
        public IntPtr hook = IntPtr.Zero;
        public String templateName = null;
        public IntPtr reservedPtr = IntPtr.Zero;
        public int reservedInt = 0;
        public int flagsEx = 0;
    }

public class DllTest
    {
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        public static bool GetOpenFileName1([In, Out] OpenFileName ofn)
        {
            return GetOpenFileName(ofn);
        }
    }

public void OpenFileDialog() {
        OpenFileName ofn = new OpenFileName();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "\0.txt\0TypingTitan\\Typing Titan\\Assets\\Sample Files";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = UnityEngine.Application.dataPath;
        ofn.title = "Please choose a file!";
        ofn.defExt = "txt";
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR
        if (DllTest.GetOpenFileName(ofn))
        {
            Debug.Log("This shows the dialog box finish");
            if (ofn.file.Length != 0)
            {
                var fileContent = File.ReadAllBytes(ofn.file);
            }
            string lineRead = "";
            codeOutput.text = "";

            StreamReader reader = new StreamReader(ofn.file);
            while (!reader.EndOfStream)
            {
                lineRead = reader.ReadLine();
                Debug.Log(lineRead);
                codeOutput.text += lineRead.Trim() + "\n";
            }
            reader.Close();
        } else {
            SceneManager.LoadScene("Error Screen");
        }
    }

void Start()
    {
        SetCurrentCode();
    }

    void SetCurrentCode()
    {
        //This is where to call the ChooseFile() function
        OpenFileDialog();
        //This will set the remaining code to the currentCode
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
