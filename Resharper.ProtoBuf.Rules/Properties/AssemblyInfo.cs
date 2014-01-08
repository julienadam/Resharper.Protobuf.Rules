using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using JetBrains.Application.PluginSupport;

[assembly: AssemblyTitle("Resharper.ProtoBuf.Rules")]
[assembly: AssemblyDescription("Rules to check and fix errors on ProtoBuf-net and Data Contract attributes")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Julien Adam")]
[assembly: AssemblyProduct("Resharper.ProtoBuf.Rules")]
[assembly: AssemblyCopyright("Copyright © Julien Adam 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b610e5c7-a642-4fd7-a6fb-627332c4b99e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: InternalsVisibleTo("Resharper.Protobuf.Rules.Tests")]

[assembly: PluginTitle("Resharper ProtoBuf Rules")]
[assembly: PluginDescription("Rules to check and fix errors on ProtoBuf-net and Data Contract attributes")]
[assembly: PluginVendor("Julien Adam")]
