using System;
using System.Collections.Generic;

namespace QB3API.Model
{
    public partial class QuestionStore
    {
        public Guid Guid { get; set; }
        public string Data { get; set; } = null!;
        public DateTime? CreationDate { get; set; }
    }
}
