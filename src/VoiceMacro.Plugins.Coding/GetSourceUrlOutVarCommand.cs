//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using vmAPI;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class GetSourceUrlOutVarCommand : vmInterface
    {
        // ---------------- Fields ----------------

        private const string url = "https://github.com/xforever1313/VoiceMacro.Plugins.Coding";

        private readonly IVmCommands vmCommands;

        // ---------------- Constructor ----------------

        public GetSourceUrlOutVarCommand() :
            this( new VmCommands() )
        {

        }

        public GetSourceUrlOutVarCommand( IVmCommands vmCommands )
        {
            this.vmCommands = vmCommands;
        }

        // ---------------- Properties ----------------

        public string DisplayName => $"{Constants.DisplayNamePrefix} Get Source URL Version, Output Var";

        public string Description =>
$@"Gets this plugin's URL to the source code and outputs it to the specified variable.
    Argument 1 - The name of the variable to write the URL to {Constants.VariableTypeDescription}.
    Argument 2 - Not Useed
    Argument 3 - Not used.
    This command is always Synchronized
";

        public string ID => "421B4352-5F80-4838-BE37-668B3EBED5E3";

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
            this.vmCommands.SetVariable( Param1, url );
        }
    }
}
