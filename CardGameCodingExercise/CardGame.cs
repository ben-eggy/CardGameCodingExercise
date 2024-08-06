namespace CardGameCodingExercise
{
    public class CardGame
    {
        private static readonly Dictionary<char, int> _cardValues = new Dictionary<char, int>
        {
            { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 },
            { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'T', 10 }, { 'J', 11 },
            { 'Q', 12 }, { 'K', 13 }, { 'A', 14 }
        };

        private static readonly Dictionary<char, int> _suitMultipliers = new Dictionary<char, int>
        {
            { 'C', 1 }, { 'D', 2 }, { 'H', 3 }, { 'S', 4 }
        };

        public static string GetUserInput()
        {
            Console.WriteLine("Enter a list of cards in the following format '2C, 4S, JK' or type 'exit' to quit: ");
            return Console.ReadLine();
        }

        public static bool IsExitCommand(string input)
        {
            return input.Trim().ToLower() == "exit";
        }

        public static string[] ParseCardInput(string input)
        {
            return input.Split(',');
        }

        public static void DisplayScore(int score)
        {
            Console.WriteLine($"Total score: {score}\n");
        }

        public static void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}\n");
        }

        public static int CalculateScore(string[] cards)
        {
            if (cards == null || cards.Length == 0)
            {
                return 0;
            }

            int jokerCount = CountJokers(cards);
            ValidateJokerCount(jokerCount);

            var uniqueCards = new HashSet<string>();
            int totalScore = 0;

            foreach (var card in cards)
            {
                if (card != "JK")
                {
                    ValidateCard(card);
                    ValidateCardUniqueness(card, uniqueCards);
                    totalScore += CalculateCardScore(card);
                }
            }

            return ApplyJokerMultiplier(totalScore, jokerCount);
        }

        private static void ValidateCard(string card)
        {
            if (card.Length != 2 || !_cardValues.ContainsKey(card[0]) || !_suitMultipliers.ContainsKey(card[1]))
            {
                throw new ArgumentException($"Invalid card: {card}");
            }
        }

        private static void ValidateCardUniqueness(string card, HashSet<string> uniqueCards)
        {
            if (!uniqueCards.Add(card))
            {
                throw new ArgumentException($"Duplicate card detected: {card}");
            }
        }

        private static int CalculateCardScore(string card)
        {
            int cardValue = _cardValues[card[0]];
            int suitMultiplier = _suitMultipliers[card[1]];
            return cardValue * suitMultiplier;
        }

        private static int CountJokers(string[] cards)
        {
            return cards.Count(card => card == "JK");
        }

        private static void ValidateJokerCount(int jokerCount)
        {
            if (jokerCount > 2)
            {
                throw new ArgumentException("Too many Jokers entered. There are only two Jokers in a pack of cards.");
            }
        }
        private static int ApplyJokerMultiplier(int totalScore, int jokerCount)
        {
            if (jokerCount > 0)
            {
                totalScore *= 2 * jokerCount;
            }
            return totalScore;
        }

        private static void Main()
        {
            while (true)
            {
                string input = GetUserInput();

                if (IsExitCommand(input))
                {
                    break;
                }

                string[] cards = ParseCardInput(input);

                try
                {
                    int score = CalculateScore(cards);
                    DisplayScore(score);
                }
                catch (ArgumentException ex)
                {
                    DisplayError(ex.Message);
                }
            }
        }
    }
}
