using System;
using System.Collections.Generic;
using System.Text;

namespace Packets.Core.Utilities
{
    /// <summary>
    ///     Utilities for wirking with packet
    /// </summary>
    public static class FormationPackageUtility
    {
        /// <summary>
        ///     Получение текста из массива байт
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static string GetText(byte[] data, int offset = 0)
        {
            List<byte> bytes = new List<byte>();

            for (int i = offset; i < data.Length; i++)
            {
                if (data[i] == 0)
                {
                    break;
                }
                else
                {
                    bytes.Add(data[i]);
                }
            }

            return Encoding.GetEncoding(1251).GetString(bytes.ToArray());
        }

        /// <summary>
        ///     Получение байтов из текста
        /// </summary>
        /// <param name="text"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string text, int size)
        {
            byte[] bytes = Encoding.GetEncoding(1251).GetBytes(text);
            Array.Resize(ref bytes, size);

            return bytes;
        }
    }
}