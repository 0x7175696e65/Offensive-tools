using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace DotNetLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] binary = Convert.FromBase64String(args[0]);
            List<string> processArgs = new List<string>();
            processArgs.Add(args[1]);

            try
            {
                Assembly assembly = Assembly.Load(binary);
                MethodInfo mI = assembly.EntryPoint;
                Console.WriteLine(mI.Name);

                assembly.CreateInstance(mI.Name);
                mI.Invoke(null, new object[] { (object[])processArgs.ToArray() });

            }
            catch
            {
                Console.WriteLine("Invalid data");
            }

        }
    }
}
