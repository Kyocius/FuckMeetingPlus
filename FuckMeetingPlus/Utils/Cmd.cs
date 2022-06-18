using System.Diagnostics;

namespace FuckMeetingPlus.Utils;

public class Cmd
{
    /// <summary>
    /// 执行cmd命令 返回cmd窗口显示的信息
    /// 多命令请使用批处理命令连接符：
    /// <![CDATA[
    /// &:同时执行两个命令
    /// |:将上一个命令的输出,作为下一个命令的输入
    /// &&：当&&前的命令成功时,才执行&&后的命令
    /// ||：当||前的命令失败时,才执行||后的命令]]>
    /// </summary>
    ///<param name="command">执行的命令</param>
    public static string RunCommand(string command)
    {
        command = command.Trim().TrimEnd('&') + "&exit";//不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
        using (Process p = new Process())
        {
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
            p.StartInfo.CreateNoWindow = true; //不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口写入命令
            p.StandardInput.WriteLine(command);
            p.StandardInput.AutoFlush = true;

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            return output;
        }
    }
}