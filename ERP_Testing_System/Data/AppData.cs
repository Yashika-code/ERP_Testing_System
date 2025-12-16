using System.Collections.Generic;
using ERP_Testing_System.Models;

namespace ERP_Testing_System.Data
{
    public static class AppData
    {
        public static List<PartCode> PartCodes = new();
        public static List<Party> Parties = new();
        public static List<IECStandard> IECStandards = new();
        public static List<ModelMaster> Models = new();
        public static List<ClassMaster> Classes = new();
        public static List<VAMaster> VAs = new();
        public static List<LabelMaster> Labels = new();
    }
}
