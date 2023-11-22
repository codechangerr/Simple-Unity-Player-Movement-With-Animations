# Simple-Unity-Player-Movement-With-Animations
A pretty straight forward script that allows animation with player movement in unity and included things like walk run crouch and crouch walk using WASD and arrows keys for moving around hold shift to run and c to crouch how ever you will need to set up an animation controller for this using bools names Walkling, Running, Crouch, and CrouchWalking

This will only work with a Cinemachine Freelook camera.

Animation Setup:

  Step 1: Download what ever animations you want from Mixamo.com.
  
  Step 2: Create an animation controller.
  
  Step 3: Create 4 emty states and there transistion these will be for the animations and have the default state as an idle state/animation.
  
  Step 4: Assign the animations for each state.
  
Player Setup:

  Step one assign the Player.cs script to the player;

  Step two you should see the reqirements for the script add a Playercontroller, Rigidbody doesnt actully need to be assigned cause it isnt used at all, and an animator with the controller drag and drop all these components into the script, A cinemachine freelook camrea add this to the scene tho then drag and drop it in.

Scene Setup:

  Create a Freelook camrea and assign the transform of the Player GameObject to the look at and follow parts of the component.
