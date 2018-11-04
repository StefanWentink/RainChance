// some .cs file included in your project
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo(assemblyName: "RainChance.DAL.Test")]
[assembly: InternalsVisibleTo(assemblyName: "RainChance.DAL.Integration")]
[assembly: ComVisible(false)]