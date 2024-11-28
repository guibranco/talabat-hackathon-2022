# Talabat Hackathon 2022

🏃 💡 Talabat Hackathon project that translates and generates audio (voice) of menu items in the [Talabat](https://talabat.com) app into many languages using AWS Polly.

[![GitHub license](https://img.shields.io/github/license/guibranco/talabat-hackathon-2022)](https://github.com/guibranco/talabat-hackathon-2022)
[![wakatime](https://wakatime.com/badge/github/guibranco/talabat-hackathon-2022.svg)](https://wakatime.com/badge/github/guibranco/talabat-hackathon-2022)
[![Build](https://github.com/guibranco/talabat-hackathon-2022/actions/workflows/build.yml/badge.svg)](https://github.com/guibranco/talabat-hackathon-2022/actions/workflows/build.yml)
[![Sonar Cloud Analysis](https://github.com/guibranco/talabat-hackathon-2022/actions/workflows/sonar-cloud.yml/badge.svg)](https://github.com/guibranco/talabat-hackathon-2022/actions/workflows/sonar-cloud.yml)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/talabat-hackathon-2022/main)](https://github.com/guibranco/talabat-hackathon-2022)

## Code Quality

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022) 

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=coverage)](https://sonarcloud.io/summary/new_code?id=guibranco_talabat-hackathon-2022)
[![CodeFactor](https://www.codefactor.io/repository/github/ApiBR/vagas-aggregator-ui/badge)](https://www.codefactor.io/repository/github/ApiBR/vagas-aggregator-ui)

[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)

[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_talabat-hackathon-2022&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_talabat-hackathon-2022)

[![Maintainability](https://api.codeclimate.com/v1/badges/de125cc7994282bf050c/maintainability)](https://codeclimate.com/github/guibranco/talabat-hackathon-2022/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/de125cc7994282bf050c/test_coverage)](https://codeclimate.com/github/guibranco/talabat-hackathon-2022/test_coverage)

---

## About the Project

This **C# project** is a **web REST API** designed to enhance the Talabat app by:

1. **Real-Time Translations**: Translate menu/catalog descriptions into multiple languages using [AWS Translate](https://aws.amazon.com/translate/).
2. **Text-to-Speech**: Generate audio for menu items using [AWS Polly](https://aws.amazon.com/polly/).

### Features
- Translates menu items dynamically into the language of the user's choice.
- Provides an audio version of menu items for accessibility.
- Seamlessly integrates into the Talabat app ecosystem.

---

## Tech Stack

- **Language**: C#
- **Framework**: ASP.NET Core
- **Cloud Services**:
  - `AmazonTranslateClient` for translations.
  - `AmazonPollyClient` for text-to-speech functionality.

---

## Installation and Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/guibranco/talabat-hackathon-2022.git
   cd talabat-hackathon-2022
   ```

2. Install dependencies and build the project:
   ```bash
   dotnet restore
   dotnet build
   ```

3. Configure AWS credentials:
   - Use the AWS CLI to set up your credentials.
   - Alternatively, set environment variables for AWS access key and secret.

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API at `http://localhost:<port>`.

---

## API Endpoints

### Text-to-Speech
- **POST** `/api/text-to-speech`
- **Body**:
  ```json
  {
    "text": "Sample text to convert to speech",
    "voice": "Preferred AWS Polly voice ID (optional)"
  }
  ```
- **Response**:
  - A stream of audio data or a URL to download the generated audio file.

### Translation
- **POST** `/api/translate`
- **Body**:
  ```json
  {
    "text": "Sample text to translate",
    "targetLanguage": "es"
  }
  ```
- **Response**:
  - A JSON object containing the translated text.

---

## Contributing

Contributions are welcome! Please submit issues or pull requests via the [GitHub repository](https://github.com/guibranco/talabat-hackathon-2022).

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
