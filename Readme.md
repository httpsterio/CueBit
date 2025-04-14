

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