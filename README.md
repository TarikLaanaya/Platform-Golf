# Platform-Golf

## Description

My first project working with mobile devices. Platform Golf is a mobile 3D platformer in which the player navigates through caves and a golf course, hitting the golf
ball to higher and higher platforms eventually reaching the flag within the smallest amount of moves. Think an angry birds platformer but its golf and you climb upwards.

## Features

All scripts can be found in `Platform-Golf/Assets/Scripts/`

* Through this game I learned a lot about combining Unity's physics engine with scripting to create dynamic movement that could simulate a golf ball. Some example scripts are:
  
  * `AddForceToBall` This script controls the main functions of the golf ball. It takes user input and converts it into gradually increasing force. It also provides the user with an estimated trajectory to help them identify the landing point of the ball.
  * `BouncePad` This simple script applies a force based on the normal that the golf ball lands on

* I also learned about using user interface with scripting to create modular and interactive UI. In this case a dialogue system which provided narrative but also a tutorial which would guide the user. The two main dialogue scripts are:

  * `DialogueController` This script worked directly with the `DialogueWindow` script to show and hide the dialogue at the appropriate times.
  * The `DialogueWindow` script controlled the flow of text on the screen so that it would display each letter after a given time. This created a scroll effect which added polish to the User Interface. It also worked with the Unity editor and was dynamic meaning you could add and remove text as you see fit. This greatly improved the time of which it took to complete the project and this system could still be used in my future projects.

## Viewing The Project

There are many more mechanics and if you would like to see them in action follow these steps:

1. Install Unity Hub from the official [Unity Website](https://unity.com/download), the version this project uses is: 2021.3.4f1.
2. Press the green "code" button located on this repositories home page, from the drop down click download zip.
3. Extract the downloaded file (right click > extract).
4. Open the Unity Hub application and press add located at the top right. Find your extracted folder.
5. The Unity project named "Platform Golf" should appear. Click on it.
6. When the application opens the play button is located at the very top.

Notes: To play the game you either need to connect your mobile device, tutorials for which can be found [here](https://www.youtube.com/watch?v=J2T92mzvmHk&ab_channel=DigieraGames)
or you can use the built in Device Simulator tutorials for which are found [here](https://www.youtube.com/watch?v=dI1IEajUg_Y&ab_channel=JehoshaphatAbu)

## Gameplay And Other Projects

If instead you would like to see gameplay footage for platform golf I have posted a video on my YouTube [LataDev](https://www.youtube.com/watch?v=fEtlPdAvisw&t=3s&ab_channel=LaTaDev) and time stamps can be found in the videos description. You can also see footage of my other projects some of which will be posted to github.
