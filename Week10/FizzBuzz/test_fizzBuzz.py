import fizzBuzz
import unittest

class TestFizzBuzz(unittest.TestCase):

	def checkFizzBuzz(self, value, expectedResult ):
		retVal = fizzBuzz.fizzBuzz(value)
		self.assertEqual(retVal,expectedResult)

	def test_returns1With1PassedIn(self):
		self.checkFizzBuzz(1,'1')

	def test_returns2With2PassedIn(self):
		self.checkFizzBuzz(2,'2')

	def test_returnsFizzWith3PassedIn(self):
		self.checkFizzBuzz(3, 'Fizz')

	def test_returnsBuzzWith5PassedIn(self):
		self.checkFizzBuzz(5, 'Buzz')

	def test_returnsFizzWithAnyMultipleOf3PassedIn(self):
		self.checkFizzBuzz(6, 'Fizz')

	def test_returnsBuzzWithAnyMultipleOf5PassedIn(self):
		self.checkFizzBuzz(10, 'Buzz')

	def test_returnsFizzBuzzWith15PassedIn(self):
		self.checkFizzBuzz(15, 'FizzBuzz')


if __name__ == '__main__':
	unittest.main()