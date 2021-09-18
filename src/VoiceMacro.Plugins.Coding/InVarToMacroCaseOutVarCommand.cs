//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using SethCS.Extensions;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class InVarToMacroCaseOutVarCommand : BaseInVarToCaseOutVarCommand
    {
        // ---------------- Constructor ----------------

        public InVarToMacroCaseOutVarCommand() :
            this( new VmCommands() )
        {

        }

        public InVarToMacroCaseOutVarCommand( IVmCommands vmCommands ) :
            base( vmCommands )
        {
        }

        // ---------------- Properties ----------------

        public override string DisplayName => $"{Constants.DisplayNamePrefix} Input Var, To Macro Case, Output var";

        public override string Description => 
$@"This command takes in the name of a variable, transforms its value to Macro Case (or Upper Snake Case), and outputs the value into a different variable.
For example, 'Hello world how are uou' becomes 'HELLO_WORLD_HOW_ARE_YOU'.
    Argument 1 - The name of the variable to read the value from {Constants.VariableTypeDescription}.
    Argument 2 - The name of the variable to save the transformed value to {Constants.VariableTypeDescription}.
                 The variable will contain {Constants.ErrorString} if the variable in argument 1 does not exist.
    Argument 3 - Not used.
    This command is always Synchronized
";

        public override string ID => "532A4F03-02F3-4D88-B718-CAB8CDA9A0D9";

        // ---------------- Functions ----------------

        protected override string Transform( string input )
        {
            return input.ToMacroCase();
        }
    }
}
