using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrderStatus
{
    public struct GetOrderStatusCmd
    {
        public String SessionID { get; }

        public GetOrderStatusCmd(String sessionID)
        {
            SessionID = sessionID;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
            // If the SessionID Exists in the AllHardCodedValues.HardcodedVals.Carts Dictionary it will return true. false otherwise
            //return AllHardcodedValues.HarcodedVals.Carts.ContainsKey(SessionID) ? true : false;
        }
    }
}