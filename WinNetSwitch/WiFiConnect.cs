using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetSwitch
{
    class WiFiConnect
    {
        public void Connect(string ssid,string password)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("netsh", $"wlan connect name=\"{ssid}\" ssid=\"{ssid}\" key=\"{password}\"");
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (output.Contains("已成功完成连接请求"))
            {
                Console.WriteLine("已成功连接到指定WiFi网络");
            }
            else
            {
                Console.WriteLine("连接失败");
            }
        }

    }
}
