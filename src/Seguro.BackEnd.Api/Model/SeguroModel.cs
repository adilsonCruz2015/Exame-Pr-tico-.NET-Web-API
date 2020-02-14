using System;

namespace Seguro.BackEnd.Api.Model
{
    public class SeguroModel
    {
        public Guid Veiculo { get;  set; }

        public Guid Segurado { get; set; }
    }
}