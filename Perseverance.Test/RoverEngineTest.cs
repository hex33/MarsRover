using NUnit.Framework;
using Perseverance.Core;
using Perseverance.Rover;
using System;
using System.Collections.Generic;
using System.IO;

namespace Perseverance.Test
{
    public class RoverEngineTest
    {
        private RoverEngine engine = new RoverEngine();
        private string plateauSize = "5 5";
        [SetUp]
        public void Setup()
        {
            Plateu_Create_5_5();
        }

        [Test]
        public void Plateu_Create_5_5()
        {            
            var currentResult = engine.PlateauCreate(plateauSize);
            Assert.AreEqual(plateauSize, currentResult);
        }

        [Test]
        public void RoverEngine_AddRover_WithParam_SouldBeSucced()
        {
            var roverCoordinates = @"1 2 N 
                LMLMLMLMM";
            var expectedOutput = "1 3 N";
            var rover = engine.AddRover(roverCoordinates);
            var currentResult = engine.Run(rover);
            Assert.AreEqual(expectedOutput, currentResult);
        }

        [Test]
        public void RoverEngine_AddRover_WithParam_SouldNotBeSameCoordinate()
        {
            var firstRoverCoordinates = @"1 2 N 
LMLMLMLMM";
            var secondRoverCoordinates = @"3 3 E
MMRMMRMRRM";
            var firstRover = engine.AddRover(firstRoverCoordinates);
            var firstRoverResult = engine.Run(firstRover);
            var secondRover = engine.AddRover(secondRoverCoordinates);
            var secondRoverResult = engine.Run(secondRover);
            Assert.AreNotEqual(firstRoverResult, secondRoverResult);
        }

        [Test]
        public void RoverEngine_AddRover_With_WrongParam_SouldBeThrowException()
        {
            var expectedError = "Rover coordinates is not match";
            var roverCoordinates = @"1 2 F 
LMLMLMLMM";
            try
            {
                var rover = engine.AddRover(roverCoordinates);
                var roverResult = engine.Run(rover);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expectedError, e.Message);
            }
        }
    }
}