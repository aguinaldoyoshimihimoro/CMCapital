using System;

namespace CMCapital.Domain.Infrastructure
{
    public class LogProcessRequest
    {
        public int Id                           { get; set; }
        public int CompositionId                { get; set; }
        public string Content                   { get; set; }
        public int PortfolioId                  { get; set; }
        public string PortfolioName             { get; set; }
        public DateTime RequestedOn             { get; set; }
    }
}
