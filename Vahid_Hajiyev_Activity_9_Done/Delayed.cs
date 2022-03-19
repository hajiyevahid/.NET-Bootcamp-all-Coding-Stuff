namespace CSharp.Activity.Events
{
    public class Delayed
    {
        public void Delaying(object obj, ArrivalEventArgs e)
        {
            Console.WriteLine("The train "+e.TrainNumber+" "+e.arrivalStatus.ToString()+". Train will come at "+e.arrivalTime.AddMinutes(8).ToString("hh:mm")+" o'clock.");
        }
    }
}
