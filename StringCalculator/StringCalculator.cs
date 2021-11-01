namespace Exeal.Katas.StringCalculator
{
	using System;

	public static class StringCalculator
	{
		public static Int32 Add (String numbersExpression)
		{
			if (numbersExpression == String.Empty) return 0;
			return Int32.Parse( numbersExpression );
		}
	}
}
