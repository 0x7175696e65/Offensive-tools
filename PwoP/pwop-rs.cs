using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace PwoP
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            RunspaceInvoke ri = new RunspaceInvoke(rs);
            Pipeline pipeL = rs.CreatePipeline();

            pipeL.Commands.AddScript(args[0]);
            pipeL.Commands.Add("Out-String");

            Collection<PSObject> output = pipeL.Invoke();

            rs.Close();
            foreach(PSObject line in output)
            {
                sb.AppendLine(line.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
