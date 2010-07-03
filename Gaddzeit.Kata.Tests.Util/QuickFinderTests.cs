using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Util;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Util
{
    [TestFixture]
    public class QuickFinderTests
    {
        [Test]
        public void ConnectMethod_StartEndIntFirstTimeInput_ArrayChangesStartValueToEndValue()
        {
            const int startPointPosition = 3;
            const int startPointValue = 3;
            const int endPointValue = 4;
            var intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 };

            var sut = new QuickFinder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointPosition].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_StartEndIntSecondTimeInput_AllValuesMatchingStartInputSwitchToEndInput()
        {
            const int startPointPosition = 4;
            const int startPointValue = 4;
            const int endPointValue = 9;
            var intArray = new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 9, 9, 5, 6, 7, 8, 9 };

            var sut = new QuickFinder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointPosition].ShouldEqual(endPointValue);
            intArray[startPointPosition -1].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_StartEndIntThirdTimeInput_AllValuesMatchingStartInputSwitchToEndInput()
        {
            const int startPointPosition = 8;
            const int startPointValue = 8;
            const int endPointValue = 0;
            var intArray = new int[] { 0, 1, 2, 9, 9, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 9, 9, 5, 6, 7, 0, 9 };

            var sut = new QuickFinder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointPosition].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_EntireSequenceOfStartPointInputs_AllValuesMoveToCommonAndFinalEndPointValue()
        {
            var intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sut = new QuickFinder(intArray);
            sut.Connect(3, 4);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 });
            sut.Connect(4, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 9, 9, 5, 6, 7, 8, 9 });
            sut.Connect(8, 0);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 9, 9, 5, 6, 7, 0, 9 });
            sut.Connect(2, 3);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 9, 9, 5, 6, 7, 0, 9 });
            sut.Connect(5, 6);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 9, 9, 6, 6, 7, 0, 9 });
            sut.Connect(2, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 9, 9, 6, 6, 7, 0, 9 });
            sut.Connect(5, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 9, 9, 9, 9, 7, 0, 9 });
            sut.Connect(7, 3);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 9, 9, 9, 9, 9, 0, 9 });
            sut.Connect(4, 8);
            intArray.ShouldEqual(new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
            sut.Connect(5, 6);
            intArray.ShouldEqual(new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
            sut.Connect(0, 2);
            intArray.ShouldEqual(new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 });
            sut.Connect(6, 1);
            intArray.ShouldEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        }
        
    }
}
