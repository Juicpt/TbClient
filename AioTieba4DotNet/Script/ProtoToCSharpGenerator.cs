using System.Diagnostics;

public class ProtoToCSharpGenerator
{
    public const string BasePath = "";
    public const string BaseDirectory = $@"{BasePath}\Api\Protobuf";

    public static void Main()
    {
        // 设置你希望扫描的目录
        string targetDirectory = $@"{BasePath}\Api";

        // 检查目标目录是否存在
        if (!Directory.Exists(targetDirectory))
        {
            Console.WriteLine($"指定的目录不存在: {targetDirectory}");
            return;
        }

        // 搜索指定目录中的所有 .proto 文件
        string[] protoFiles = Directory.GetFiles(targetDirectory, "*.proto", SearchOption.AllDirectories);

        if (protoFiles.Length == 0)
        {
            Console.WriteLine("未找到任何 .proto 文件。");
            return;
        }

        // 遍历所有找到的 proto 文件并生成相应的 C# 代码
        foreach (string protoFile in protoFiles)
        {
            Console.WriteLine($"正在处理: {protoFile}");
            GenerateCSharpCode(protoFile);
        }

        Console.WriteLine("C# 代码生成完成！");
    }

    static void GenerateCSharpCode(string protoFile)
    {
        // 获取 proto 文件所在的目录
        var directory = Path.GetDirectoryName(protoFile);

        // 生成 C# 文件命令
        var command = $"protoc --csharp_opt=serializable --csharp_out={directory} --proto_path={directory} -I {BaseDirectory} {protoFile}";
    
        // 执行命令
        RunCommand(command);
    }

    static void RunCommand(string command)
    {
        try
        {
            // 设置命令行进程
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {command}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // 启动进程并执行命令
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            // 输出执行结果
            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine("输出: " + output);
            }

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("错误: " + error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("执行命令时出错: " + ex.Message);
        }
    }
}