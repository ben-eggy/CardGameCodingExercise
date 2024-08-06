using CardGameCodingExercise;

namespace CardGameCodingExerciseTests
{
    [TestClass]
    public class CardGameTests
    {
        [TestMethod]
        public void Test_SingleCard_2C_ShouldReturn_2()
        {
            var cards = new[] { "2C" };
            int result = CardGame.CalculateScore(cards);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_SingleCard_9H_ShouldReturn_27()
        {
            var cards = new[] { "9H" };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void Test_SingleCard_QD_ShouldReturn_24()
        {
            var cards = new[] { "QD" };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void Test_MultipleCards_ShouldReturn_CorrectScore()
        {
            var cards = new[] { "4C", "KD", "AH" };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual(4 + 26 + 42, result);
        }

        [TestMethod]
        public void Test_Joker_Once_ShouldDoubleScore()
        {
            var cards = new[] { "4C", "KD", "AH", "JK" };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual((4 + 26 + 42) * 2, result);
        }

        [TestMethod]
        public void Test_Joker_Twice_ShouldQuadrupleScore()
        {
            var cards = new[] { "2H", "9S", "JK", "5D", "JK" };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual((2 * 3 + 9 * 4 + 5 * 2) * 4, result);
        }

        [TestMethod]
        public void Test_Joker_Thrice_ShouldThrowError()
        {
            var cards = new[] { "3C", "JK", "JK", "JK" };
            Assert.ThrowsException<ArgumentException>(() => CardGame.CalculateScore(cards));
        }

        [TestMethod]
        public void Test_DuplicateCard_ShouldThrowError()
        {
            var cards = new[] { "2C", "2C" };
            Assert.ThrowsException<ArgumentException>(() => CardGame.CalculateScore(cards));
        }

        [TestMethod]
        public void Test_InvalidCardInput_ShouldThrowError()
        {
            var cards = new[] { "2C", "XX" };
            Assert.ThrowsException<ArgumentException>(() => CardGame.CalculateScore(cards));
        }

        [TestMethod]
        public void Test_EmptyInput_ShouldReturn_Zero()
        {
            var cards = new string[] { };
            var result = CardGame.CalculateScore(cards);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_IsExitCommand_ShouldReturnTrueForExit()
        {
            Assert.IsTrue(CardGame.IsExitCommand("exit"));
            Assert.IsTrue(CardGame.IsExitCommand(" Exit "));
            Assert.IsTrue(CardGame.IsExitCommand("EXIT"));
        }

        [TestMethod]
        public void Test_IsExitCommand_ShouldReturnFalseForNonExit()
        {
            Assert.IsFalse(CardGame.IsExitCommand("hello"));
        }

        [TestMethod]
        public void Test_ParseCardInput_ShouldReturnCorrectArray()
        {
            string input = "3C,KH,7D,JK";
            string[] expected = { "3C", "KH", "7D", "JK" };

            var result = CardGame.ParseCardInput(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ParseCardInput_ShouldHandleEmptyInput()
        {
            string input = "";
            string[] expected = { "" };

            var result = CardGame.ParseCardInput(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_GetUserInput_ShouldReturnUserInput()
        {
            var input = "5C, AH, 10D, JK";
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                var result = CardGame.GetUserInput();
                Assert.AreEqual(input, result);
            }
        }

        [TestMethod]
        public void Test_DisplayScore_ShouldOutputCorrectMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CardGame.DisplayScore(101);
                var result = sw.ToString().Trim();
                Assert.AreEqual("Total score: 101", result);
            }
        }

        [TestMethod]
        public void Test_DisplayError_ShouldOutputCorrectMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CardGame.DisplayError("Invalid card input");
                var result = sw.ToString().Trim();
                Assert.AreEqual("Error: Invalid card input", result);
            }
        }
    }
}
