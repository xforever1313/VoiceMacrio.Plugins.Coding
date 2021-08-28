//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using SethCS.Extensions;
using vmAPI;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class InVarToPascalCaseOutVarCommand : vmInterface
    {
        // ---------------- Constructor ----------------

        public InVarToPascalCaseOutVarCommand()
        {
        }

        // ---------------- Properties ----------------

        public string DisplayName => "Input Var, To Pascal Case, Output var";

        public string Description => 
$@"This command takes in the name of a variable, transforms its value to Pascal Case, and outputs the value into a different variable.
    Argument 1 - The name of the variable to read the value from {Constants.VariableTypeDescription}.
    Argument 2 - The name of the variable to save the transformed value to {Constants.VariableTypeDescription}.
                 The variable will contain {Constants.ErrorString} if the variable in argument 1 does not exist.
    Argument 3 - Not used.
    This command is always Synchronized
";

        public string ID => "2704D5F9-336F-4E23-8510-5227E2F1F60F";

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
            string input = vmCommand.GetVariable( Param1 );
            if( input.Equals( Constants.ErrorString ) )
            {
                vmCommand.SetVariable( Param2, Constants.ErrorString );
            }
            else
            {
                vmCommand.SetVariable( Param2, input.ToPascalCase() );
            }
        }
    }
}
