# Typing Titan
A game created to increase the users typing speed.

## Table of Contents
- [Introduction](https://github.com/spencerFelts/TypingTitan#Introduction)
- [Technologies](https://github.com/spencerFelts/TypingTitan#Technologies)
- [How to install](https://github.com/spencerFelts/TypingTitan#Installation)
- [Usage](https://github.com/spencerFelts/TypingTitan#Usage)
- [License](https://github.com/spencerFelts/TypingTitan#License)

### Introduction
Do you want to be the fastest typer out of all of your friends? What about the fastest typer in your computer science classses? If you answered no to either of these questions, this game is not for you. Typing Titan is a game created to increase the speed at which the player can type. Although the game is predominantly aimed at computer science students, any casual person wanting to speed-up their typing skills can use this as well! 

## Technologies
Typing Titan was created using the C# language inside Unity.

In order to open a file to import into the game I used the Open File Panel and read file script:

```C#
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
 ```

To make the code in game easier to read I used a simple trim method adding it to the lineRead:
```C#
codeOutput.text += lineRead.Trim() + "\n";
```
Note that the trim method is included inside the read file script. I just wanted to highlight this because of its importance in the game.

## Installation

## Usage
Once you launch the game, you will be loaded into the start screen giving two options: Start the game or quit the application.

*start screen*

After clicking start game an open file box will pop up, asking the user to select a .txt file. I have created a few sample files in the TextFiles folder to start with!

*open file box*

Upon choosing a file the game will start. The contents inside of the file will show on the screen and the user will have 30 seconds to completely type the code.

*gameplay*

When the player runs out of time or completes the code, they will be met with the final screen. This will give them the option to play again or quit the application.

*final scene*

## License
MIT License

Copyright (c) 2021 spencerFelts

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
