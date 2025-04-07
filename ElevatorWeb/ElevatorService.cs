using System;
using System.Timers;

public class ElevatorService : IDisposable
{
    public Elevator Elevator { get; } = new();
    private readonly System.Timers.Timer _timer;
    public event Action? OnChange;

    public ElevatorService()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += (_, _) =>
        {
            Elevator.Step();
            OnChange?.Invoke();
        };
        _timer.Start();
    }

    public void RequestFloor(int floor) => Elevator.RequestFloor(floor);
    public void CallElevator(int floor, Direction direction) => Elevator.CallElevator(floor, direction);
    public void Dispose() => _timer.Dispose();
}