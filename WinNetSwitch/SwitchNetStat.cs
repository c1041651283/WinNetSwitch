using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetSwitch
{
    internal class SwitchNetStat
    {

        /// <summary>
        /// 网卡的禁用/启用方法
        /// </summary>
        /// <param name="enable">是bool值，表示网卡的启用或禁用，false 禁用</param>
        /// <param name="networkConnectionName">网卡显示的名称，一般是：本地连接，本地连接 2这样的。</param>
        /// <returns></returns>
        public bool ChangeNetworkConnectionStatus(bool enable, string networkConnectionName)
        {
            using (Process process = new Process())
            {
                string netshCmd = "interface set interface name=\"{0}\" admin={1}";
                process.EnableRaisingEvents = false;
                process.StartInfo.Arguments = String.Format(netshCmd, networkConnectionName, enable ? "ENABLED" : "DISABLED");
                process.StartInfo.FileName = "netsh.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                string rtn = process.StandardOutput.ReadToEnd();
                if (rtn.Trim().Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
