namespace GiftBox.Common
{
    using System;

    public static class HelperMethods
    {
        public static byte[] StringToBytes(string strInput)
        {
            int numBytes = strInput.Length / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }
    }
}
