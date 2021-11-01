namespace Exeal.Katas.StringCalculator
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;

	public static class StringCalculator
	{
		[SuppressMessage( category: "ReSharper", checkId: "PossiblyMistakenUseOfParamsMethod" )]
		public static Int32 Add (String numbersExpression)
		{
			return numbersExpression == String.Empty
					? 0
					: numbersExpression.Split( ',', '\n' )
							.ToList()
							.Select( Int32.Parse )
							.Sum();
		}
	}
}
