//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using SethCS.Extensions;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class InVarToPascalCaseOutVarCommand : BaseInVarToCaseOutVarCommand
    {
        // ---------------- Properties ----------------

        public override string DisplayName => $"{Constants.DisplayNamePrefix} Input Var, To Pascal Case, Output var";

        public override string Description => 
$@"This command takes in the name of a variable, transforms its value to Pascal Case, and outputs the value into a different variable.
For example, 'Hello world how are uou' becomes 'HelloWorldHowAreYou'.
    Argument 1 - The name of the variable to read the value from {Constants.VariableTypeDescription}.
    Argument 2 - The name of the variable to save the transformed value to {Constants.VariableTypeDescription}.
                 The variable will contain {Constants.ErrorString} if the variable in argument 1 does not exist.
    Argument 3 - Not used.
    This command is always Synchronized
";

        public override string ID => "2704D5F9-336F-4E23-8510-5227E2F1F60F";

        // ---------------- Functions ----------------

        protected override string Transform( string input )
        {
            return input.ToPascalCase();
        }
    }
}
