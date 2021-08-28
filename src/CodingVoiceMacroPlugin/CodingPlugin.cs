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
    public class CodingPlugin : vmInterface
    {
        // ---------------- Fields ----------------

        // ---------------- Constructor ----------------

        public CodingPlugin()
        {
        }

        // ---------------- Properties ----------------

        public string DisplayName => "Coding Plugin";

        public string Description => "This plugin helps with coding with VoiceMacro";

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
        }
    }
}
