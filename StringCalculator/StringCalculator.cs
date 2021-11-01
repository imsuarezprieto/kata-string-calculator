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
					? throw new ArgumentException( @$"negatives not allowed{
						numbers
								.Where( static number => number < 0 )
								.Aggregate(
										seed: String.Empty,
										func: static (acc, number) => $"{acc} {number}" )}" )
					: numbers.Sum();
		}

		[SuppressMessage( category: "ReSharper", checkId: "StringStartsWithIsCultureSpecific" )]
		private static Char[] GetDelimiter (
				this String numbersExpression
		) {
			return new[] {
					',',
					'\n',
					numbersExpression.StartsWith( "//" ) ? numbersExpression[2] : '\0',
			};
		}

		private static IEnumerable<Int32> GetNumbers (
				this String numbersExpression
		) {
			return new Regex( @"(//.\n)?(?<LIST>[\S\s]+)" )
					.Match( numbersExpression )
					.Groups["LIST"]
					.Value
					.Split( numbersExpression.GetDelimiter() )
					.Select( static number => number.Parse() ?? 0 );
		}

		private static Int32? Parse (
				this String @string
		) {
			try {
				return Int32.Parse( @string );
			}
			catch {
				return null;
			}
		}
	}
}
