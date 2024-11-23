using System;
using System.Text;

namespace Sofa.CourseManagement;

public struct Id
{
	private readonly Guid _guid;

	public Id(Guid guid)
	{
		_guid = guid;
	}

	// ToString: تبدیل Guid به رشته Base32 کوتاه
	public override string ToString()
	{
		return ConvertToBase32(_guid.ToByteArray());
	}

	// Parse: تبدیل رشته Base32 به Id
	public static Id Parse(string encoded)
	{
		var bytes = ConvertFromBase32(encoded);
		return new Id(new Guid(bytes));
	}

	// Implicit Conversion از Guid به Id
	public static implicit operator Id(Guid guid) => new Id(guid);

	// Implicit Conversion از Id به Guid
	public static implicit operator Guid(Id id) => id._guid;

	// Implicit Conversion از Id به string
	public static implicit operator string(Id id) => id.ToString();

	// Implicit Conversion از string به Id
	public static implicit operator Id(string encoded) => Parse(encoded);

	// روش تبدیل Base32 برای تولید رشته کوتاه و امن
	private static string ConvertToBase32(byte[] data)
	{
		const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"; // Base32 کاراکترها
		StringBuilder result = new StringBuilder();
		int bitBuffer = 0, bitBufferLength = 0;

		foreach (byte b in data)
		{
			bitBuffer = (bitBuffer << 8) | b;
			bitBufferLength += 8;

			while (bitBufferLength >= 5)
			{
				int index = (bitBuffer >> (bitBufferLength - 5)) & 0b11111;
				result.Append(alphabet[index]);
				bitBufferLength -= 5;
			}
		}

		if (bitBufferLength > 0)
		{
			int index = (bitBuffer << (5 - bitBufferLength)) & 0b11111;
			result.Append(alphabet[index]);
		}

		return result.ToString();
	}

	private static byte[] ConvertFromBase32(string encoded)
	{
		const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
		encoded = encoded.ToUpper();
		int bitBuffer = 0, bitBufferLength = 0, index = 0;
		byte[] result = new byte[16];
		int byteIndex = 0;

		foreach (char c in encoded)
		{
			if (byteIndex >= result.Length) break;

			int charIndex = alphabet.IndexOf(c);
			if (charIndex < 0) throw new FormatException("Invalid Base32 character.");

			bitBuffer = (bitBuffer << 5) | charIndex;
			bitBufferLength += 5;

			if (bitBufferLength >= 8)
			{
				result[byteIndex++] = (byte)((bitBuffer >> (bitBufferLength - 8)) & 0xFF);
				bitBufferLength -= 8;
			}
		}

		if (byteIndex != result.Length)
		{
			throw new FormatException("Invalid Base32 string length.");
		}

		return result;
	}
}