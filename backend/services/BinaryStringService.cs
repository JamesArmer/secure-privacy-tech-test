using System;
namespace backend.Services
{
	public class BinaryStringService
	{
		public BinaryStringService()
		{
		}

		public bool Evaluate(string binary)
		{
			int noOfZeros = 0;
            int noOfOnes = 0;
			bool validPrefix = true;
			bool equalNoOnesAndZeros;

			foreach(char c in binary)
			{ 
				if (c == '0')
				{
					noOfZeros++;
				}
				if (c == '1')
				{
					noOfOnes++;
				}

				if(noOfOnes >= noOfZeros)
				{
					validPrefix = true;
				} else
				{
					validPrefix = false;
					break;
				}
			}

			if(noOfOnes == noOfZeros)
			{
				equalNoOnesAndZeros = true;
			} else
			{
				equalNoOnesAndZeros = false;
			}

			return equalNoOnesAndZeros && validPrefix;
        }
	}
}

