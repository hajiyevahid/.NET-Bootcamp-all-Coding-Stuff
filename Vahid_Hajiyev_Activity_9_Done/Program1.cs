namespace CSharp.Activity.Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TrainStation trainStation = new TrainStation();
            TrainStation trainStation2 = new TrainStation();
            TrainStation trainStation3 = new TrainStation();

            ArrivedOnTime person1 = new ArrivedOnTime();
            Delayed person2 = new Delayed();
            Cancelled person3 = new Cancelled();

            //Person1's train is Arrived on time.
            trainStation.Arrival += person1.Arrival;
            trainStation.AnnounceArrival(1, ArrivalEventArgs.ArrivalStatus.Arriving, DateTime.Now);

            //Person 2's train is Delayed. 
            trainStation2.Arrival += person2.Delaying;
            trainStation2.AnnounceArrival(2, ArrivalEventArgs.ArrivalStatus.Delayed, DateTime.Now);

            //Person 3's train was cancelled.
            trainStation3.Arrival += person3.Cancel;
            trainStation3.AnnounceArrival(3, ArrivalEventArgs.ArrivalStatus.Cancelled, DateTime.Now);
        }
    }
}
