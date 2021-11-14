using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChallengeV1
{
    class Program
    {
        static void Main(string[] args)
        {
            var validWorldVectorinp = false; var validDroneVectorinp = false; var validDroneCommandinp = false; var droneCmdComplete = false;
            List<string> worldVectorArr = new List<string>();
            List<string> droneVectorArr = new List<string>();
            List<string> directionList = new List<string> { "LEFT", "RIGHT", "UP", "DOWN", "FORWARD", "BACKWARD" };
            List<DroneCmdViewModel> droneCommandList = new List<DroneCmdViewModel>();

            Console.WriteLine("=== Volodrone Initialising");
            Console.WriteLine("=== Volodrone Sensor Data Read");

            while (!validWorldVectorinp)
            {
                Console.WriteLine("=== Enter World Vector Data (ex:10 10 10)");
                var worldVectorVal = Console.ReadLine();
                worldVectorVal = Regex.Replace(worldVectorVal, @"\s+", " ");
                validWorldVectorinp = worldVectorVal.All(a => Char.IsDigit(a) || a == ' ') && worldVectorVal.Count(Char.IsWhiteSpace) == 2;
                if (!validWorldVectorinp)
                {
                    Console.WriteLine("Invalid 'World Vector' input!. Kindly try again.");
                }
                else {
                    worldVectorArr = worldVectorVal.Split(' ').ToList();
                }
            }

            while (!validDroneVectorinp)
            {
                Console.WriteLine("=== Enter Drone Vector Data (ex:5 5 5)");
                var droneVectorVal = Console.ReadLine();
                droneVectorVal = Regex.Replace(droneVectorVal, @"\s+", " ");
                validDroneVectorinp = droneVectorVal.All(a => Char.IsDigit(a) || a == ' ') && droneVectorVal.Count(Char.IsWhiteSpace) == 2;
                if (!validDroneVectorinp)
                {
                    Console.WriteLine("Invalid 'Drone Vector' input!. Kindly try again.");
                }
                else
                {
                    droneVectorArr = droneVectorVal.Split(' ').ToList();
                }
            }

            while (!droneCmdComplete)
            {
                Console.WriteLine("=== Enter Drone Command Data (ex:01 LEFT 2)");
                foreach (var item in droneCommandList)
                {
                    StringBuilder cmdStringBuilder = new StringBuilder();
                    cmdStringBuilder.Append(item.OrderNo);
                    cmdStringBuilder.Append(' ');
                    cmdStringBuilder.Append(item.OrderDirection);
                    cmdStringBuilder.Append(' ');
                    cmdStringBuilder.Append(item.OrderDistance);
                    Console.WriteLine(Convert.ToString(cmdStringBuilder));
                }
                var droneCmdVal = Console.ReadLine();
                droneCmdVal = Regex.Replace(droneCmdVal, @"\s+", " ");
                validDroneCommandinp = droneCmdVal.All(a => Char.IsLetterOrDigit(a) || a == ' ') && droneCmdVal.Count(Char.IsWhiteSpace) == 2;
                if (droneCmdVal.Count(Char.IsWhiteSpace) == 2)
                {
                    List<string> currentCmdCheck = droneCmdVal.Split(' ').ToList();
                    string directionInpVal = currentCmdCheck[1];
                    var orderInpVal = int.TryParse(currentCmdCheck[0], out int orderOutput);
                    var distanceInpVal = int.TryParse(currentCmdCheck[2], out int distanceOutput);
                    if (!directionList.Contains(directionInpVal, StringComparer.OrdinalIgnoreCase)
                        || !orderInpVal || !distanceInpVal
                        )
                    {
                        validDroneCommandinp = false;
                        //Console.WriteLine("Invalid 'Drone Command Direction' input!. Kindly try again.");
                    }
                    if (droneCommandList.Any(a => a.OrderNo == Convert.ToInt32(currentCmdCheck[0])))
                    {
                        validDroneCommandinp = false;
                    }
                }
                if (!validDroneCommandinp)
                {
                    Console.WriteLine("Invalid 'Drone Command' input!. Kindly try again.");
                }
                else {
                    List<string> currentCmdList = droneCmdVal.Split(' ').ToList();
                    DroneCmdViewModel droneCmdViewModel = new DroneCmdViewModel();
                    droneCmdViewModel.OrderNo = Convert.ToInt32(currentCmdList[0]);
                    droneCmdViewModel.OrderDirection = (currentCmdList[1]).ToUpper();
                    droneCmdViewModel.OrderDistance = Convert.ToInt32(currentCmdList[2]);
                    droneCommandList.Add(droneCmdViewModel);

                    Console.WriteLine("Provision of drone directions completed (y/n): ");
                    string checkContinuity = Console.ReadLine();
                    bool checkContinuityFlag = (checkContinuity == "y" || checkContinuity == "n") ? true : false;
                    while (!checkContinuityFlag)
                    {
                        Console.WriteLine("Invalid Selection!. Kindly try again.");
                        Console.WriteLine("Provision of drone directions completed (y/n): ");
                        checkContinuity = Console.ReadLine();
                    }
                    droneCmdComplete = checkContinuity == "y" ? true : false;
                }
            }

            Vector vector = new Vector();
            bool crashTestStatus = vector.VectorMovement(worldVectorArr, droneVectorArr, droneCommandList);
            if (!crashTestStatus)
            {
                //Console.WriteLine("CRASH IMMINENT - AUTOMATIC COURSE CORRECTION --> (0,5,5)");
            }
            Console.WriteLine("=== Volodrone Landing");
            Console.ReadLine();
        }
    }
}
