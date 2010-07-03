using System;

namespace Gaddzeit.Kata.Util
{
    public class QuickFinder
    {
        private readonly int[] _intArray;

        public QuickFinder(int[] intArray)
        {
            _intArray = intArray;
        }

        public void Connect(int startPoint, int endPoint)
        {
            //FirstVersionOfAlgorithm(startPoint, endPoint);
            //SecondVersionOfAlgorithm(startPoint, endPoint);
            //ThirdVersionOfAlgorithm(startPoint, endPoint);
            //FourthVersionOfAlgorithm(startPoint, endPoint);
            RefactoredAndFinalVersionOfAlgorithm(startPoint, endPoint);
        }

        private void FirstVersionOfAlgorithm(int startPoint, int endPoint)
        {
            _intArray[startPoint] = endPoint;
        }

        private void SecondVersionOfAlgorithm(int startPoint, int endPoint)
        {
            for (var i = 0; i < _intArray.Length; i++)
            {
                if (_intArray[i].Equals(startPoint))
                    _intArray[i] = endPoint;
            }
        }

        private void ThirdVersionOfAlgorithm(int startPoint, int endPoint)
        {
            for (var i = 0; i < _intArray.Length; i++)
            {
                if (_intArray[i].Equals(startPoint))
                    _intArray[i] = _intArray[endPoint];
            }
        }

        private void FourthVersionOfAlgorithm(int startPoint, int endPoint)
        {
            var valueAtIndexStartPoint = _intArray[startPoint];
            for (var i = 0; i < _intArray.Length; i++)
            {
                if (_intArray[i].Equals(valueAtIndexStartPoint))
                    _intArray[i] = _intArray[endPoint];
            }
        }

        private void RefactoredAndFinalVersionOfAlgorithm(int startPoint, int endPoint)
        {
            var valueAtIndexStartPoint = _intArray[startPoint];
            for (var i = 0; i < _intArray.Length; i++)
            {
                if (CurrentIndexValueEqualsStartPointIndexValue(i, valueAtIndexStartPoint))
                    SetCurrentIndexValueToEndPointIndexValue(i, endPoint);
            }
        }

        private void SetCurrentIndexValueToEndPointIndexValue(int i, int endPoint)
        {
            _intArray[i] = _intArray[endPoint];
        }

        private bool CurrentIndexValueEqualsStartPointIndexValue(int i, int valueAtIndexStartPoint)
        {
            return _intArray[i].Equals(valueAtIndexStartPoint);
        }
    }
}