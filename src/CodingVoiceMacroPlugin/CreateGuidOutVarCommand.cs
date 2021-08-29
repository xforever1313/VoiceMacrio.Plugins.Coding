//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using System;
using vmAPI;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class CreateGuidOutVarCommand : vmInterface
    {
        // ---------------- Properties ----------------

        public string DisplayName => $"{Constants.DisplayNamePrefix} Create GUID, Output Var";

        public string Description =>
$@"Creates a GUID and outputs it to the specified variable.
    Argument 1 - The name of the variable to write the GUID to {Constants.VariableTypeDescription}.
    Argument 2 - The format provider.  Defaults to 'D' if not specified.  This should be one of the following characters:
                 N - 00000000000000000000000000000000
                 D - 00000000-0000-0000-0000-000000000000
                 B - {{00000000-0000-0000-0000-000000000000}}
                 P - (00000000-0000-0000-0000-000000000000)
                 X - {{0x00000000,0x0000,0x0000,{{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}}}
    Argument 3 - Not used.
    This command is always Synchronized
";

        public string ID => "AECA1246-CEC8-499C-BA15-44FBC2B3FD04";

        // ---------------- Functions ----------------

        public void Init()
        {
        }

        public void Dispose()
        {
        }

        public void ProfileSwitched( string ProfileGUID, string ProfileName )
        {
        }

        public void ReceiveParams( string Param1, string Param2, string Param3, bool Synchron )
        {
            Guid guid = Guid.NewGuid();

            string outputString;
            if( string.IsNullOrEmpty( Param2 ) )
            {
                outputString = guid.ToString();
            }
            else
            {
                outputString = guid.ToString( Param2 );
            }

            vmCommand.SetVariable( Param1, outputString );
        }
    }
}
