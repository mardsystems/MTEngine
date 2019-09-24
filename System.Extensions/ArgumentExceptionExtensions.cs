using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class ArgumentExceptionExtensions
    {
        public static string GetMessageWithoutParamName(this ArgumentException ex)
        {
            int position = ex.Message.IndexOf("Nome do parâmetro");

            if (position > 0)
            {
                return ex.Message.Substring(0, position - 2);
            }
            else
            {
                position = ex.Message.IndexOf("Parameter name");

                if (position > 0)
                {
                    return ex.Message.Substring(0, position - 2);
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string GetParamNameWithoutPrefix(this ArgumentException ex)
        {
            return ex.ParamName.Replace("novo", "").Replace("nova", "");
        }
    }
}
