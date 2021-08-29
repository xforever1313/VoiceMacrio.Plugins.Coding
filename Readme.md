# Coding Voice Macro Plugin

This is a plugin to [VoiceMacro](https://www.voicemacro.net/) that helps create programming-related macros.

# Installation

Download the latest .zip file, and unzip its contents to VoiceMacro's Plugins directory.  This is located in its install directory.  If installing with the .msi, that would be ```C:\Program Files (x86)\VoiceMacro```

# Features

This plugin's main purpose is manipulating variables within VoiceMacro to be used in formats useful to programmers.  Here is a list of what this plugin is capable of:

* Converting strings to PascalCase
* Converting strings to camelCase
* Converting strings to snake_case
* Converting strings to MACRO_CASE
* Converting strings to lower-kebab-case
* Converting strings to UPPER-KEBAB-CASE
* Creating [GUIDs](https://en.wikipedia.org/wiki/Guid) and saving them to variables.

# Usage

After installing the contents of the .zip file to VoiceMacro's Plugins Directory, do the following to use this plugin:
* Open VoiceMacro
* Create a new macro
* Under the Actions section, go to "Other" -> Advanced -> Send to Plugin.
* Under the dropdown, any actions added via this Plugin will start with \[Coding\].
* Read the description of each action carefully, as it explains what needs to be passed in to each arguments.

# Build from Source

This plugin targets .NET Standard 1.4 as VoiceMacro targets .NET 4.6.1, which implements .NET Standard 1.4.  Therefore, the [.NET Core SDK](https://dotnet.microsoft.com/download/visual-studio-sdks) must be installed.

After, copy/paste the ```VoiceMacro.Plugins.Coding.csproj.user.example``` file inside of src/VoiceMacro.Plugins.Coding and rename it to ```VoiceMacro.Plugins.Coding.csproj.user```.  Edit it in a text editor and set the ```OutDir``` to the path to VoiceMacro's Plugin directory.  This means that each time you compile the plugin, it will automatically be deployed to VoiceMacro.

# License

This plugin is distributed under the [Boost Software License v1.0](https://www.boost.org/users/license.html).
