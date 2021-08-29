// ---------------- Constants ----------------

const string buildTarget = "build";
const string releaseTarget = "build_release";
const string zipTarget = "create_zip";
const string defaultTarget = buildTarget;

string target = Argument( "target", defaultTarget );

FilePath sln = File( "src/VoiceMacroCodingPlugin.sln" );
DirectoryPath distroPath = Directory( "DistPackages" );

const string version = "0.1.0";

MSBuildSettings msBuildSettings = new MSBuildSettings
{
    Restore = true,
    ToolVersion = MSBuildToolVersion.VS2019,
    MaxCpuCount = 0
};
msBuildSettings.WithProperty( "Version", version )
    .WithProperty( "AssemblyVersion", version )
    .WithProperty( "FileVersion", version );

// ---------------- Tasks ----------------

Task( buildTarget )
.Does(
    () =>
    {
        MSBuild( sln, msBuildSettings );
    }
).Description( "Builds the debug build." );

Task( releaseTarget )
.Does(
    () =>
    {
        EnsureDirectoryExists( distroPath );
        CleanDirectory( distroPath );

        msBuildSettings.Configuration = "Release";

        msBuildSettings.WithProperty(
            "OutDir",
            distroPath.ToString()
        );

        msBuildSettings.WithProperty(
            "OutputPath",
            distroPath.ToString()
        );

        MSBuild( sln, msBuildSettings );
    }
).Description( "Builds the release build." );

Task( zipTarget )
.Does(
    () =>
    {
        FilePath glob = distroPath.CombineWithFilePath( File( "(*.dll|*.pdb)" ) );
        var files = GetFiles( glob.ToString() );

        FilePath outputFile = distroPath.CombineWithFilePath( File( $"VoiceMacro.Plugins.Coding_{version}.zip" ) );

        Zip( "./", outputFile.ToString(), files );
    }
).Description( "Creates the .zip that contains the plugin." )
.IsDependentOn( releaseTarget );

RunTarget( target );
