using TravelAgency;
internal class Program
{
  private static List<Itinerary> itineraries = [];
  private static void Main(string[] args)
  {
    Console.WriteLine("\nWelcome to Algonquin College Student Travel Agency!");

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("Travel Agency Menu");
      Console.WriteLine("1. View all itineraries");
      Console.WriteLine("2. Add a new itinerary");
      Console.WriteLine("3. Change an existing itinerary");
      Console.WriteLine("4. Exit");
      Console.Write("\nEnter a choice: ");
      Console.Write("");

      string? choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          ViewItineraries();
          break;
        case "2":
          AddItineraries();
          break;
        case "3":
          ChangeItineraries();
          break;
        case "4":
          Console.WriteLine("Thank you for using Algonquin College Student Travel Agency!");
          return;
        default:
          Console.WriteLine("Not a valid input.");
          break;
      }
    }
  }

  static void ViewItineraries()
  {
    if (itineraries.Count == 0)
    {
      Console.WriteLine("\nNo itinerary exists in the system.");
    }
    else
    {
      Console.WriteLine();
      for (int i = 0; i < itineraries.Count; i++)
      {
        Console.WriteLine($"{i} - Passenger: {itineraries[i].PassengerName}, Departure: {itineraries[i].DepartureCity}, Arriving: {itineraries[i].ArrivalCity}, Cost: ${itineraries[i].Cost}");
      }
    }
  }

  static void AddItineraries()
  {
    string name = GetResponse("\nEnter passenger's name: ");
    string departureCity = GetResponse("Enter departure city: ");
    string arrivalCity = GetResponse("Enter arrival city: ");

    var itinerary = new Itinerary(name, departureCity, arrivalCity);
    try
    {
      itineraries.Add(itinerary);
      Console.WriteLine($"{name}'s itinerary hass been added to the system, Cost: {itinerary.Cost}");
    }
    catch (Exception e)
    {
      Console.WriteLine($"\n{e.Message}\n");
    }
  }

  static void ChangeItineraries()
  {
    if (itineraries.Count == 0)
    {
      Console.WriteLine("\nNo itinerary exists in the system.");
    }
    else
    {
      while (true)
      {
        Console.Write($"\nEnter the index of the itinerary you want to change (0 to {itineraries.Count - 1}): ");
        string? input = Console.ReadLine();
        bool isValid = int.TryParse(input, out int index);

        if (isValid && index < itineraries.Count)
        {
          string newDepartureCity = GetResponse("Enter new departure city: ");
          string newArrivalCity = GetResponse("Enter new arrival city: ");
          itineraries[index].ChangeItinerary(newDepartureCity, newArrivalCity);
          Console.WriteLine($"{itineraries[index].PassengerName}'s itinerary has been changed. ${Itinerary.ChangeFee} was applied.");
          return;
        }
        Console.WriteLine("Not a valid response or out of index.");
      }
    }
  }

  /* 
  * GetReponse
  * Used to work with nullable strings from user response.
  * Will continue to prompt the user with an information request
  * Until the user provides a non-nullable value
  * @params: {string} information request
  * @returns: {string} user's response
  */
  static string GetResponse(string request)
  {
    string? response = null;

    while (string.IsNullOrWhiteSpace(response))
    {
      Console.Write(request);
      response = Console.ReadLine();
    }

    return response;
  }
}