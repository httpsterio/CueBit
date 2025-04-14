# CueBit
CueBit is an 8bit inspired pool game for Win/Mac/Linux built with [Jypeli 11.3.7](https://github.com/Jypeli-JYU/Jypeli) and .NET 8.0.15.

It was created in 2020 as my course final project, which also explains the slightly messy code. I hope you have fun with it though!

If you find any bugs, please create an issue or ping me on Mastodon (sami @ social.lol)!

## Controls

- Mouse for aiming
- Left mouse button to charge up hit power
- R-key to reset the game

## Rules

You have to bag all the balls, but if you bag the black ball while still having other balls on the table, you lose.

Each shot drops your score, the fewer shots you take, the higher your score. Bagging the white ball drops your score by 5.

## Building for Windows

Install the .NET 8.0 or .NET 10 SDK for Windows from https://dotnet.microsoft.com/

Building with [Jetbrains Rider](https://www.jetbrains.com/rider/) recommended.

You can either build a self-contained or framework-dependent version of the game (meaning whether to bundle the .net runtime or not).

Use the supplied config files in .run/ or create a new configuration: 

- Run in top menu -> Edit Configuration
- Add new configuration -> Publish to folder
- Target location: recommended /path/to/project/CueBit/release
- Configuration: Release | Any CPU
- Target framework: net8.0
- Deployment mode: Framework Dependent or Self-Contained
- Target runtime: win-x64
- Enable ReadyToRun compilation: true
- __Trim unused assemblies: false__
- Produce single file: true
- Include native libraries for self extract: true
- Include all content for self extract: true
- Delete existing files: optional, true recommended.

When you run the configuration, you should end up with a single .exe file in the target folder. The .pdb file can be removed.

## Building for Mac

Install the .NET 8.0 SDK for Arm64 from https://dotnet.microsoft.com/en-us/download/dotnet/8.0
(.NET 10 Preview should also work)

chmod the build script

```bash
chmod +x build/build_mac.sh
```

and then run the build script

```bash
./build/build_mac.sh
```

the CueBit.app should be created in /release/