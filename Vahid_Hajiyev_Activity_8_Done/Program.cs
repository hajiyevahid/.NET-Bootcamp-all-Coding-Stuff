using System.Text;
namespace CSharp.Activity.Collections;
class Program
{
    static void Main(string[] args)
    {
        var players = new CustomerInfoCollection<CustomerInfo>();

        var player1 = new CustomerInfo(1454, "Vahid", "Vilnius", "iamso@gmail.com");
        var player2 = new CustomerInfo(2241, "Diana", "Oslo", "diana68@gmail.com");
        var player3 = new CustomerInfo(7951, "Adelina", "Baku", "adel1997@gmail.com");
        var player4 = new CustomerInfo(4016, "Tommy", "Istanbul", "tommy_gerrard@gmail.com");
        var player5 = new CustomerInfo(9987, "Martin", "Kaunas", "sword_fish@gmail.com");
        var player6 = new CustomerInfo(1025, "Joseph", "Paris", "true_side64@gmail.com");
        var player7 = new CustomerInfo(3065, "Christ", "Milan", "christ_tailor@gmail.com");
        var player8 = new CustomerInfo(3067, "Kamila", "Torino", "kam_1996@gmail.com");

        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Insert(2, player5);
        players.Remove(player1);
        players.Insert(0, player8);
        players.Insert(4, player6);
        players.Add(player4);
        players.Add(player7);

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < players.count; i++)
        {

            stringBuilder.Append("\n[" + players[i].ID + ", " + players[i].Name + ", " + players[i].Address + ", " + players[i].Email + "]");

        }

        var path = @"C:\Users\haciy\Dropbox\My PC (LAPTOP-GRTJRV5H)\Documents\data.txt";

        FileHandling document = new FileHandling(path);

        document.WriteToDisk(stringBuilder.ToString());

        Console.WriteLine("-----------------------------------------------------------");

        document.ReadFromDisk();
    }
}