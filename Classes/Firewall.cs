using System;
using NetFwTypeLib;

namespace Patch.Classes
{
    internal sealed class Firewall
    {
        internal static void AddRule(string Name, string Description, string Path)
        {
            Type NetFwPolicy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 FwPolicy = (INetFwPolicy2)Activator.CreateInstance(NetFwPolicy);
            Type NetFwRule = Type.GetTypeFromProgID("HNetCfg.FwRule");
            INetFwRule2 FwRule = (INetFwRule2)Activator.CreateInstance(NetFwRule);
            FwRule.Enabled = true;
            FwRule.Name = Name;
            FwRule.Description = Description;
            FwRule.ApplicationName = Path;
            FwRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
            FwRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            FwRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            FwRule.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            FwRule.EdgeTraversal = false;
            FwPolicy.Rules.Add(FwRule);
        }
    }
}
