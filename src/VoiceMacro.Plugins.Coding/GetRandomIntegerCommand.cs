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
    public sealed class GetRandomIntegerCommand : vmInterface
    {
        // ---------------- Fields ----------------

        private readonly Random random;
        private readonly IVmCommands vmCommands;

        // ---------------- Constructor ----------------

        public GetRandomIntegerCommand() :
            this( new VmCommands() )
        {
            
        }

        public GetRandomIntegerCommand( IVmCommands vmCommands )
        {
            this.random = new Random();
            this.vmCommands = vmCommands;
        }

        // ---------------- Properties ----------------

        public string DisplayName => $"{Constants.DisplayNamePrefix} Get Random Integer";

        public string Description =>
$@"Generates a randome interger and outputs it to the specified variable.
    Argument 1 - The name of the variable to write the generated integer to {Constants.VariableTypeDescription}.
                 On an error, this is a multiline string with the first line being '{Constants.ErrorString}',
                 while the second line is what went wrong.
    Argument 2 - The minimum possible integer value (inclusive).  Defaulted to 0 if not specified.  An '{Constants.ErrorString}'
                 will be produced if this is not an integer.
    Argument 3 - The maximum possible integer value (exclusive).  Defaulted to {int.MaxValue} if not specified.
                 An '{Constants.ErrorString}'  will be produced if this is not an integer.
    This command is always Synchronized.
";

        public string ID => "6E4750EE-F46D-435E-AE6A-6A9629A81D04";

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
            int min = 0;
            int max = int.MaxValue;

            if( string.IsNullOrWhiteSpace( Param2 ) == false )
            {
                if( int.TryParse( Param2, out min ) == false )
                {
                    string error = Constants.ErrorString + Environment.NewLine + $"'{Param2}' is not a valid integer.";
                    this.vmCommands.SetVariable( Param1, error );
                    return;
                }
            }

            if( string.IsNullOrWhiteSpace( Param3 ) == false )
            {
                if( int.TryParse( Param3, out max ) == false )
                {
                    string error = Constants.ErrorString + Environment.NewLine + $"'{Param3}' is not a valid integer.";
                    this.vmCommands.SetVariable( Param1, error );
                    return;
                }
            }

            if( min > max )
            {
                string error = Constants.ErrorString + Environment.NewLine + $"Minimum value, {Param2}, is greater than maximum value, {Param3}";
                this.vmCommands.SetVariable( Param1, error );
                return;
            }

            int nextValue = this.random.Next( min, max );
            this.vmCommands.SetVariable( Param1, nextValue.ToString() );
        }
    }
}
