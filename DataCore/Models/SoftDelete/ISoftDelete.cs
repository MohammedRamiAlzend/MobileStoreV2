using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.SoftDelete;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public void Undo()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}
