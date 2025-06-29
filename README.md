# SimulationInstances

**SimulationInstances** is a Unity project demonstrating how to run multiple independent simulations concurrently within a single Unity runtime. Development was completed in just a few hours, including time spent refreshing Unity syntax and API knowledge after a break.

## Project Overview

A hypothetical design question inspired this project:
*“How would you run multiple simulations simultaneously within a single Unity runtime, each with support for different input methods—including autonomous input?”*

The current implementation focuses on a modular architecture, with planned support for the following features:

* **Additive Scene Loading** – enabling dynamic loading and unloading of simulation scenes.
* **ECS-driven Objective Spawner** – for efficiently managing and distributing simulation objectives.
* **ECS-based Scene Manager** – acts as a configuration hub to dynamically add or remove simulations using a factory pattern driven by ScriptableObject data.
* **ECS-based Simulation Logger** – tracks and records the final score results of each simulation instance for analysis and comparison.

## Implemented Features

* **Dynamic Input Handler**
  Accepts any class derived from the `InputStrategy` base, supporting runtime hotswapping. Two input strategies are currently implemented:

  * **Input Bindings Strategy** – maps user input to movement actions.
  * **Random Input Strategy** – provides random decision-making for automated simulations.

* **Objective System**
  A lightweight scoring framework built around an `IObjective` interface. An example implementation, `TouchObjective`, is provided, triggering a score when interacted with, assuming it is enabled and active in the scene.
