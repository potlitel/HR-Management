# HR-Management

## Description

HR-Management is a simple sample web API project that simulates a HR Management System Application.

<img src="images/Resume.png" alt="Logo" width="840" height="480">

- What was your motivation?
- Why did you build this project? (Note: the answer is not "Because it was a homework assignment.")
- What problem does it solve?
- What did you learn?

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

## Credits

List your collaborators, if any, with links to their GitHub profiles.

If you used any third-party assets that require attribution, list the creators with links to their primary web presence in this section.

If you followed tutorials, include links to those here as well.

## License

The last section of a high-quality README file is the license. This lets other developers know what they can and cannot do with your project. If you need help choosing a license, refer to [https://choosealicense.com/](https://choosealicense.com/).

---

🏆 The previous sections are the bare minimum, and your project will ultimately determine the content of this document. You might also want to consider adding the following sections.

## Badges

![badmath](https://img.shields.io/github/languages/top/lernantino/badmath)

Badges aren't necessary, per se, but they demonstrate street cred. Badges let other developers know that you know what you're doing. Check out the badges hosted by [shields.io](https://shields.io/). You may not understand what they all represent now, but you will in time.

## Features

If your project has a lot of features, list them here.

## How to Contribute

If you created an application or package and would like other developers to contribute it, you can include guidelines for how to do so. The [Contributor Covenant](https://www.contributor-covenant.org/) is an industry standard, but you can always write your own if you'd prefer.

## Tests

Go the extra mile and write tests for your application. Then provide examples on how to run them here.
