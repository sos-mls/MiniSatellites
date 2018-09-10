using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMaster.Models
{
    public interface ICreator
    {
        int Id { get; set; }
        string Name { get; set; }
        string Hash { get; set; }
        string Json { get; set; }
    }
}
