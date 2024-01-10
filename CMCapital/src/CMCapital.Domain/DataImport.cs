using System;

namespace CMCapital.Domain
{
    public class DataImport
    {
        public int Id { get; set; }

        public DateTime ImportDate { get; set; }

        public DateTime ReferenceDate { get; set; }

        public bool IsSuccess { get; set; }
    }
}