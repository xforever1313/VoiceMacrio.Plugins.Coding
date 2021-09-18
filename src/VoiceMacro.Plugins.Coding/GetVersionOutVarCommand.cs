//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using System;
using System.Reflection;
using vmAPI;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class GetVersionOutVarCommand : vmInterface
    {
        // ---------------- Fields ----------------

        private readonly IVmCommands vmCommands;

        // ---------------- Constructor ----------------

        public GetVersionOutVarCommand() :
            this( new VmCommands() )
        {

        }

        public GetVersionOutVarCommand( IVmCommands vmCommands )
        {
            this.vmCommands = vmCommands;
        }

        // ---------------- Properties ----------------

        public string DisplayName => $"{Constants.DisplayNamePrefix} Get Plugin Version, Output Var";

        public string Description =>
$@"Gets this plugin's version and outputs it to the specified variable.
    Argument 1 - The name of the variable to write the version to {Constants.VariableTypeDescription}.
    Argument 2 - Not Useed
    Argument 3 - Not used.
    This command is always Synchronized
";

        public string ID => "811CA919-C5BE-46D6-960E-CA76421D2018";

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
            Version vers = typeof( GetVersionOutVarCommand ).GetTypeInfo().Assembly.GetName().Version;
            this.vmCommands.SetVariable( Param1, vers.ToString( 3 ) );
        }
    }
}
