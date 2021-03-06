namespace Exeal.Katas.StringCalculator.Tests
{
	using System;
	using Xunit;


	public sealed class StringCalculatorSpecs
	{

		// Create a simple String calculator with a method signature:
		//		int Add(string)
		// The method can take up to two numbers, separated by commas, and will return their sum.
		// For an empty string it will return 0


		[Fact]
		public void GIVEN_empty_string_WHEN_add_THEN_returns_0() {
			// Given
			var emptyString = String.Empty;
			// When
			Int32 sum = StringCalculator.Add( emptyString );
			// Then
			Assert.Equal( expected: 0, actual: sum );
		}


		[Fact]
		public void GIVEN_one_number_string_WHEN_add_THEN_return_the_number() {
			// Given
			const Int32 NUMBER_TO_TEST  = 1;
			var         oneNumberString = $"{NUMBER_TO_TEST}";
			// When
			Int32 sum = StringCalculator.Add( oneNumberString );
			// Then
			Assert.Equal( expected: NUMBER_TO_TEST, actual: sum );
		}


		[Fact]
		public void GIVEN_two_numbers_string_WHEN_Add_THEN_return_the_sum() {
			// Given
			var twoNumbersString = "1,2";
			// When
			Int32 sum = StringCalculator.Add( twoNumbersString );
			// Then
			Assert.Equal( expected: 3, actual: sum );
		}


		// Allow the Add method to handle an unknown amount of numbers


		[Fact]
		public void GIVEN_several_numbers_string_WHEN_add_THEN_return_the_sum() {
			// Given
			const String THREE_NUMBERS_STRING = "1,2,3";
			// When
			Int32 sum = StringCalculator.Add( THREE_NUMBERS_STRING );
			// Then
			Assert.Equal( expected: 6, actual: sum );
		}


		// Allow the Add method to handle new lines between numbers (instead of commas)


		[Fact]
		public void GIVEN_number_string_with_newlines_WHEN_add_THEN_returnT_the_sum() {
			// Given
			const String NUMBERS_WITH_NEWLINES = "1\n2,3";
			// When
			Int32 sum = StringCalculator.Add( NUMBERS_WITH_NEWLINES );
			// Then
			Assert.Equal( expected: 6, actual: sum );
		}


		// Support different delimiters
		//	- To change a delimiter, the beginning of the string will contain a separate line that looks like this:
		//		“//[delimiter]\n[numbers…]”
		//		For example “//;\n1;2” should return three where the default delimiter is ‘;’ .
		// - The first line is optional. all existing scenarios should still be supported


		[Fact]
		public void GIVE_number_string_with_custom_delimiters_WHEN_add_THEN_return_the_sum() {
			// Given
			var numbersWithCustomDelimiters = "//;\n1;2";
			// When
			Int32 sum = StringCalculator.Add( numbersWithCustomDelimiters );
			// Then
			Assert.Equal( expected: 3, actual: sum );
		}


		// Calling Add with a negative number will throw an exception “negatives not allowed”
		//	and the negative that was passed.
		// If there are multiple negatives, show all of them in the exception message.


		[Fact]
		public void GIVEN_string_with_negative_numbers_WHEN_add_THEN_throw_exception() {
			// Given
			const String STRING_WITH_NEGATIVE_NUMBERS = "-1,2";
			// When
			static void AddNegativeNumbers() => StringCalculator.Add( STRING_WITH_NEGATIVE_NUMBERS );
			// Then
			var exception = Assert.Throws<ArgumentException>( AddNegativeNumbers );
			Assert.Equal( expected: "negatives not allowed -1", actual: exception.Message );
		}

	}
}
