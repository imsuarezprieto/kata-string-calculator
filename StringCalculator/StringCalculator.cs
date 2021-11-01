namespace Exeal.Katas.StringCalculator
{
	using System;

	public static class StringCalculator
	{
		public static Int32 Add (String numbersExpression)
		{
			return numbersExpression == String.Empty
					? 0
					: Int32.Parse( numbersExpression );
		}
	}
}
