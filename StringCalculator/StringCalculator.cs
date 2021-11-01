namespace Exeal.Katas.StringCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Text.RegularExpressions;


	public static class StringCalculator
	{

		[SuppressMessage( category: "ReSharper", checkId: "PossiblyMistakenUseOfParamsMethod" )]
		public static Int32 Add (
				String numbersExpression
		) {
			List<Int32> numbers = numbersExpression.GetNumbers().ToList();
			return numbers
					.Any( static number => number < 0 )
					? throw new ArgumentException(
							@$"negatives not allowed{
								numbers
										.Where( static number => number < 0 )
										.JoinedString()
							}" )
					: numbers.Sum();
		}


		[SuppressMessage( category: "ReSharper", checkId: "StringStartsWithIsCultureSpecific" )]
		private static Char[] GetDelimiter (
				this String numbersExpression
		) {
			String delimiter =
					numbersExpression
							.MatchExpression()
							.Groups["DELIMITER"]
							.Value;
			return delimiter == String.Empty
					? new[] {',', '\n'}
					: delimiter.ToCharArray();
		}


		private static Match MatchExpression (
				this String stringExpression
		) =>
				new Regex( @"(//(?<DELIMITER>.+?)\n)?(?<LIST>[\S\s]+)" )
						.Match( stringExpression );


		private static IEnumerable<Int32> GetNumbers (
				this String numbersExpression
		) =>
				numbersExpression
						.MatchExpression()
						.Groups["LIST"]
						.Value
						.Split( numbersExpression.GetDelimiter() )
						.Select( static number => number.Parse() ?? 0 );


		private static Int32? Parse (
				this String @string
		) {
			try {
				Int32 number = Int32.Parse( @string );
				return number > 1000 ? 0 : number;
			}
			catch {
				return null;
			}
		}


		private static String JoinedString (
				this IEnumerable<Int32> numberList,
				String                  separator = " "
		) =>
				numberList
						.Aggregate(
								seed: String.Empty,
								func: (acc, number) => $"{acc}{separator}{number}" );

	}
}
