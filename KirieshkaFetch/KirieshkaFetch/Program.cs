using Microsoft.Win32;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Инфа о системе

using var osvar = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"); // ОС

using var procvar = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0"); // Процессор

using var gpuvar = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}\0000"); // Видеокарта

using var hostvar = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS"); // Название компьютера

string osversion = $"{osvar?.GetValue("ProductName")}";

string buildNumberStr = osvar?.GetValue("CurrentBuild")?.ToString() ?? "0";

if (int.TryParse(buildNumberStr, out int build) && build >= 22000)
{
    osversion = osversion.Replace("Windows 10", "Windows 11");
}

string osdisplayver = $"{osvar?.GetValue("DisplayVersion")}";

string os = $"{osversion} {osdisplayver}";

string cpu = $"{procvar?.GetValue("ProcessorNameString")}";

string gpu = $"{gpuvar?.GetValue("DriverDesc")}";

string cores = $"{Environment.ProcessorCount}";

string vendor = $"{hostvar?.GetValue("BaseBoardManufacturer")}";

string product = $"{hostvar?.GetValue("BaseBoardProduct")}";

string host = $"{vendor} {product}";

// Вывод
string kfoutput = $"""
⠀⠀⠀⠀⠀⠀⠀⠀⣠⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀KIRIESHKA FETCH 1.0
⠀⠀⠀⠀⠀⠀⠀⠀⠻⡿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀--------------------
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢘⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ОС: {os}
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠿⠥⠤⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀Хост: {host}
⠀⠀⠀⠀⠀⠀⠀⡠⡄⣤⠀⠀⠀⢀⠃⣷⡄⠀⠀⠀⠀⠀⠀Проц: {cpu}
⠀⠀⠀⠀⠀⠀⠠⠀⠆⠀⠀⠐⠀⠈⠀⠨⠂⡄⠀⠀⠀⠀⠀Потоков: {cores}
⠀⠀⠀⠀⠀⠀⠚⠀⠠⠀⠀⠀⠀⢀⠀⠈⠐⣠⠀⠀⠀⠀⠀Видюха: {gpu}
⠀⠀⠀⠀⠀⠐⠀⠀⠀⠂⠀⠀⡀⠀⠀⠂⢁⢊⡅⠀⠀⠀⠀
⠀⠀⠀⠀⢀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠂⡐⢼⡀⠀⠀⠀
⠀⠀⠀⠀⠂⠀⠀⠀⠂⠀⠀⣆⠀⠀⠀⠈⠄⠀⡔⣣⠀⠀⠀
⠀⠀⠀⡡⠊⢆⠀⡀⠀⠀⡇⠈⠣⡀⠀⠀⠡⠀⠌⠐⣣⠀⠀
⠀⡐⣬⢑⡅⢊⢎⣛⢬⡅⢧⠡⣂⣀⣄⠀⠈⠠⠈⠠⢘⢧⠀
⢀⢱⡖⣍⣿⣧⠀⠣⣧⠓⠀⡜⣅⣿⣿⣧⢀⠐⠀⠂⢤⠭⡂
⠠⠸⢇⠻⣿⡟⠂⠀⠘⢷⠀⠈⢿⣿⡿⡻⡉⠄⡁⠀⢀⠨⡆
⠨⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠈⠀⠣⠀⠄⠐⠀⢁⡂
⠈⡀⠀⠀⠀⠀⠀⢤⣀⣀⣠⠆⠀⠀⠀⠀⠁⠐⠌⠄⡠⢷⠃
⠀⠐⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠁⠀⡃⠠⣂⢢⡜⠀
⠀⠀⠈⢄⠁⢀⠀⡀⠀⠀⡀⠀⠠⠀⠀⠀⡠⠀⢁⢒⠈⠀⠀
⠀⠀⠀⠀⠐⠠⡀⠂⠈⠄⠀⣀⠀⠈⢂⠈⠠⡰⠖⠁⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠉⠛⠷⣶⢾⣼⣧⡿⠷⠋⠁⠀⠀⠀⠀⠀
""";

Console.Write(kfoutput);

