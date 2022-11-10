
Console.WriteLine("Hello, UpdateConference 2022!");

Directory.CreateDirectory("log");
Wasmtime.WasiConfiguration confi = new Wasmtime.WasiConfiguration()
    .WithStandardError("log/error.log")
    .WithStandardOutput("log/output.log")
    .WithArg("CalledFromConsole")
    .WithArgs(args); //passing args

var engine = new Wasmtime.Engine();
var linker = new Wasmtime.Linker(engine);
linker.DefineWasi();
var store = new Wasmtime.Store(engine);
store.SetWasiConfiguration(confi);

string wasm = @"/Users/ntanis/GitHub/updateconference2022/Extend/MyRustModule/target/wasm32-wasi/debug/myrustmodule.wasm";
var module = Wasmtime.Module.FromFile(engine, wasm);
var inst = linker.Instantiate(store, module);
var main = inst.GetFunction("main");

if (main!=null)
    main.Invoke(0,0);