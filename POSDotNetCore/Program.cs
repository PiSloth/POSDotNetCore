﻿//Kabukii sama
//using POSDotNetCore.AdoDotNetExamples;
//using POSDotNetCore.DapperExamples;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Run();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

using POSDotNetCore.EFCoreExamples;

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Edit(1);
eFCoreExample.Create("Sloths", "Moving slowly", "But he is strong in sticky");
eFCoreExample.Update(1, "Lwin", "Studying", "I'm lazy to study.");
eFCoreExample.Delete(21);
eFCoreExample.Read();