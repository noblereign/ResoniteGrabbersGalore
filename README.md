# GrabbersGalore

A [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader) mod for [Resonite](https://resonite.com/) that allows you to add more Grabbers to your avatar.

## Usage
To make a new grabber, follow these steps:
1. Make a new slot for your grabber.
2. Add a `DynamicVariableSpace` to the slot with the name `GrabbersGalore`.
3. Add a `DynamicValueVariable<bool>` to the slot, and set the `VariableName` to `Grabbing`.
4. Add a `Grabber` to the slot.
5. Set yourself as the `Grabber`'s `AutoUpdateUser`.
Now the Grabber will attempt a grab once the variable is toggled on. It will release once it's toggled off.

## Screenshots
TBA

## Installation
1. Install [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader).
1. Place [ExampleModName.dll](https://github.com/YourGithubUsername/YourModRepoName/releases/latest/download/ExampleModName.dll) into your `rml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\Resonite\rml_mods` for a default install. You can create it if it's missing, or if you launch the game once with ResoniteModLoader installed it will create this folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Resonite logs.
