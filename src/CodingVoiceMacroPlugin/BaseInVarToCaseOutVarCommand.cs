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
    public abstract class BaseInVarToCaseOutVarCommand : vmInterface
    {
        // ---------------- Properties ----------------

        public abstract string DisplayName { get; }

        public abstract string Description { get;}

        public abstract string ID { get; }

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
                vmCommand.SetVariable(
                    Param2,
                    Constants.ErrorString + Environment.NewLine + $"{Param1} does not exist"
                );
            }
            else
            {
                vmCommand.SetVariable( Param2, Transform( input ) );
            }
        }

        protected abstract string Transform( string input );
    }
}
