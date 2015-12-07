namespace CountWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var testString = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var splitted = testString.Split(new char[] { ' ', ',', '.', '?', '!', ';', '–' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower())
                .ToList();

            var result = new Dictionary<string, int>();

            foreach (var word in splitted)
            {
                if (result.ContainsKey(word))
                {
                    result[word] += 1;
                }
                else
                {
                    result[word] = 1;
                }
            }

            var ordered = result.OrderBy(x => x.Value).ToList();
            foreach (var item in ordered)
            {
                Console.WriteLine("{0, 10} --> {1}", item.Key, item.Value);
            }
        }
    }
}
