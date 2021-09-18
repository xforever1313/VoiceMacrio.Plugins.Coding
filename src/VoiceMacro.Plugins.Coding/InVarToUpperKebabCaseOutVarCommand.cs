//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using SethCS.Extensions;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class InVarToUpperKeabCaseOutVarCommand : BaseInVarToCaseOutVarCommand
    {
        // ---------------- Constructor ----------------

        public InVarToUpperKeabCaseOutVarCommand() :
            this( new VmCommands() )
        {

        }

        public InVarToUpperKeabCaseOutVarCommand( IVmCommands vmCommands ) :
            base( vmCommands )
        {
        }

        // ---------------- Properties ----------------

        public override string DisplayName => $"{Constants.DisplayNamePrefix} Input Var, To Upper Kebab Case, Output var";

        public override string Description => 
$@"This command takes in the name of a variable, transforms its value to Upper Kebab Case, and outputs the value into a different variable.
For example, 'Hello world how are uou' becomes 'HELLO-WORLD-HOW-ARE-YOU'.
    Argument 1 - The name of the variable to read the value from {Constants.VariableTypeDescription}.
    Argument 2 - The name of the variable to save the transformed value to {Constants.VariableTypeDescription}.
                 The variable will contain {Constants.ErrorString} if the variable in argument 1 does not exist.
    Argument 3 - Not used.
    This command is always Synchronized
";

        public override string ID => "E912F621-EC3F-4853-8C09-BD4C2C5F5A29";

        // ---------------- Functions ----------------

        protected override string Transform( string input )
        {
            return input.ToUpperKebabCase();
        }
    }
}
