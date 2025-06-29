# LibraryManager

## About

**LibraryManager** is a desktop application that helps users manage their personal book collections and share them with a community. It allows users to register books and journals, track their physical locations on bookshelves, and manage borrowing and lending activities with other users in the system.

Key features of the application include:
- Book and journal registration with physical location tracking.
- User-to-user lending with borrow/return registration.
- Global collection search and reservation system across the user community.
- A built-in assistant ("Clippy") that offers context-sensitive help when pressing `F1`.

### Technologies Used
- **.NET** with **WPF** for the desktop user interface.
- **Entity Framework Core** (Database First approach) for ORM and database handling.
- **MySQL** cloud-hosted on **Aiven** as the primary database.
- **C#** as the main programming language.

The application performs standard **CRUD operations** (Create, Read, Update, Delete) on the database entities using Entity Framework Core.

### Architectural Notes
The project follows the **MVVM (Model-View-ViewModel)** design pattern for clear separation of concerns:
- **Model** – Entity classes and database context (via Entity Framework Core).
- **View** – WPF UI components (XAML files).
- **ViewModels** – Logic and data-binding between the UI and model.
- **Services** – Helper classes and business logic (e.g., Clippy assistant behavior).

This modular architecture improves testability, maintainability, and scalability.

## Installation

To install and run the LibraryManager application:

1. Download the setup file from the `Installer` folder of this repository:  
   [`Installer/LibraryManagerSetup.msi`]

2. Double-click `LibraryManagerSetup.msi` to launch the installer.

3. Follow the on-screen instructions to complete the installation.

4. Once installed, you can launch **LibraryManager** from the Start Menu. 

## Getting Started (Developers)

To run the project locally:

1. Clone the repository:
   ```bash
   git clone https://github.com/AS-Systems/2025_DSA_S8_POTEREJKO
   cd LibraryManager
Restore NuGet packages and build the solution in Visual Studio.

## Usage
Once started, the user can:

- Register or log in.

- Add books and assign them to shelves.

- Browse their collection or search the global catalog.

- Reserve, borrow, and return books.

- Use Clippy (F1) for help throughout the app.