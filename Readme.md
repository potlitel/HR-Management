# HR-Management

## Description

HR-Management is a simple sample web API project that simulates a HR Management System Application.

<img src="images/Resume.gif" alt="Logo" width="840" height="480">

### Built With

- [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- [Dapper](https://www.nuget.org/packages/Dapper/)
- [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient/5.1.1)

## Table of Contents:

- [Prerequisites](#Prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Credits](#credits)
- [License](#license)

### Prerequisites

1. First you need to check if you have installed the .NET Core 3.1 SDK with the following .NET CLI (Command-Line Interface) command:

   ```sh
   dotnet --version
   ```

   If your version is not 3.1, [download the .NET Core 3.1 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) and install it on your machine.

2. Install Visual Studio Code editor (also know as VSCode).

3. Once Visual Studio Code is open, install the REST Client extension.

4. Finally, install the C# extension to get IntelliSense features in VSCode.

## Installation

What are the steps required to install your project? Provide a step-by-step description of how to get the development environment running.

1. Clone the repo
   ```sh
   git clone https://github.com/potlitel/HR-Management.git
   ```
2. Install NPM packages
   ```sh
   npm install
   ```
3. Enter your API in `config.js`
   ```js
   const API_KEY = "ENTER YOUR API";
   ```

## Usage

Provide instructions and examples for use. Include screenshots as needed.

To add a screenshot, create an `assets/images` folder in your repository and upload your screenshot to it. Then, using the relative filepath, add it to your README using the following syntax:

    ```md
    ![alt text](assets/images/screenshot.png)
    ```
