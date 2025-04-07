public class FloorRequest
{
    public int Floor { get; }
    public Direction Direction { get; }

    public FloorRequest(int floor, Direction direction)
    {
        Floor = floor;
        Direction = direction;
    }
}