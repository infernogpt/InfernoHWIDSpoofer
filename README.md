# HWID Spoofer by Inferno

![Downloads](https://img.shields.io/github/downloads/infernogpt/HwidSpoofer/total?style=for-the-badge&label=Downloads)
![Stars](https://img.shields.io/github/stars/infernogpt/HwidSpoofer?style=for-the-badge&label=Stars)
![Issues](https://img.shields.io/github/issues/infernogpt/HwidSpoofer?style=for-the-badge&label=Issues)
![License](https://img.shields.io/github/license/infernogpt/HwidSpoofer?style=for-the-badge&label=License)

![HWID Spoofer Screenshot](images/hwid-spoofer-screenshot.png)

## Introduction

HWID Spoofer by Inferno is a tool designed to spoof the HWID of your machine. It allows you to spoof, revert, back up, and restore your HWID with ease. This tool is perfect for testing and development purposes.

## Features

- **Spoof HWID**: Generate a random HWID to spoof your current one.
- **Revert HWID**: Revert to the original HWID.
- **Backup HWID**: Backup the current HWID for future restoration.
- **Restore HWID**: Restore the HWID from a backup.
- **Notifications**: Receive notifications for actions performed.
- **Status Indicator**: Visual indication of whether the HWID is spoofed or not.
- **Links**: Quick access to the GitHub repository and Azure Menu.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Windows operating system

### Installation

Download from the releases tabs of this repo

### Running the Application

1. Run the application

### Publishing the Application

To publish the project as a single executable, use the following command:
```sh
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```
This will create a single executable file located in the `bin\Release\net8.0\win-x64\publish` directory.

## Usage

### Spoofing HWID

1. Click the **Spoof HWID** button to generate and apply a random HWID.

### Reverting HWID

1. Click the **Revert to Original** button to revert to the original HWID.

### Backing Up HWID

1. Click the **Backup HWID** button to back up the current HWID.

### Restoring HWID

1. Click the **Restore HWID** button to restore the HWID from the backup.

### Accessing Links

1. Click the **GitHub Repo** link to visit the GitHub repository.
2. Click the **Get Azure Menu** link to visit the Azure Menu page.

## Screenshots

### Main Interface
![Main Interface](images/main-interface.png)

### Spoofed HWID
![Spoofed HWID](images/spoofed-hwid.png)

## Contributing

Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- Special thanks to all contributors and supporters.
- Inspired by various open-source projects.

## Contact

- **Author**: Inferno
- **GitHub**: [infernogpt](https://github.com/infernogpt)
- **Website**: [Azure Modding](https://dsc.gg/azuremodding)

---

![Footer Image](images/footer.png)
