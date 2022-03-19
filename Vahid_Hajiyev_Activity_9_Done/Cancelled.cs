namespace CSharp.Activity.Events
{
    public class Cancelled
    {
        public void Cancel(object obj, ArrivalEventArgs e)
        {
            Console.WriteLine("The train " + e.TrainNumber + " " + e.arrivalStatus.ToString() + ". Train will come on " + e.arrivalTime.AddDays(8).ToString("MM/dd/yyyy")+" at "+DateTime.Now.ToString("hh:mm") +" o'clock.");
        }
    }
}
