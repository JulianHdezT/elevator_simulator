# Elevator Simulation in Blazor (.NET 8)

This project simulates a 5-floor elevator system using a clean object-oriented design and a real-time Blazor Server interface.

## 🧱 Project Structure

```
ElevatorSimulation/
├── ElevatorCore/          # Elevator logic (OO design)
├── ElevatorWeb/           # Blazor Server UI with graphical simulation
```

## 🚀 Features

- Elevator state: current floor, direction, doors
- Internal panel (buttons 1-5)
- External call buttons (Up/Down)
- Visual elevator shaft and animated movement
- Periodic state updates (1s tick)

## 🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or Visual Studio Code

## 🧪 Run the Project

1. Extract the ZIP and open the solution folder.
2. Open a terminal in the `ElevatorWeb` folder.
3. Run the Blazor Server app:

```bash
dotnet run
```

4. Open your browser and navigate to:

```
https://localhost:5001/elevator
```

## 📦 Projects

### ElevatorCore
Contains:
- `Elevator.cs` – elevator state machine
- `Direction.cs` – direction enum
- `FloorRequest.cs` – request model

### ElevatorWeb
Contains:
- `ElevatorService.cs` – background timer and logic bridge
- `Pages/Elevator.razor` – UI page with internal/external buttons and visualization
- `wwwroot/css/app.css` – animation and layout styles

## 📌 Notes

- Uses `System.Timers.Timer` for periodic updates.
- UI updates on each state change via `StateHasChanged()`.

---

Enjoy simulating! 🛗