# Typing Titan
A game created to increase the users typing speed.

## Table of Contents
- [Introduction](https://github.com/spencerFelts/TypingTitan#Introduction)
- [Technologies](https://github.com/spencerFelts/TypingTitan#Technologies)
- [How to install](https://github.com/spencerFelts/TypingTitan#Installation)
- [Usage](https://github.com/spencerFelts/TypingTitan#Usage)
- [License](https://github.com/spencerFelts/TypingTitan#License)

## Introduction
Do you want to be the fastest typer out of all of your friends? What about the fastest typer in your computer science classses? If you answered no to either of these questions, this game is not for you. Typing Titan is a game created to increase the speed at which the player can type. Although the game is predominantly aimed at computer science students, any casual person wanting to speed-up their typing skills can use this as well! 

## Technologies
Typing Titan was created using the C# language inside Unity.

In order to read the file after choosing it from a file dialog box I used:

```C#
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
 ```

To make the code in game easier to read I used a simple trim method adding it to the lineRead:
```C#
codeOutput.text += lineRead.Trim() + "\n";
```
*Note that the trim method is included inside the read file script. I just wanted to highlight this because of its importance in the game.*

## Installation
In order to play the game follow the following steps:

1. Download this Github repository
2. Open the Typing Titan folder
3. Open the Assets folder
4. Open the Scenes folder
5. Right click the StartScreen scene with the icon next to it
6. Press "open with" and choose Unity Editor

Once the editor opens you will need to create an executable:

1. Click the file tab in the top left corner
2. Click "build and run" from the dropdown
3. It will ask where you want to create the executable. Choosing the GitHub file is okay!
4. After you choose where you want to create it, the game should load.

Have fun and enjoy practicing your typing skills! Create your own text files and becoming the fastest typer you know!

## Usage
1. Once you launch the game, you will be loaded into the start screen giving three options: Start the game, quit the application, and/or choose a time limit. 

![StartScreen](https://github.com/spencerFelts/TypingTitan/blob/main/pictures/StartScreen.PNG)

2. After clicking start game an open file box will pop up, asking the user to select a file. I have created a few sample files in the Sample Files folder to start with!

![OpenFile](https://github.com/spencerFelts/TypingTitan/blob/main/pictures/FileDialog.PNG)

3. If the user hits cancel on the open file box an error screen will be shown prompting the user to go back to the start menu and choose a file.

![Error](https://github.com/spencerFelts/TypingTitan/blob/main/pictures/ErrorScreen.PNG)

4. Upon choosing a file the game will start. The contents inside of the file will show on the screen and the user will have the previous chosen time to completely type the code.
*90 seconds is the default time if nothing is chosen*

![Gameplay](https://github.com/spencerFelts/TypingTitan/blob/main/pictures/Gameplay.PNG)

5. When the player runs out of time or completes the code, they will be met with the final screen. This will give them the option to play again or quit the application.

![FinalScreen](https://github.com/spencerFelts/TypingTitan/blob/main/pictures/FinalScreen.PNG)

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
