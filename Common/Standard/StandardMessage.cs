using System;

namespace Common.Standard
{
    public static class StandardMessage
    {
        
        public static readonly string ERR_ENTITY_NOT_ACTIVE = "{0} is inactive.";
        public static readonly string ERR_PROCESS = "Error while processing data.";
        public static readonly string ERR_ENTITY_INVALID = "{0} is invalid.";
        public static readonly string ERR_ENTITY_NOT_EXIST = "{0} does not exist.";
        public static readonly string ERR_REQUIRED_FIELD = "{0} is required.";
        public static readonly string ERR_NO_DETAILS = "No details are recieved.";
        public static readonly string ERR_DUPLICATE_RECORD = "Duplicate {0} already exists.";

        public static readonly string ALREADY_LINKED = "{0} is already linked to {1}.";
        public static readonly string NO_LINK = "No linked {0} found for {1}.";

        public static string FormatError(this string s, params string[] repalcer  )
        {
            return String.Format(s, repalcer);
        }
    }
}