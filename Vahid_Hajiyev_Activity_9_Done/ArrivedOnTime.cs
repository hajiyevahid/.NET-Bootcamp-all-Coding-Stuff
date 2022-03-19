namespace CSharp.Activity.Events
{
    public class ArrivedOnTime
    {
        public void Arrival(object obj, ArrivalEventArgs e)
        {
            Console.WriteLine("The train " +e.TrainNumber + " " + e.arrivalStatus.ToString() + " at " + e.arrivalTime.ToString("hh:mm") + " o'clock.");
        }
    }
}
