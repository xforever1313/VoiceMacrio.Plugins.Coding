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
    /// <summary>
    /// Wrapper around <see cref="vmCommand"/> so we can mock it in unit test land.
    /// </summary>
    public interface IVmCommands
    {
        /// <see cref="vmCommand.CommandExists(string)"/>
        string CommandExists( string CommandName );

        /// <see cref="vmCommand.ExecuteMacro(string)"/>
        bool ExecuteMacro( string ProfileMacroGUID );

        /// <see cref="vmCommand.GetActiveProfileGUID"/>
        string GetActiveProfileGUID();

        /// <see cref="vmCommand.GetDataDirectory"/>
        string GetDataDirectory();

        /// <see cref="vmCommand.GetProfiles"/>
        List<vmProfile> GetProfiles();

        /// <see cref="vmCommand.GetVariable(string, string)"/>
        string GetVariable( string name, string GUIDP = "" );

        /// <see cref="vmCommand.SetVariable(string, string, string)"/>
        bool SetVariable( string name, string value, string GUIDP = "" );
    }
}
