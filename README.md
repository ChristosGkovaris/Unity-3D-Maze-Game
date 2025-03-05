# Unity 3D Maze Game
Welcome to the "Unity 3D Maze Game" repository, an interactive 3D game designed as a learning project for the course Computer Graphics and Interaction Systems. This project explores fundamental concepts in game development using Unity and C# scripting. The final grade of the project is 93 (excluding the additional 50 bonus points) out of 100.



## Overview
The game is a 3D maze-based adventure where players control a character, "Treasure Bob" to navigate through a maze, collect treasures, and avoid traps. The project emphasizes gameplay mechanics, object interactions, and visual/audio enhancements to create an engaging experience.



## Key Features
- Interactive Maze Navigation: Players control "Treasure Bob" to move through the maze while avoiding walls.
- Dynamic Treasure Spawning: Randomly generated treasures with varying scores and visual effects.
- Score System: A live score tracker updates dynamically based on collected treasures.
- Trap Mechanics: Randomly spawning traps that end the game upon collision.
- Camera Controls: Free camera movement for exploring the maze environment.
- Visual and Audio Enhancements: Includes sound effects and visual cues for interactions.
- Game Over Screen: Clear feedback when the game ends.



## Implementation Details
- The maze is constructed using Unity's 3D objects: Floor->A textured plane (100x100) with a `floor.jpg` texture. Walls->Blue cubes
  (10x10x10) placed to form the maze structure.
- Treasure Bob: A spherical character (diameter 7) textured with `bob.jpg`. Bob is controlled with the keys `I`, `K`, `J`, `L` for directional movement. Movement is constrained within the maze using collision detection.
- Spawned at random locations with textures like cherries, lemons, and oranges. Each treasure type awards different points.
- Treasures shrink and disappear after being collected, with accompanying sound and visual effects.
- Randomly spawning spheres (`death.jpg` texture) that trigger the "Game Over" state when collided with.
- Fully controlled camera for exploring the maze: Movement with arrow keys or `W`, `A`, `S`, `D`. Vertical adjustment
  with `+` and `-`. Rotation with `R`.
- Adjustable movement speed for Treasure Bob using number keys (1–5).
- Real-time score updates displayed on the UI.



## Collaboration
This project was a collaborative effort. Special thanks to [SpanouMaria](https://github.com/SpanouMaria), for their significant contributions to the development and improvement of the game.
