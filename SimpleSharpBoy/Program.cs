
using SimpleSharpBoy;

var data = File.ReadAllBytes(args[0]);
var cartridge = new Cartridge(data);

var bus = new Bus16Bit();

var cpu = new SimpleBoyCPU(bus);
var ppu = new SimplePPU(bus, true);
var dma = new SimpleDMA(bus);

bus.Connect(cartridge);
bus.Connect(dma);

var console = new SimpleConsole(cpu, ppu, dma);

Console.WriteLine("####################");
Console.WriteLine($"{nameof(cartridge.Title)} = {cartridge.Title}");
Console.WriteLine($"{nameof(cartridge.LicenseeCode)} = {cartridge.LicenseeCode}");
Console.WriteLine($"{nameof(cartridge.RomSize)} = {cartridge.RomSize}");
Console.WriteLine($"{nameof(cartridge.RamSize)} = {cartridge.RamSize}");
Console.WriteLine($"Type = {cartridge.Type}");
Console.WriteLine("####################");

console.PowerOn();