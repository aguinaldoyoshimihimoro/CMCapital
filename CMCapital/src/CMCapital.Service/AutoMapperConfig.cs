using AutoMapper;
using CMCapital.Domain;
//using CMCapital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCapital.Service
{
    public class AutoMapperConfig
    {

        public AutoMapperConfig()
        {
            Configure();
        }

        public MapperConfiguration _config;

        public IMapper Instanciar()
        {
            return _config.CreateMapper();
        }

        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<ProcessResult, ProcessResultViewModel>();

                //cfg.CreateMap<SecurityType, SecurityTypeViewModel>();

                //cfg.CreateMap<StressScenario, StressScenarioViewModel>();

                //cfg.CreateMap<WithdrawalMatrix, WithdrawalsMatrixViewModel>();

                //cfg.CreateMap<Term, TermViewModel>();

            });
        }

    }
}