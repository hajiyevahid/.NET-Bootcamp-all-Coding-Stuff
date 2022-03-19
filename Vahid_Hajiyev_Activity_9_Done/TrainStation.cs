namespace CSharp.Activity.Events
{
    public class TrainStation
    {
        public event EventHandler<ArrivalEventArgs> Arrival;
        protected void OnArrival(ArrivalEventArgs e)
        {
            Arrival?.Invoke(this, e);
        }

        public void AnnounceArrival(int train, ArrivalEventArgs.ArrivalStatus arrivalStatus, DateTime arrivalTime)
        {
            OnArrival(new ArrivalEventArgs(train, arrivalStatus, arrivalTime));
        }
    }
}
