# AMP Automation Assessment

This project contains manual testing documentation and automated tests for the SauceDemo application.

Application under test:  
https://www.saucedemo.com/

## Technology Stack

- C#
- .NET 9
- Microsoft Playwright
- NUnit
- Page Object Model
- JSON test data

## Project Structure

```text
amp-assesment-AhmedOsman/
├── README.md
├── AMP.AutomationTests.sln
└── AMP.AutomationTests/
    ├── Docs/
    │   ├── Evidence/
    │   ├── BugReport.md
    │   ├── ManualTestCases.md
    │   ├── Summary.md
    │   └── TestScenarios.md
    ├── Helpers/
    │   ├── ExpectationHelper.cs
    │   ├── TestBase.cs
    │   └── TestDataReader.cs
    ├── PageObjects/
    │   ├── CartPO.cs
    │   ├── CheckoutPO.cs
    │   ├── InventoryPO.cs
    │   └── LoginPO.cs
    ├── TestData/
    │   └── testData.json
    ├── Tests/
    │   ├── CheckoutTests.cs
    │   └── LoginTests.cs
    ├── AMP.AutomationTests.csproj
    ├── AMP.runsettings
    └── GlobalUsings.cs
```

## Prerequisites

Before running the tests, install:

- .NET 9 SDK
- Visual Studio 2022 or another compatible IDE
- PowerShell

## Running the Tests Locally

### 1. Clone the repository

```bash
git clone https://github.com/ahmed-osman-qa/amp-assesment-AhmedOsman.git
cd amp-assesment-AhmedOsman
```

### 2. Navigate to the test project

```bash
cd AMP.AutomationTests
```

### 3. Restore the project dependencies

```bash
dotnet restore
```

### 4. Build the project

```bash
dotnet build
```

### 5. Install the Playwright browsers

On Windows PowerShell:

```powershell
pwsh bin/Debug/net9.0/playwright.ps1 install
```

This step is normally required only after the first build or after updating Playwright.

### 6. Run all automated tests

```bash
dotnet test
```

To use the included run settings file:

```bash
dotnet test --settings AMP.runsettings
```

## Running Tests in Visual Studio

1. Open `AMP.AutomationTests.sln` in Visual Studio.
2. Build the solution.
3. Open **Test Explorer** from **Test > Test Explorer**.
4. Select **Run All Tests**.

## Automated Test Coverage

The automated tests include:

- Successful login
- Locked-out user login validation
- Invalid-credentials validation
- Successful checkout with valid customer information

## Test Data

Test data is stored in:

```text
AMP.AutomationTests/TestData/testData.json
```

This file contains user credentials and checkout customer information.

## Test Documentation

The manual testing documentation is available in:

```text
AMP.AutomationTests/Docs
```

The documentation includes:

- `TestScenarios.md` — high-level test scenarios
- `ManualTestCases.md` — detailed manual test cases
- `BugReport.md` — documented issue found during testing
- `Summary.md` — assessment approach and framework summary