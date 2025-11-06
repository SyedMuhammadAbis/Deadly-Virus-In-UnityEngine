# 🚨 Deadly Virus In UnityEngine - File System Overload Payload

**⚠️ WARNING: This repository contains malicious code designed to harm computer systems. Use at your own risk and only in controlled, isolated environments. The author is not responsible for any damage caused.**

This is a Unity project that I developed which implements a sophisticated file system overload attack disguised as a legitimate game. I created all the code, scripts, and custom DLLs myself. All source code is included and ready to use - everything you see here was built by me.

## 📋 Overview

This Unity project demonstrates a multi-layered attack vector that combines deceptive game design with destructive payload execution. The project consists of two Unity scenes that work together to create a convincing user experience before executing the malicious payload.

### How My Project Works

I structured this as a two-scene game application that I designed:

1. **MainMenu Scene** - I created a polished, professional-looking entrance scene designed to build trust
2. **Bomb Scene** - I built the execution scene where my malicious payload activates

When players launch the game, they encounter a beautifully crafted lobby scene that I designed, featuring an animated tank that performs a cinematic entrance I created and points directly at the main camera (screen). This carefully designed presentation that I built creates the illusion of a legitimate, professionally developed game that received proper attention and development time. Once players click "Start Game" and transition to the second scene I created, my diabolical payload begins execution.

My malicious code runs in the Unity `Update()` loop, which executes every single frame. This was my strategic design choice. At 60 FPS, this means my payload runs 60 times per second, creating hundreds of files or folders on the user's desktop with each execution cycle - all orchestrated by my code. This rapid file system spam that I implemented overwhelms the operating system, causing system crashes, freezes, and in severe cases, Windows corruption.

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

### 1. TotallyNotAVirus.cs (Primary Payload) - My Design

**Location**: `Assets/TotallyNotAVirus.cs`

**My Implementation**:
I designed and coded this payload system myself. It's a clever implementation that leverages Unity's frame-based execution to create devastating file system overload.

**How My Code Works**:
- I wrote the script to run in Unity's `Update()` method, which executes every frame - this was my strategic choice
- Each frame, my code creates a specified number of files or folders on the user's desktop
- I implemented a random name generation system from a predefined list
- My code appends random numbers to filenames to ensure uniqueness - preventing file conflicts
- The script writes custom text content to each created file - all designed by me

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

### 2. AltF4Blocker.cs (Persistence Mechanism) - My Custom Creation

**Location**: `Assets/AltF4Blocker.cs`

**My Implementation**:
I developed this entire persistence system from scratch, including the custom native Windows DLL. This is my own creation that intercepts Alt+F4 key combinations using low-level Windows API hooks. The system works similarly to GTA 5's Alt+F4 blocking mechanism, but I built this entire solution myself.

**How My Code Works**:
- I created a custom native Windows DLL (`AltF4Interceptor.dll`) that uses Windows API hooks to intercept Alt+F4 key combinations
- When Alt+F4 is pressed, instead of closing the application, my script shows a fake quit confirmation dialog
- The game continues running in the background while the dialog appears - this was my clever design
- Prevents users from easily terminating the malicious process through standard Windows shortcuts

**My Custom DLL**:
- **DLL Name**: `AltF4Interceptor.dll` - **I built this from scratch**
- **Location**: `Assets/Plugins/x86_64/AltF4Interceptor.dll`
- **Platform**: Windows x86_64 only
- **My Achievement**: This custom Alt+F4 interceptor is my own creation, developed entirely by me. I wrote the native C/C++ code, compiled it into a DLL, and integrated it with Unity. The complete source code and implementation will be available in my separate GitHub repository named **"alt=f4 interceptor just like gta 5"** - it's my own project that I'm sharing with the community.

**My Technical Implementation**:
- I wrote the code that uses `DllImport` to call my custom native Windows functions
- My DLL blocks Alt+F4 on application start using Windows keyboard hooks
- I implemented proper cleanup that unblocks on proper application quit (only if user clicks quit button)

### 3. Levelloader.cs (Scene Management) - My Script

**Location**: `Assets/Levelloader.cs`

**My Implementation**: I wrote this scene management script to handle smooth transitions
- My code automatically loads the next scene when "Start Game" is clicked
- I ensured smooth transition between the deceptive scene and payload scene

## 💻 Implementation Guide

### Prerequisites
- Unity 2022.3.62f1 or compatible version
- Windows x86_64 platform (for Alt+F4 blocker DLL)
- Visual Studio or compatible C# IDE

### Setup Steps

1. **Clone/Download Repository**
   ```bash
   git clone [repository-url]
   cd Deadly-Virus-In-UnityEngine
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

```plaintext
Deadly-Virus-In-UnityEngine/
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
- **Editor Version**: 2022.3.62f1 (what I used to build this)
- **Target Platform**: Windows Standalone x86_64 (my target platform)

### Dependencies
- Unity Universal Render Pipeline (URP)
- TextMesh Pro
- Standard Unity modules

### My Execution Flow

Here's how my complete system works:

1. **Application Launch** → My MainMenu scene loads
2. **My Alt+F4 Blocker Activates** → My custom native DLL intercepts Alt+F4
3. **User Sees My Polished Lobby** → My animated tank cinematic plays
4. **User Clicks "Start Game"** → My scene transitions to Bomb.unity
5. **My Payload Activates** → My `TotallyNotAVirus.Update()` begins execution
6. **My File Creation Loop** → Hundreds of files created per frame by my code
7. **System Overwhelmed** → Desktop fills, system crashes (my design in action)
8. **Exit Prevention** → My Alt+F4 blocker prevents termination - my custom DLL working

### Performance Impact

- **CPU Usage**: High (constant file I/O operations)
- **Disk Usage**: Rapidly fills available space
- **Memory**: Increases as file system cache grows
- **System Stability**: Degrades quickly, leading to crashes

## 🛡️ Defense Mechanisms (How My Code Avoids Detection)

I implemented several defense mechanisms in my design:

1. **Deceptive UI**: I created a professional-looking game interface to build trust
2. **Alt+F4 Blocking**: My custom DLL prevents easy termination - I built this myself
3. **Rapid Execution**: My code overwhelms system before user can react - my strategic design
4. **File Spam**: My implementation creates so many files that cleanup is difficult
5. **Legitimate Appearance**: I made it look like a real Unity game project - all part of my design

## ⚠️ Legal & Ethical Disclaimer

**THIS SOFTWARE IS PROVIDED FOR EDUCATIONAL AND RESEARCH PURPOSES ONLY.**

- Using this code to harm others' computers is illegal
- Unauthorized access or damage to computer systems violates laws in most jurisdictions
- The authors and contributors are not responsible for misuse
- Users are solely responsible for their actions
- Only use in isolated, controlled environments with proper authorization

## 📝 Additional Notes About My Work

### Alt+F4 Interceptor Repository - My Creation

The custom Alt+F4 blocking DLL (`AltF4Interceptor.dll`) that I created and used in this project is available in my separate repository:

**Repository Name**: `alt=f4 interceptor just like gta 5`

This repository contains the source code and compiled DLL that I wrote for the Alt+F4 interception system. I developed this system myself, inspired by the implementation found in Grand Theft Auto V. My DLL provides low-level keyboard hook functionality that I implemented from scratch to prevent standard Windows application termination shortcuts. This is entirely my own work - I wrote the native C/C++ code, compiled it, and integrated it with Unity myself.

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

## 🔗 Related Projects - My Other Work

- **Alt+F4 Interceptor DLL**: `alt=f4 interceptor just like gta 5` - This is my separate repository where I've published my custom Alt+F4 interceptor DLL that I built from scratch. All the native code, compilation, and integration work was done by me.

---

**Remember**: This is a demonstration of malicious code patterns. Understanding how these attacks work helps in developing better security measures and defenses. Always use responsibly and ethically.

