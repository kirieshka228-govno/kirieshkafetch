using Microsoft.Win32;
using Spectre.Console;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Инфа о системе


// ОС
using var osvar = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

// Процессор
using var procvar = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");

// Видеокарта
using var gpuvar = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}\0000");

// Название компьютера
using var hostvar = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS");


string osversion = $"{osvar?.GetValue("ProductName")}" ?? "Неизвестна:(";

string buildNumberStr = osvar?.GetValue("CurrentBuild")?.ToString() ?? "0";

if (int.TryParse(buildNumberStr, out int build) && build >= 22000)
{
    osversion = osversion.Replace("Windows 10", "Windows 11");
}

string osdisplayver = $"{osvar?.GetValue("DisplayVersion")}" ?? "Неизвестна:(";

string os = $"{osversion} {osdisplayver}";

string cpu = $"{procvar?.GetValue("ProcessorNameString")}" ?? "Неизвестна:(";

string gpu = $"{gpuvar?.GetValue("DriverDesc")}" ?? "Неизвестна:(";

string cores = $"{Environment.ProcessorCount}";

string vendor = $"{hostvar?.GetValue("BaseBoardManufacturer")}" ?? "Неизвестна:(";

string product = $"{hostvar?.GetValue("BaseBoardProduct")}" ?? "Неизвестна:(";

string host = $"{vendor} {product}";

string username = $"{Environment.UserName}";

string machinename = $"{Environment.MachineName}";

// Вывод
string kfoutput = $"""
⠀⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⣠⣄⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀{username}@{machinename}
⠀⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⠻⡿⠆[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀--------------------
⠀⠀⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⢘⣿⡀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀[bold aqua]OS:[/] {os}
⠀⠀⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⢀⠿⠥⠤⠀⡀[/]⠀⠀⠀⠀⠀⠀⠀⠀[bold LightPink1]Хост:[/] {host}
⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⡠⡄⣤⠀⠀⠀⢀⠃⣷⡄[/]⠀⠀⠀⠀⠀⠀[bold LightPink1]Проц:[/] {cpu}
⠀⠀⠀⠀⠀⠀[bold LightGreen]⠠⠀⠆⠀⠀⠐⠀⠈⠀⠨⠂⡄[/]⠀⠀⠀⠀⠀[bold LightPink1]Потоков:[/] {cores}
⠀⠀⠀⠀⠀[bold LightGreen]⠀⠚⠀⠠⠀⠀⠀⠀⢀⠀⠈⠐⣠⠀[/]⠀⠀⠀⠀[bold LightSalmon3_1]Видюха:[/] {gpu}
⠀⠀⠀⠀⠀[bold LightGreen]⠐⠀⠀⠀⠂⠀⠀⡀⠀⠀⠂⢁⢊⡅[/]⠀⠀⠀⠀
⠀⠀⠀⠀[bold LightGreen]⢀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠂⡐⢼⡀[/]⠀⠀⠀
⠀⠀⠀⠀[bold LightGreen]⠂⠀⠀⠀⠂⠀⠀⣆⠀⠀⠀⠈⠄⠀⡔⣣[/]⠀⠀
⠀⠀⠀[bold LightGreen]⡡⠊⢆⠀⡀⠀⠀⡇⠈⠣⡀⠀⠀⠡⠀⠌⠐⣣[/]⠀⠀
⠀[bold LightGreen]⡐⣬⢑⡅⢊⢎⣛⢬⡅⢧⠡⣂⣀⣄⠀⠈⠠⠈⠠⢘⢧[/]⠀
[bold LightGreen]⢀⢱⡖⣍⣿⣧⠀⠣⣧⠓⠀⡜⣅⣿⣿⣧⢀⠐⠀⠂⢤⠭⡂[/]
[bold LightGreen]⠠⠸⢇⠻⣿⡟⠂⠀⠘⢷⠀⠈⢿⣿⡿⡻⡉⠄⡁⠀⢀⠨⡆[/]
[bold LightGreen]⠨⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠈⠀⠣⠀⠄⠐⠀⢁⡂[/]
[bold LightGreen]⠈⡀⠀⠀⠀⠀⠀⢤⣀⣀⣠⠆⠀⠀⠀⠀⠁⠐⠌⠄⡠⢷⠃[/]
⠀[bold LightGreen]⠐⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠁⠀⡃⠠⣂⢢⡜[/]⠀
⠀⠀[bold LightGreen]⠈⢄⠁⢀⠀⡀⠀⠀⡀⠀⠠⠀⠀⠀⡠⠀⢁⢒⠈[/]⠀⠀
⠀⠀⠀⠀[bold LightGreen]⠐⠠⡀⠂⠈⠄⠀⣀⠀⠈⢂⠈⠠⡰⠖⠁[/]⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀[bold LightGreen]⠉⠛⠷⣶⢾⣼⣧⡿⠷⠋⠁[/]⠀⠀⠀⠀⠀
""";

AnsiConsole.Markup(kfoutput);

