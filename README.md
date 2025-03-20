# C-_Zomato_app_Testing
Automated testing for the Zomato app using C#, Selenium, and Appium in a .NET environment. Supports login, profile management, and food ordering workflows on Android devices.


// Zomato Automation Project //

This project automates the Zomato app using "C# Selenium and Appium" in a .NET environment.

// Prerequisites //
Ensure the following software is installed before running the project:  

1️⃣ .NET 8.0 SDK
- Download from the official .NET website:  
  [Download .NET 8.0 SDK](https://download.visualstudio.microsoft.com/download/pr/6f043b39-b3d2-4f0a-92bd-99408739c98d/fa16213ea5d6464fa9138142ea1a3446/dotnet-sdk-8.0.407-win-x64.exe)  

2️⃣ Node.js
- Download from the official website:  
  [Download Node.js](https://nodejs.org/dist/v22.14.0/node-v22.14.0-x64.msi)  

3️⃣ Appium Inspector
- Download from GitHub:  
  [Download Appium Inspector](https://github.com/appium/appium-inspector/releases)  

4️⃣ Appium Server
- Download from GitHub:  
  [Download Appium Server GUI](https://github.com/appium/appium-desktop/releases)  

5️⃣ Universal ADB Driver
- Download from GitHub:  
  [Download Universal ADB Driver](https://github.com/koush/UniversalAdbDriver)  

---

Setup Instructions

1️⃣ Clone the Repository
```bash
git clone <repository-url>
```
Replace `<repository-url>` with the actual GitHub repository link.  

2️⃣ Open the Project in VS Code
For the best experience, use **Visual Studio Code**.  

3️⃣ Navigate to the Project Directory
Open a terminal and move to the directory where the `.sln` file resides:  
```bash
cd path/to/your/project
```

4️⃣ Install Required Dependencies
Run the following commands in the terminal to install the necessary .NET packages:  
```bash
dotnet add package Appium.WebDriver
dotnet add package Selenium.WebDriver
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

5️⃣ Connect Your Android Device
- **Enable USB Debugging** on your Android device.  
- Connect it to your machine via **USB**.  

6️⃣ Start the Appium Server
Run the following command to start Appium with debugging enabled:  
```bash
appium --log-level debug --relaxed-security
```

7️⃣ Run the Automation Scripts
- Open another terminal.  
- Navigate to the directory where the `.sln` file is located.  
- Run the tests using:  
```bash
dotnet test
```

---

// Notes //
- Ensure that **Appium Inspector** is correctly set up to inspect UI elements.  
- If running into **device connection issues**, verify ADB is working by running:  
  ```bash
  adb devices
  ```  
- If **Appium does not start**, check logs using:  
  ```bash
  appium --log-level info
  ```  
 

---
