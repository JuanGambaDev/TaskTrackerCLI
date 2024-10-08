
# Task Tracker CLI

A simple command line interface (CLI) application for tracking tasks, built in C#. This tool allows users to manage their tasks by adding, updating, deleting, and marking tasks as in progress or done. 

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Commands](#commands)
- [Task Properties](#task-properties)
- [Error Handling](#error-handling)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

## Features

- Add, update, and delete tasks.
- Mark tasks as "in progress" or "done."
- List all tasks, or filter by status (done, not done, in progress).
- Store tasks in a JSON file in the current directory.
- Simple command line interface for easy interaction.

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/JuanGambaDev/TaskTrackerCLI.git
   cd TaskTrackerCLI
   ```

2. **Set up your development environment:**
   - Ensure you have [Visual Studio](https://visualstudio.microsoft.com/) or any C# compatible IDE installed.
   - Open the project in your chosen IDE.

3. **Build the project:**
   - Use the build option in your IDE or run the following command:
   ```bash
   dotnet build
   ```

## Usage

Run the application from the command line with the desired command. The CLI supports various commands for managing tasks.

## Commands

- **Add a new task:**
  ```bash
  dotnet run add "Task description"
  ```

- **Update a task:**
  ```bash
  dotnet run update <task_id> "New task description"
  ```

- **Delete a task:**
  ```bash
  dotnet run delete <task_id>
  ```

- **Mark a task as in progress:**
  ```bash
  dotnet run mark-in-progress <task_id>
  ```

- **Mark a task as done:**
  ```bash
  dotnet run mark-done <task_id>
  ```

- **List all tasks:**
  ```bash
  dotnet run list
  ```

- **List tasks by status:**
  ```bash
  dotnet run list done
  dotnet run list todo
  dotnet run list in-progress
  ```

## Task Properties

Each task has the following properties:

- `id`: A unique identifier for the task.
- `description`: A short description of the task.
- `status`: The status of the task (todo, in-progress, done).
- `createdAt`: The date and time when the task was created.
- `updatedAt`: The date and time when the task was last updated.

## Error Handling

The application gracefully handles errors and edge cases, such as invalid inputs, non-existent task IDs, and file read/write errors. Users will receive informative messages to guide them in correcting their actions.

## Project Structure

```
task-tracker-cli/
│
├── Program.cs         # Main entry point of the application
├── model/Task.cs            # Model representing a task
├── services/TaskManager.cs     # Handles task operations
└── tasks.json         # JSON file for storing tasks
```

## Technologies Used

- C#
- .NET 
- JSON for data storage

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you find any bugs or have suggestions for improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Acknowledgements

This project was inspired by a coding challenge from [Roadmap.sh](https://roadmap.sh/projects/task-tracker).
