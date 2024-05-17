namespace Part3
{
    class NumericalExpression(long number)
    {
        public long Number = number;
        private readonly string[] Units = [ "", "One", "Two", "Three", "Four", "Five",
                                  "Six", "Seven", "Eight", "Nine", "Ten"];
        private readonly string[] TenToTwenty = ["Eleven", "Twelve", "Thirteen", "Fourteen",
                                  "Fifteen", "Sixteen", "Seventeen", "Eighteen",
                                  "Nineteen" ];

        private readonly string[] Tens = [ "", "", "Twenty", "Thirty", "Fourty", "Fifty",
                                 "Sixty", "Seventy", "Eighty", "Ninety" ];

        private readonly string[] Magnitutes = ["", "Thousand", "Million", "Billion"];

        public long GetValue()
        {
            return Number;
        }

        public static long SumLetters(long number)
        {
            long sum = 0;
            for (int i = 0; i < number; i++)
            {
                NumericalExpression temp = new(number);
                sum += temp.ToString().Trim().Length;
            }
            return sum;
        }

        // The OOP principle shown here is encapsulation.
        // I don't have to know what happens in the ToString() method for this class,
        // but i can use it to calculate SumLetters().
        public static long SumLetters(NumericalExpression number)
        {
            long sum = 0;
            for (int i = 0; i < number.Number; i++)
            {
                sum += number.ToString().Trim().Length;
            }
            return sum;
        }

        private string HundredsToWords(long hundreds)
        {
            string numbersAsWords = "";

            if (hundreds >= 100)
            {
                numbersAsWords += $"{Units[hundreds / 100]} Hundred ";
                hundreds %= 100;
            }
            if (hundreds >= 10 && hundreds <= 19)
            {
                numbersAsWords += $"{TenToTwenty[hundreds % 10]} ";
            }
            else
            {
                numbersAsWords += $"{Tens[hundreds / 10]} ";
                numbersAsWords += $"{Units[hundreds % 10]} ";
            }

            return numbersAsWords;
        }

        public override string ToString()
        {
            if (Number == 0)
            {
                return "Zero";
            }
            
            string numberAsWords = "";
            long temp = Number;
            
            if (Number < 0)
            {
                numberAsWords += "Minus ";
            }
            for (int i = 0; temp > 0; i++)
            {
                if (temp % 1000 != 0)
                    numberAsWords = $"{HundredsToWords(temp % 1000)}{Magnitutes[i]} {numberAsWords}";

                temp /= 1000;
            }

            return numberAsWords.Trim();
        }
    }
}