
using SimpleSharpBoy;

var data = File.ReadAllBytes("cpu_instrs/individual/06-ld r,r.gb");
var cartridge = new Cartridge(data);
var bus = new Bus16Bit();
var cpu = new Z80GB(bus);
var ppu = new SimplePPU(bus, true);
var console = new SimpleSharpConsole(cpu, ppu);

Console.WriteLine("####################");
Console.WriteLine($"{nameof(cartridge.Title)} = {cartridge.Title}");
Console.WriteLine($"{nameof(cartridge.LicenseeCode)} = {cartridge.LicenseeCode}");
Console.WriteLine($"{nameof(cartridge.RomSize)} = {cartridge.RomSize}");
Console.WriteLine($"{nameof(cartridge.RamSize)} = {cartridge.RamSize}");
Console.WriteLine($"Type = {cartridge.Type}");
Console.WriteLine("####################");

bus.Load(data);
console.PowerOn();