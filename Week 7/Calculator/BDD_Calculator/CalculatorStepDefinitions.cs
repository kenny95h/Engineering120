using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using CalculatorLib;

namespace BDD_Calculator
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private Calculator _calculator;
        private int _result;
        private Exception _divideException;
        private List<int> _myList = new List<int>();

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }

        [Given(@"I enter (.*) and (.*) in the calculator")]
        public void GivenIEnterAndInTheCalculator(int a, int b)
        {
            _calculator.Num1 = a;
            _calculator.Num2 = b;
        }

        [Given(@"I enter the numbers below to a list")]
        public void GivenIEnterTheNumbersBelowToAList(Table table)
        {
            foreach(var row in table.Rows)
            {
                _myList.Add(int.Parse(row[0].Trim()));
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            try 
            {
                _result = _calculator.Divide();
            }
            catch (Exception ex)
            {
                _divideException = ex;
            }
                
            
        }
        

        [When(@"I iterate through the list to add all the even numbers")]
        public void WhenIIterateThroughTheListToAddAllTheEvenNumbers()
        {
            _result = _calculator.AddEven(_myList);
        }


        [Then(@"a DivideByZero Exception should a DivideByZeroException when I press divide")]
        public void ThenADivideByZeroExceptionShouldADivideByZeroExceptionWhenIPressDivide()
        {
            Assert.That(() => _calculator.Divide(), Throws.TypeOf<DivideByZeroException>());
        }

        [Then(@"the exception should have the message ""([^""]*)""")]
        public void ThenTheExceptionShouldHaveTheMessage(string expected)
        {
            Assert.That(expected, Is.EqualTo(_divideException.Message));
        }



        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }

        
    }
}







