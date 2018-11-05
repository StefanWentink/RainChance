// some .cs file included in your project
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo(assemblyName: "RainChance.BL.Test")]
[assembly: InternalsVisibleTo(assemblyName: "RainChance.BL.Integration")]
[assembly: ComVisible(false)]