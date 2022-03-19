namespace CSharp.Activity.Events
{
    public class ArrivalEventArgs
    {
        public enum ArrivalStatus
        {
            Arriving,
            Delayed,
            Cancelled
        }

        public int TrainNumber { get; private set; }
        public ArrivalStatus arrivalStatus { get; private set; }
        public DateTime arrivalTime { get; private set; }

        public ArrivalEventArgs(int num, ArrivalStatus status, DateTime time)
        {
            TrainNumber = num;
            arrivalStatus = status;
            arrivalTime = time;
        }
    }
}
