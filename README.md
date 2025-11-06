# 🚨 Deadly Unity Virus - File System Overload Payload

**⚠️ WARNING: This repository contains malicious code designed to harm computer systems. Use at your own risk and only in controlled, isolated environments. The author is not responsible for any damage caused.**

This is a Unity project that implements a sophisticated file system overload attack disguised as a legitimate game. All source code is included and ready to use.

## 📋 Overview

This Unity project demonstrates a multi-layered attack vector that combines deceptive game design with destructive payload execution. The project consists of two Unity scenes that work together to create a convincing user experience before executing the malicious payload.

### How It Works

The project is structured as a two-scene game application:

1. **MainMenu Scene** - A polished, professional-looking entrance scene designed to build trust
2. **Bomb Scene** - The execution scene where the malicious payload activates

When players launch the game, they encounter a beautifully crafted lobby scene featuring an animated tank that performs a cinematic entrance and points directly at the main camera (screen). This carefully designed presentation creates the illusion of a legitimate, professionally developed game that received proper attention and development time. Once players click "Start Game" and transition to the second scene, the diabolical payload begins execution.

The malicious code runs in the Unity `Update()` loop, which executes every single frame. At 60 FPS, this means the payload runs 60 times per second, creating hundreds of files or folders on the user's desktop with each execution cycle. This rapid file system spam overwhelms the operating system, causing system crashes, freezes, and in severe cases, Windows corruption.

## 🏗️ Project Structure

### Scene 1: MainMenu.unity
- **Purpose**: Deceptive entrance/lobby scene
- **Features**: 
  - Animated tank cinematic sequence
  - Tank points toward the main camera for dramatic effect
  - Professional UI and presentation
  - Alt+F4 blocker already active (prevents easy exit)
- **Strategy**: Builds user trust and lowers suspicion before payload activation

### Scene 2: Bomb.unity  
- **Purpose**: Payload execution scene
- **Features**:
  - Contains the `TotallyNotAVirus` script component
  - File creation system activated on scene load
  - Alt+F4 blocker continues to prevent termination
- **Payload**: Begins creating files/folders immediately upon scene activation

## 🔧 Technical Components

### 1. TotallyNotAVirus.cs (Primary Payload)

**Location**: `Assets/TotallyNotAVirus.cs`

**How It Works**:
- The script runs in Unity's `Update()` method, which executes every frame
- Each frame, it creates a specified number of files or folders on the user's desktop
- Files are created with random names from a predefined list
- Random numbers are appended to filenames to ensure uniqueness
- The script writes text content to each created file

**Configuration** (as seen in Bomb.unity):
- `numberOfItemsToCreate`: 400 (creates 400 items per frame)
- `createFiles`: true (creates files instead of folders)
- `fileExtension`: ".txt"
- `possibleNames`: List of custom names for files
- `includeRandomNumber`: true (adds random numbers to prevent conflicts)

**Impact Calculation**:
- At 60 FPS: 400 items × 60 frames = **24,000 files/second**
- Within 10 seconds: **240,000 files** on desktop
- System becomes unresponsive and crashes

### 2. AltF4Blocker.cs (Persistence Mechanism)

**Location**: `Assets/AltF4Blocker.cs`

**How It Works**:
- Uses a custom native Windows DLL (`AltF4Interceptor.dll`) to intercept Alt+F4 key combinations
- Similar functionality to GTA 5's Alt+F4 blocking system
- When Alt+F4 is pressed, instead of closing the application, it shows a fake quit confirmation dialog
- The game continues running in the background while the dialog appears
- Prevents users from easily terminating the malicious process

**Custom DLL**:
- **DLL Name**: `AltF4Interceptor.dll`
- **Location**: `Assets/Plugins/x86_64/AltF4Interceptor.dll`
- **Platform**: Windows x86_64 only
- **Note**: This custom Alt+F4 interceptor addon will be available in a separate GitHub repository named **"alt=f4 interceptor just like gta 5"**

**Implementation**:
- Uses `DllImport` to call native Windows functions
- Blocks Alt+F4 on application start
- Unblocks on proper application quit (only if user clicks quit button)

### 3. Levelloader.cs (Scene Management)

**Location**: `Assets/Levelloader.cs`

**Purpose**: Handles scene transitions from MainMenu to Bomb scene
- Automatically loads the next scene when "Start Game" is clicked
- Ensures smooth transition between deceptive scene and payload scene

## 💻 Implementation Guide

### Prerequisites
- Unity 2022.3.62f1 or compatible version
- Windows x86_64 platform (for Alt+F4 blocker DLL)
- Visual Studio or compatible C# IDE

### Setup Steps

1. **Clone/Download Repository**
   ```bash
   git clone [repository-url]
   cd Hasnain__Karma
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Open the project folder
   - Wait for Unity to import all assets

3. **Configure the Payload**
   - Open `Assets/Scenes/Bomb.unity`
   - Find the GameObject with `TotallyNotAVirus` component
   - Adjust parameters in Inspector:
     - `numberOfItemsToCreate`: Change intensity (default: 400)
     - `createFiles`: Toggle between files/folders
     - `fileExtension`: Customize file type
     - `possibleNames`: Add your custom file/folder names
     - `includeRandomNumber`: Enable/disable random suffixes

4. **Verify Alt+F4 Blocker**
   - Ensure `AltF4Interceptor.dll` exists in `Assets/Plugins/x86_64/`
   - Check that `AltF4Blocker.cs` is attached to GameObjects in both scenes
   - Test in Play mode to confirm Alt+F4 is blocked

5. **Build the Executable**
   - File → Build Settings
   - Select Windows platform
   - Click "Build"
   - Choose output directory
   - The built `.exe` will include all malicious components

### Customization Options

**Modify File Creation Rate**:
- Lower `numberOfItemsToCreate` for slower, more subtle attacks
- Increase for faster, more aggressive payload execution

**Change Target Location**:
- Edit `CreateRandomFilesOnDesktop()` method in `TotallyNotAVirus.cs`
- Change `System.Environment.SpecialFolder.Desktop` to other folders:
  - `MyDocuments`
  - `ProgramFiles` (requires admin)
  - Custom paths

**Customize File Names**:
- Edit the `possibleNames` list in Unity Inspector
- Add your own strings to personalize the attack

**Modify File Content**:
- Edit line 63 in `TotallyNotAVirus.cs`
- Change the text written to each file

## 📁 File Structure

```
Hasnain__Karma/
├── Assets/
│   ├── TotallyNotAVirus.cs          # Main payload script
│   ├── AltF4Blocker.cs              # Alt+F4 interceptor
│   ├── Levelloader.cs               # Scene transition handler
│   ├── GameManager.cs               # Game state manager
│   ├── Scenes/
│   │   ├── MainMenu.unity           # Deceptive entrance scene
│   │   └── Bomb.unity               # Payload execution scene
│   └── Plugins/
│       └── x86_64/
│           └── AltF4Interceptor.dll # Native Windows DLL
├── ProjectSettings/                 # Unity project configuration
└── Packages/                        # Unity package dependencies
```

## ⚙️ Technical Details

### Unity Version
- **Editor Version**: 2022.3.62f1
- **Target Platform**: Windows Standalone x86_64

### Dependencies
- Unity Universal Render Pipeline (URP)
- TextMesh Pro
- Standard Unity modules

### Execution Flow

1. **Application Launch** → MainMenu scene loads
2. **Alt+F4 Blocker Activates** → Native DLL intercepts Alt+F4
3. **User Sees Polished Lobby** → Animated tank cinematic plays
4. **User Clicks "Start Game"** → Scene transitions to Bomb.unity
5. **Payload Activates** → `TotallyNotAVirus.Update()` begins execution
6. **File Creation Loop** → Hundreds of files created per frame
7. **System Overwhelmed** → Desktop fills, system crashes
8. **Exit Prevention** → Alt+F4 blocked, difficult to terminate

### Performance Impact

- **CPU Usage**: High (constant file I/O operations)
- **Disk Usage**: Rapidly fills available space
- **Memory**: Increases as file system cache grows
- **System Stability**: Degrades quickly, leading to crashes

## 🛡️ Defense Mechanisms (How It Avoids Detection)

1. **Deceptive UI**: Professional-looking game interface
2. **Alt+F4 Blocking**: Prevents easy termination
3. **Rapid Execution**: Overwhelms system before user can react
4. **File Spam**: Creates so many files that cleanup is difficult
5. **Legitimate Appearance**: Looks like a real Unity game project

## ⚠️ Legal & Ethical Disclaimer

**THIS SOFTWARE IS PROVIDED FOR EDUCATIONAL AND RESEARCH PURPOSES ONLY.**

- Using this code to harm others' computers is illegal
- Unauthorized access or damage to computer systems violates laws in most jurisdictions
- The authors and contributors are not responsible for misuse
- Users are solely responsible for their actions
- Only use in isolated, controlled environments with proper authorization

## 📝 Additional Notes

### Alt+F4 Interceptor Repository

The custom Alt+F4 blocking DLL (`AltF4Interceptor.dll`) used in this project is available in a separate repository:

**Repository Name**: `alt=f4 interceptor just like gta 5`

This repository contains the source code and compiled DLL for the Alt+F4 interception system, similar to the implementation found in Grand Theft Auto V. The DLL provides low-level keyboard hook functionality to prevent standard Windows application termination shortcuts.

### Known Issues

- Windows Defender may flag the executable as malicious
- Some antivirus software may detect the file creation patterns
- System may require administrator privileges for certain file locations
- DLL may not work on all Windows versions

### Testing Recommendations

- Test in virtual machines only
- Use isolated test environments
- Never test on production systems
- Keep backups of important data
- Use snapshot/restore functionality in VMs

## 🔗 Related Projects

- Alt+F4 Interceptor DLL: `alt=f4 interceptor just like gta 5` (separate repository)

---

**Remember**: This is a demonstration of malicious code patterns. Understanding how these attacks work helps in developing better security measures and defenses. Always use responsibly and ethically.

