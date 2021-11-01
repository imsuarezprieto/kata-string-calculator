namespace Exeal.Katas.StringCalculator
{
	using System;
	using System.Linq;

	public static class StringCalculator
	{
		public static Int32 Add (String numbersExpression)
		{
			return numbersExpression == String.Empty
					? 0
					: numbersExpression.Split( ',' )
							.ToList()
							.Select( Int32.Parse )
							.Sum();
		}
	}
}
