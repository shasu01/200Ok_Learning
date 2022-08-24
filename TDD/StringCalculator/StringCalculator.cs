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

            var listOfNumbers = numbers.Split(delimiterList.ToArray()).ToArray();
            var listOfNegativeNumbers = listOfNumbers.Where(x => (int.Parse(x) < 0)).ToList();
            var msg = "Negatives Not Allowed, ";
            if (listOfNegativeNumbers.Any())
            {
                listOfNegativeNumbers.ToList().ForEach(s => msg += s + " ");
                throw new Exception(msg);
            }
                

            return numbers.Split(delimiterList.ToArray()).ToArray().Sum(x => int.Parse(x));
        }
    }
}