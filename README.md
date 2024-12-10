# ApiVersioningApp

ApiVersioningApp is a demonstration of an ASP.NET Core Web API implementing multiple API versions with proper routing and functionality.

## Features

- **API Versioning**: Supports multiple API versions (`v2.0` and `v2.1`).
- **Dynamic Weather Forecasts**: Generates random weather forecast data for demonstration purposes.
- **Version-Specific Endpoints**:
  - **v2.0**: `/api/v2.0/WeatherForecast`
  - **v2.1**: `/api/v2.1/WeatherForecast`
- **Clean Architecture**: Implements controllers adhering to ASP.NET Core API standards.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- IDE of your choice (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Rider](https://www.jetbrains.com/rider/), or [Visual Studio Code](https://code.visualstudio.com/))

## Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/your-repo/ApiVersioningApp.git
2. Navigate to the project directory:
   ```bash
   cd ApiVersioningApp
3. Restore the dependencies:
   ```bash
   dotnet restore
4. Build the project:
   ```bash
   dotnet build
