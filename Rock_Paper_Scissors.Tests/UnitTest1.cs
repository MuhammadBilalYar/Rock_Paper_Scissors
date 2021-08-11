using Moq;
using NUnit.Framework;
using Rock_Paper_Scissors.Models;
using System;
using System.IO;

namespace Rock_Paper_Scissors.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Move

        [Test]
        public void MoveConvertions_ValidInput()
        {
            Assert.AreEqual(1.ToMove(), Move.Rock);
            Assert.AreEqual(2.ToMove(), Move.Paper);
            Assert.AreEqual(3.ToMove(), Move.Scissors);

            Assert.AreEqual("R".ToMove(), Move.Rock);
            Assert.AreEqual("P".ToMove(), Move.Paper);
            Assert.AreEqual("S".ToMove(), Move.Scissors);
        }
        [Test]
        [TestCase(-31)]
        [TestCase(0)]
        [TestCase(233)]
        public void MoveConvertions_InValidInput(int input)
        {
            Assert.AreEqual(input.ToMove(), Move.Default);
        }

        [Test]
        [TestCase("21312")]
        [TestCase("asdfad")]
        [TestCase("SADSFASD")]
        public void MoveConvertions_InValidInput(string input)
        {
            Assert.AreEqual(input.ToMove(), Move.Default);
        }
        #endregion

        #region Input
        [Test]
        public void GetName()
        {
            // Arrange
            var input = "Somebody";
            Console.SetIn(new StringReader(input));
            IInputFactory factory = new InputFactory();

            //Act & Assert
            Assert.AreEqual(input, factory.GetName());
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase("r")]
        [TestCase("P")]
        [TestCase("s")]
        [TestCase("P")]
        [TestCase("S")]
        [TestCase("R")]
        public void GetHumanMove_Valid(dynamic input)
        {
            // Arrange
            string move = input.ToString();
            Console.SetIn(new StringReader(move));
            IInputFactory factory = new InputFactory();

            //Act & Assert
            Assert.AreEqual(move.ToMove(), factory.GetHumanMove());
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetComputerMove_Valid(int input)
        {
            // Arrange
            IInputFactory factory = new InputFactory();

            //Act 
            var move = factory.GetComputerMove();
            //Act & Assert
            Assert.IsTrue(move == Move.Rock || move == Move.Paper || move == Move.Scissors);
        }
        #endregion

        #region Game
        [Test]
        [TestCase(Move.Rock, Move.Scissors)]
        [TestCase(Move.Scissors, Move.Paper)]
        [TestCase(Move.Paper, Move.Rock)]
        public void PlayGame_RockBeatsScissors(Move human, Move computer)
        {
            Mock<IInputFactory> factory = new Mock<IInputFactory>();
            factory.Setup(x => x.GetName()).Returns(() => "Human");
            factory.Setup(x => x.GetHumanMove()).Returns(() => human);
            factory.Setup(x => x.GetComputerMove()).Returns(() => computer);

            new Game(factory.Object).Start();
        }
        #endregion
    }
}