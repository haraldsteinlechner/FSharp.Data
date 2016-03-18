#load "../src\CommonProviderImplementation/AssemblyReader.fs"

let file = System.IO.Path.Combine(__SOURCE_DIRECTORY__,"ConsoleApplication4.exe")
let private assemblyReader = ProviderImplementation.AssemblyReader.ILModuleReaderAfterReadingAllBytes(file, ProviderImplementation.AssemblyReader.mkILGlobals ProviderImplementation.AssemblyReader.ecmaMscorlibScopeRef, true)
[for inp in assemblyReader.ILModuleDef.ManifestOfAssembly.CustomAttrs.Elements do 
         match ProviderImplementation.AssemblyReader.decodeILCustomAttribData assemblyReader.ILGlobals inp with
         | [] -> ()
         | args -> yield (inp.Method.EnclosingType.BasicQualifiedName, Seq.head [ for (_,arg) in args -> if isNull arg then "" else arg.ToString()]) ]
