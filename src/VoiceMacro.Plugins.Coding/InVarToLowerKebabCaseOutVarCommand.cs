//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using SethCS.Extensions;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class InVarToLowerKebabCaseOutVarCommand : BaseInVarToCaseOutVarCommand
    {
        // ---------------- Constructor ----------------

        public InVarToLowerKebabCaseOutVarCommand() :
            this( new VmCommands() )
        {

        }

        public InVarToLowerKebabCaseOutVarCommand( IVmCommands vmCommands ) :
            base( vmCommands )
        {
        }

        // ---------------- Properties ----------------

        public override string DisplayName => $"{Constants.DisplayNamePrefix} Input Var, To Lower Kebab Case, Output var";

        public override string Description => 
$@"This command takes in the name of a variable, transforms its value to Lower Kebab Case, and outputs the value into a different variable.
For example, 'Hello world how are uou' becomes 'hello-world-how-are-you'.
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
            return input.ToLowerKebabCase();
        }
    }
}
