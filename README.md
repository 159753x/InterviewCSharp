# Worker Time Entry Application

## Overview

This repository contains a solution with two C# projects designed to handle and visualize worker time entry data. The solution is structured to include a shared code module for common logic and two separate projects that utilize this shared code.

### Folder Structure

```
WorkerTimeEntryApp/
├── src/
│   ├── VisualizationHTML/          // First C# project | Console Application
│   │   ├── Program.cs              // Entry point
│   │   ├── VisualizationHTML.csproj
│   │   └── (Other VisualizationHTML files)
│   ├── VisualizationPNG/                   // Second C# project Console App
│   │   ├── Program.cs              // Entry point
│   │   ├── VisualizationPNG.csproj
│   │   └── (Other VisualizationPNG files)
│   └── SharedCodeLibrary/          // Shared code module with common logic
│       ├── SharedCode.csproj       // Project file for the shared code library
│       ├── Model/
│       │   └── EmployeeTime.cs
│       │   └── TimeEntry.cs
│       ├── Controller/
│       │   └── FetchDataController.cs  // Fetches data from API endpoint
|       |   └── GeneratingDataHTMLTaskController.cs
|       |   └── GeneratingHTMLContentController.cs
|       |   └── HtmlFileController.cs  // Generates HTML file for data visualization
|       |   └── GenerateDataPNG.cs
|       |   └── ImagePNGController.cs  // Generates PNG file for data visualization
│       └── View/
│           
└── WorkerTimeEntryApp.sln          // Solution file
```
#### Explanation of Folder Structure
src/: Contains the source code for all projects in the solution.

VisualizationHTML/: The first application project.

VisualizationPNG/: The second application project.
SharedCode/: A class library project containing shared models, controllers, and views used by both VisualizationHTML/ and VisualizationPNG.

WorkerTimeEntryApp.sln: The solution file that includes all the projects and test projects.

#### Also View module is empty because It was logical for me to put making of static HTML file or PNG file as a controller as it's only for representation of data and it's not rendering like a front-end service.

## Solution Description

### VisualizationHTML

- **Type**: Console Application
- **Description**: This project demonstrates the use of the shared code to generate an HTML report based on worker time entry data. It uses `SharedCodeLibrary` to process data and generate the HTML file. Resulting HTML file will be in InterviewCSharp\VisualizationHTML\bin\Debug\net8.0 with title 'time_entries.html'.

### VisualizationPNG

- **Type**: Console Application
- **Description**: This project demonstrates the use of the shared code to generate an HTML report based on worker time entry data in form of Pie Chart on PNG image file. It uses `SharedCodeLibrary` to process data and generate the PNG file. Resulting PNG file will be in InterviewCSharp\VisualizationPNG\bin\Debug\net8.0 with title 'PieChart.png'.

### SharedCode

- **Type**: Class Library
- **Description**: This module contains the shared code used by both `VisualizationHTML` and `VisualizationPNG`. It includes models, controllers, and views related to worker time entry data.
- **Dependencies**: This library depends on Newtonsoft.Json package which can be downloaded and installed through VS or through cmd (for Windows) and on System.Drawing.Common (it is installed in same way as Newtonsoft.Json)
    #### Description on how to install it:
    _Method 1: Using Visual Studio's NuGet Package Manager_
  
  
    Open Visual Studio:          
    Open your C# project or solution in Visual Studio.
    Manage NuGet Packages:
    
    Right-click on the project in the Solution Explorer.
    Select Manage NuGet Packages.
    Browse for Newtonsoft.Json:
    
    Go to the Browse tab.
    Search for Newtonsoft.Json.
    Install the Package:
    
    Select Newtonsoft.Json from the search results.
    Click the Install button.
    Review and accept any license agreements if prompted.
    Verify Installation:
    
    Check the Installed tab to ensure that Newtonsoft.Json is listed as an installed package.
  
    _Method 2: Using the .NET CLI_

  
    Open a Command Prompt or Terminal:
    
    Open a command prompt (Windows) or terminal (macOS/Linux).
    Navigate to the Project Directory:
    
    Use the cd command to navigate to the directory containing your project file (.csproj).
    Install the Package:
    
    Run the following command to install
  ```dotnet add package Newtonsoft.Json```


## Instructions

### Cloning the Repository

To clone the repository and get started with the projects, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/159753x/InterviewCSharp.git
   ```

2. **Navigate to the Solution Directory**
3. **Open the Solution in Visual Studio**
4. **Build and Run Projects**

