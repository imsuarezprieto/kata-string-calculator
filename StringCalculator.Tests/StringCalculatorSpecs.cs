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
		public void GIVEN_EmptyString_WHEN_Add_THEN_Returns0()
		{
			// Given
			var emptyString = String.Empty;
			// When
			Int32 sum = StringCalculator.Add( emptyString );
			// Then
			Assert.Equal( expected: 0, actual: sum );
		}

		[Fact]
		public void GIVEN_OneNumberString_WHEN_Add_THEN_ReturnTheNumber()
		{
			// Given
			const Int32 NUMBER_TO_TEST  = 1;
			var         oneNumberString = $"{NUMBER_TO_TEST}";
			// When
			Int32 sum = StringCalculator.Add( oneNumberString );
			// Then
			Assert.Equal( expected: NUMBER_TO_TEST, actual: sum );
		}

		[Fact]
		public void GIVEN_TwoNumbersString_WHEN_Add_THEN_ReturnTheSum()
		{
			// Given
			var twoNumbersString = "1,2";
			// When
			Int32 sum = StringCalculator.Add( twoNumbersString );
			// Then
			Assert.Equal( expected: 3, actual: sum );
		}
	}
}
