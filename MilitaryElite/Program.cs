using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> allSoldiers = new List<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();

                string type = info[0];
                string id = info[1];
                string firstName = info[2]; 
                string lastName = info[3];

                if(type == "Private")
                {
                    decimal salary = decimal.Parse(info[4]);
                    Private privateSoldier=new Private(id, firstName, lastName,salary);
                    allSoldiers.Add(privateSoldier);
                }
                else if(type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(info[4]);

                    List<ISoldier> underGeneralCommand = new List<ISoldier>();

                    if (info.Length >= 5)
                    {
                        for (int i = 5; i < info.Length; i++)
                        {
                            string privateId = info[i];
                            ISoldier? soldier = allSoldiers.Where(s => s.Id == privateId).FirstOrDefault();
                            underGeneralCommand.Add(soldier);
                        }
                    }

                    LieutenantGeneral general 
                        = new LieutenantGeneral(id, firstName, lastName, salary, underGeneralCommand);

                    allSoldiers.Add(general);
                }
                else if(type == "Engineer")
                {
                    decimal salary = decimal.Parse(info[4]);
                    string corpsType = info[5];

                    bool enumIsValid = Enum.TryParse(corpsType, out Corps corps);
                    
                    if(!enumIsValid)
                    {
                        continue;
                    }
                    
                    //repairs
                    List<Repair> repairs = new List<Repair>();
                    if (info.Length > 6)
                    {
                        for (int i = 6; i < info.Length; i += 2)
                        {
                            string part = info[i];
                            int hours = int.Parse(info[i + 1]);

                            Repair repair = new Repair(part, hours);
                            repairs.Add(repair);
                        }
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);

                    allSoldiers.Add(engineer);
                }
                else if(type == "Commando")
                {
                    decimal salary = decimal.Parse(info[4]);
                    string corpsType = info[5];

                    bool enumIsValid = Enum.TryParse(corpsType, out Corps corps);

                    if (!enumIsValid)
                    {
                        continue;
                    }

                    List<Mission> missions = new List<Mission>();
                    if (info.Length > 6)
                    {
                        for (int i = 6; i < info.Length; i += 2)
                        {
                            string missionName = info[i];

                            string state = info[i + 1];

                            bool missionIsValid = Enum.TryParse(state, out MissionState missionState);

                            if (!missionIsValid)
                            {
                                continue;
                            }

                            Mission mission = new Mission(missionName, missionState);
                            missions.Add(mission);
                        }
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    allSoldiers.Add(commando);
                }
                else if(type == "Spy")
                {
                    int codeNumber = int.Parse(info[4]);

                    Spy spy=new Spy(id, firstName, lastName, codeNumber);
                    allSoldiers.Add(spy);
                }
            }

            foreach(var soldier in allSoldiers)
            {
                Console.WriteLine(soldier.ToString().TrimEnd());
            }
        }
    }
}