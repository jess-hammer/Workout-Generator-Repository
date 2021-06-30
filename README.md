# Workout Routine Generator

### Introduction
SEE THE APP ON ITCH HERE https://jess-hammer.itch.io/workout-routine-generator if it is too much of a hassle to clone and run in Unity. It's completely free and should just run in the browser!

This app is:
- made with Unity
- designed to randomly generate a workout routine for you, depending on your preferences, that you can then follow along!

It was developed in order to make exercising less repetitive and more interesting.
You are currently able to adjust the duration, difficulty, whether you want a warmup or cooldown and which body area of focus you would like. If you aren't happy with the selection of excercises it picks, you can hit the refresh button to generate new ones. You can also copy the text version of the workout to the clipboard. 

Here is a preview of what it looks like - I'm no designer but I tried my best! Credit goes to "Modern UI Pack" by Michsky for the individual sliders and dropdowns. However, all the exercise demonstrations were drawn by hand...it took a long time (there are over 100 exercises).
 
<p align="center">
  <img src="Images/ScreenV2 1.png" height="250" title="Main Screen">
</p>

<p align="center">
  <img src="Images/ScreenV2 2.png" height="250" title="Select Duration and Difficulty Screen">
</p>

<p align="center">
  <img src="Images/ScreenV2 3.png" height="250" title="Select Focus and Workout Type Screen">
</p>

<p align="center">
  <img src="Images/ScreenV2 4.png" height="250" title="Overview Screen">
</p>

<p align="center">
  <img src="Images/ScreenV2 5.png" height="250" title="Inside a Workout Screen">
</p>

### How it works
The way the workouts are generated is quite simple. First, the exercises from the "database" (a list of objects in a C# script) are randomly shuffled. Then only the ones that match the user's preferences are picked, until there are enough to fulfill the duration of the workout. There is a small chance the exercises from the above/below difficulties are included too. Unity of course handles the graphical interface.

### Possible Future Extensions
There are some features I originally had planned, but sadly, I probably won't get around to them after all since I want to focus on other projects too.
- Import workout from text
- More exercises with gym equipment - right now it's more home-workout focused but could be extended to be used in the gym
- Similarly to this, properly add options for equipment and exercise types. The foundation for this was already implemented but there was not enough variety of exercises for it to be useful.

Feel free to email me at jrhammer50@gmail.com if you have any enquiries. And, thanks for checking out my app! -Jess
