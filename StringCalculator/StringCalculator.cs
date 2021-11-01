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
		public static Int32 Add (String numbersExpression)
		{
			return numbersExpression == String.Empty
					? 0
					: numbersExpression
							.GetNumbers()
							.Any( number => number < 0 )
							? throw new ArgumentException( @$"negatives not allowed{numbersExpression
									.GetNumbers()
									.Where( static number => number < 0 )
									.Aggregate(
											seed: String.Empty,
											func: static (acc, number) => $"{acc} {number}" )}" )
							: numbersExpression
									.GetNumbers()
									.Sum();
		}

		[SuppressMessage( category: "ReSharper", checkId: "StringStartsWithIsCultureSpecific" )]
		private static Char[] GetDelimiter (
				this String numbersExpression
		)
		{
			return new[] {
					',',
					'\n',
					numbersExpression.StartsWith( "//" ) ? numbersExpression[2] : '\0',
			};
		}

		private static IEnumerable<Int32> GetNumbers (
				this String numbersExpression
		)
		{
			return new Regex( @"(//.\n)?(?<LIST>[\S\s]+)" )
					.Match( numbersExpression )
					.Groups["LIST"]
					.Value
					.Split( numbersExpression.GetDelimiter() )
					.Select( Int32.Parse );
		}
	}
}
