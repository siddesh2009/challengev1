using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeV1
{
    /// <summary>
    /// DroneCmdViewModel class to hold the drone command 
    /// </summary>
    public class DroneCmdViewModel
    {
        public int OrderNo { get; set; }
        public string OrderDirection { get; set; }
        public int OrderDistance { get; set; }
    }
}
