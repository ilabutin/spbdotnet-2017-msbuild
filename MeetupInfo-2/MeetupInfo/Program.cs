using System;
using System.IO;
using System.Reflection;
using SuperSerializer;

namespace MeetupInfo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\n\n--------------------------------------------");
      var meetupFile = args[0];

      using (var input = new FileStream(meetupFile, FileMode.Open))
      using (var xsd = new MemoryStream(Properties.Resource.MeetupInfo))
      {
        try
        {
          var c = new SuperSerializer<MeetupInfo>();
          var meetupInfo = c.DeserializeAndValidate(input, xsd);

          Console.WriteLine($"Meetup date: {meetupInfo.Date.ToLocalTime()}");
          Console.WriteLine("Speakers:");
          foreach (var speaker in meetupInfo.Speakers.SpeakerInfo)
          {
            Console.Write("  {0} ", speaker.Approved ? "+" : "-");
            Console.WriteLine($"{speaker.Name}, {speaker.Mail}");
          }
        }
        catch (Exception e)
        {
          Console.WriteLine("ERROR: " + e.Message);
        }
      }

      Console.WriteLine("\n\n");
    }
  }
}
