namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiterList = new List<char> { '\n', ',' };
            if (numbers.Contains("//"))
            {
                var delimiter = numbers.Substring(2, 1);
                delimiterList.Add(char.Parse(delimiter)); 
                numbers = numbers.Substring(numbers.IndexOf('\n')+1);
            }

            return numbers.Split(delimiterList.ToArray()).ToArray().Sum(x => int.Parse(x));
        }
    }
}