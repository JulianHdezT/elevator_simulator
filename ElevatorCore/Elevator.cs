using System;
using System.Collections.Generic;
using System.Linq;

public class Elevator
{
    public int CurrentFloor { get; private set; } = 1;
    public Direction MovementDirection { get; private set; } = Direction.Idle;
    public bool DoorsOpen { get; private set; } = false;

    private readonly HashSet<int> internalRequests = new();
    private readonly Queue<FloorRequest> externalRequests = new();

    public void RequestFloor(int floor)
    {
        internalRequests.Add(floor);
    }

    public void CallElevator(int floor, Direction direction)
    {
        externalRequests.Enqueue(new FloorRequest(floor, direction));
    }

    public void Step()
    {
        if (DoorsOpen)
        {
            CloseDoors();
            return;
        }

        if (internalRequests.Contains(CurrentFloor))
        {
            internalRequests.Remove(CurrentFloor);
            OpenDoors();
            return;
        }

        var matchingExternal = externalRequests.FirstOrDefault(r => r.Floor == CurrentFloor);
        if (matchingExternal != null)
        {
            externalRequests.Dequeue();
            OpenDoors();
            return;
        }

        var allRequests = internalRequests.Concat(externalRequests.Select(r => r.Floor)).ToList();
        if (!allRequests.Any())
        {
            MovementDirection = Direction.Idle;
            return;
        }

        int target = allRequests.OrderBy(f => Math.Abs(f - CurrentFloor)).First();
        MovementDirection = target > CurrentFloor ? Direction.Up : Direction.Down;
        MoveElevator();
    }

    private void MoveElevator()
    {
        if (MovementDirection == Direction.Up)
            CurrentFloor++;
        else if (MovementDirection == Direction.Down)
            CurrentFloor--;
    }

    private void OpenDoors() => DoorsOpen = true;
    private void CloseDoors() => DoorsOpen = false;
}