using Microsoft.FluentUI.AspNetCore.Components;
using MyChores.Domain.Enums;

namespace MyChores.Blazor.Services
{
    public class RecourseService
    {
        public IEnumerable<Option<string>> RecourseOptions { get; private set; }
        public RecourseService() 
        {
            RecourseOptions = Enum.GetValues(typeof(Recourse)).Cast<Recourse>().Select(x => new Option<string> {Value = ((int)x).ToString(), Text = x.ToString() }); ;
        }

        public string GetStringName(string Value)
        {
            return RecourseOptions.FirstOrDefault(x => x.Value.Equals(Value)).Text;
        }

        public int GetIndexNumber(string Text)
        {
            int number;
            bool success = int.TryParse(RecourseOptions.FirstOrDefault(y => y.Text.Equals(Text)).Value, out number);
            if (!success)
                throw new Exception("parsing Recourse went wrong");
            return number;
        }

        public Recourse GetEnumByIndex(string Value)
        {
            int number;
            bool success = int.TryParse(Value, out number);
            if (!success)
                throw new Exception("parsing Recourse went wrong");

            Recourse[] values = (Recourse[])Enum.GetValues(typeof(Recourse));

            return values[number];
        }

        public Recourse GetEnumByString(string Text)
        {
            int number = GetIndexNumber(Text);
            Recourse[] values = (Recourse[])Enum.GetValues(typeof(Recourse));

            return values[number];
        }
    }
}
