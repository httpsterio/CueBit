#!/bin/bash

# Navigate to the solution directory (parent of this script)
cd "$(dirname "$0")/.."

# Set up paths
PUBLISH_DIR="Billiards Game/bin/Release/net8.0/osx-arm64/publish"
RELEASE_DIR="release"
APP_NAME="CueBit"
APP_DIR="$RELEASE_DIR/${APP_NAME}.app"
CONTENTS_DIR="$APP_DIR/Contents"
MACOS_DIR="$CONTENTS_DIR/MacOS"
RESOURCES_DIR="$CONTENTS_DIR/Resources"

# 1. Build the project
dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=false /p:IncludeNativeLibrariesForSelfExtract=true

# 2. Clean up any existing .app
rm -rf "$APP_DIR"

# 3. Create .app structure
mkdir -p "$MACOS_DIR"
mkdir -p "$RESOURCES_DIR"

# 4. Move published files into MacOS directory
cp -R "$PUBLISH_DIR/"* "$MACOS_DIR/"

# 5. Copy icon to Resources
cp "$PUBLISH_DIR/Content/cuebit.icns" "$RESOURCES_DIR/"

# Copy rest of Content (excluding cuebit.icns) to MacOS/Content
mkdir -p "$MACOS_DIR/Content"
rsync -a --exclude="cuebit.icns" "$PUBLISH_DIR/Content/" "$MACOS_DIR/Content/"


# 6. Create Info.plist
cat > "$CONTENTS_DIR/Info.plist" <<EOF
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" 
  "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleName</key>
    <string>CueBit</string>
    <key>CFBundleExecutable</key>
    <string>CueBit</string>
    <key>CFBundleIdentifier</key>
    <string>com.httpsterio.cuebit</string>
    <key>CFBundleVersion</key>
    <string>1.0.1</string>
    <key>CFBundlePackageType</key>
    <string>APPL</string>
    <key>CFBundleIconFile</key>
    <string>cuebit</string>
</dict>
</plist>
EOF

# 7. Rename main binary to match app name
mv "$MACOS_DIR/CueBit" "$MACOS_DIR/${APP_NAME}"

echo "✅ ${APP_NAME}.app created at $RELEASE_DIR/"

# 8. Cleanup bin directory
rm -rf "Billiards Game/bin"
echo "🧹 Cleaned up build artifacts."
