# Calculator

A simple interactive console calculator built with **C#**. The application allows the user to enter two numbers, choose an arithmetic operation using the keyboard, and calculate the result without restarting the program.

This project was created as part of the **Simulation Academy .NET Diploma – Cycle 1** assignment.

## Features

- Perform the four basic arithmetic operations:
  - Addition (`+`)
  - Subtraction (`-`)
  - Multiplication (`*`)
  - Division (`/`)
- Enter two numbers directly from the keyboard.
- Supports decimal and negative numbers.
- Navigate between inputs and the operator using the arrow keys.
- Change the selected operation using the Up and Down arrow keys.
- Edit input using Backspace.
- Calculate the result using Enter.
- Handles invalid/incomplete input.
- Prevents division by zero.
- Perform multiple calculations without restarting the application.

## Controls

| Key | Action |
| --- | --- |
| `←` / `→` | Move between the first number, operator, and second number |
| `↑` / `↓` | Change the arithmetic operation |
| `0-9` | Enter numbers |
| `.` or `,` | Enter a decimal point |
| `-` | Toggle the sign of the selected number |
| `Backspace` | Delete the last entered character |
| `Enter` | Calculate the result |
| `Esc` | Exit the application |

## Technologies Used

- C#
- .NET Console Application
- Git & GitHub

## Project Structure

```text
Calculator/
├── Program.cs
├── Menu.cs
├── CalculatorInput.cs
├── Calculator.cs
├── .gitignore
└── README.md
```

### Main Components

- **`Calculator.cs`** – Contains the calculation logic and supported operations.
- **`CalculatorInput.cs`** – Handles user input, validation, selected operation, and result state.
- **`Menu.cs`** – Handles the interactive console UI and keyboard controls.
- **`Program.cs`** – Application entry point.

## How to Run

### Requirements

Install the **.NET SDK** on your machine.

### Steps

1. Clone the repository:

```bash
git clone <your-repository-url>
```

2. Open the project directory:

```bash
cd calculator
```

3. Run the application:

```bash
dotnet run
```

## Example

```text
==============================================
                Simple Calculator
==============================================

        [12.5]   +   [7.5]   =   [20]

        ← →   Move
        ↑ ↓   Change operation
        Enter Calculate
        Esc   Exit

==============================================
```

## Input Validation

The application handles common input problems, including:

- Missing first or second number.
- Invalid characters.
- Multiple decimal separators.
- Division by zero.

When an invalid calculation is attempted, a clear error message is displayed instead of terminating the application.


## Author

**Your Name**  
GitHub: [@iTz-DESPERADO](https://github.com/iTz-DESPERADO)

## License

This project was created for educational purposes as part of the Simulation Academy .NET Diploma assignment.
