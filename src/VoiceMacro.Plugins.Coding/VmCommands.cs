//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using System.Collections.Generic;
using vmAPI;

namespace VoiceMacro.Plugins.Coding
{
    public sealed class VmCommands : IVmCommands
    {
        // ----------------- Functions -----------------

        public string CommandExists( string CommandName )
        {
            return vmCommand.CommandExists( CommandName );
        }

        public bool ExecuteMacro( string ProfileMacroGUID )
        {
            return vmCommand.ExecuteMacro( ProfileMacroGUID );
        }

        public string GetActiveProfileGUID()
        {
            return vmCommand.GetActiveProfileGUID();
        }

        public string GetDataDirectory()
        {
            return vmCommand.GetDataDirectory();
        }

        public List<vmProfile> GetProfiles()
        {
            return vmCommand.GetProfiles();
        }

        public string GetVariable( string name, string GUIDP = "" )
        {
            return vmCommand.GetVariable( name, GUIDP );
        }

        public void SendKey( KeyboardAction KeyboardAction )
        {
            vmCommand.SendKey( KeyboardAction );
        }

        public bool SetVariable( string name, string value, string GUIDP = "" )
        {
            return vmCommand.SetVariable( name, value, GUIDP );
        }
    }
}
