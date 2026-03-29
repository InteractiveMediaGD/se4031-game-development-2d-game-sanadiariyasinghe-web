Galactic Navigator: 2D Space Survival

## Overview
Galactic Navigator is an interactive 2D space-themed survival game developed using the Unity Engine. The project features a physics-driven player controller where the user must navigate a UFO through a hazardous environment of pipes and moving fireballs.
Developed as part of the SE4031: 2D Game Development module, this project demonstrates core game architecture principles, including Dynamic Difficulty Scaling (DDS), Object Instantiation, and Real-time UI Synchronization.

## Features
•	Dynamic Difficulty Scaling (DDS): The game speed and obstacle frequency increase automatically based on the player's score milestones (every 10 points) and elapsed time.
•	Combat & Defense System: Unlike traditional "avoidance" games, players can fire projectiles using the 'Z' key to destroy incoming fireballs.
•	Robust Health System: Features a 100-point health pool with Invincibility Frames (I-Frames) using C# Coroutines to prevent instant death upon collision.
•	Adaptive HUD (Heads-Up Display): The health UI dynamically changes color (White → Yellow → Red) to provide immediate visual feedback on the player's status.
•	Memory Optimization: Implemented a "Deadzone" cleanup system that destroys off-screen objects to prevent memory leaks and maintain high performance.

## Project Workflow
1.	Input Polling: The system listens for Space (Jump) and Z (Shoot) inputs during the Update loop.
2.	Physics Processing: Rigidbody2D handles gravity and upward impulses, ensuring smooth, physics-based movement.
3.	State Management: A centralized Logic Manager tracks the score, health, and global speed multipliers.
4.	Collision Matrix: The game uses Tags (FireBall, HealthPack, Pipe) to trigger specific logic events—such as damage, healing, or score increments—upon collision.

