using PowerBsRise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise
{
    public static class ProgramLogic
    {
        public static bool IsValidInteger(string textValue)
        {
            return int.TryParse(textValue, out int parsedChoice);
        }

        public static void InitializeBroadsignResource(string token)
        {
            ApiDataHandler apiDataHandler = new ApiDataHandler();

        }
    }
}
