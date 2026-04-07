using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTools.Desktop.Common
{
    class AgentTool
    {
        private static List<Agent> agents = new List<Agent>{
            new Agent{AgentName = "许航", AgentCode = "BD8B336C-CEB6-4872-9A3B-08DD54265EDD" },
            new Agent{AgentName = "锦囊", AgentCode = "48B6B98F-0D89-43CF-9A3A-08DD54265EDD" },
            new Agent{AgentName = "同创", AgentCode = "FC43C563-C927-4442-9A39-08DD54265EDD" }
        };
        public static string GetAgentCode(string agentName)
        {
            return agents.FirstOrDefault(x => x.AgentName == agentName).AgentCode;
        }
    }
    class Agent
    {
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
    }
}
