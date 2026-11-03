using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Table
{
    public class TableListDto
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string QRCode { get; set; }
        public bool IsAvailable { get; set; }
    }
}
