# zutari-unity-2023-Matthew-Cresswell
Interview project for Zutari Engineering

Process Description:

- Created a Main Menu scene, Level 1 Scene and WeatherApp Scene
- Made all scenes linkable through UI buttons on the Main Menu scene

- LEVEL 1
  - Added a cube controller script for the cube that allows it to move along the x & y axis
  - Created a function that changes the cube's colour when the WASD & arrow keys are pressed
  - Create a screen boundary object that has a box collider attached
  - On the screen boundary object create a script that creates a screen boundary the size of your camera
  - Sets the size of the screen boundary by applying the orthographic size of camera * 2 to a float and then set the size of the collider to the calculated sizes.
  - Create a function to check if an object is out of the bounds of the screen
  - Create a function that places objects on the opposite side of the screen if a boundary is crossed.
  - In the update function of the cube controller script run a check to see if the cube is out of screen bounds. If the cube is out of bounds reposition the cube using the function to place an object on the opposite side of the screen. If not out of bounds keep the cube in the same position.
  - Create a function that allows cubes speed to change when press J & K or with buttons
 
- WEATHER APP
    - Create Coroutine.
    - Coroutine assigns the Open Weather API url for each location to a string url variable.
    - Fetch the data from the URL
    - Check to make sure there are no connection errors
    - if all is good parse the simpleJson code supplied by openWeahter to text.
    - Assign the response to the variables required such as location, country name, weahter etc.
    - Assign functions to buttons of each provincial capital to gain API info based on the locations ID.
